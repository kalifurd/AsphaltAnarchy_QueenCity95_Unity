using UnityEngine;
using AsphaltAnarchy.Core;

namespace AsphaltAnarchy.Vehicle
{
    /// <summary>
    /// Physics-based motorcycle controller using WheelColliders.
    /// Handles acceleration, braking, steering, leaning, and nitrous.
    /// Adapts to surface types (wet asphalt, brick, metal grating).
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class MotorcycleController : MonoBehaviour
    {
        [Header("Wheel Colliders")]
        [SerializeField] private WheelCollider frontWheel;
        [SerializeField] private WheelCollider rearWheel;

        [Header("Wheel Meshes")]
        [SerializeField] private Transform frontWheelMesh;
        [SerializeField] private Transform rearWheelMesh;

        [Header("Physics Settings")]
        [SerializeField] private float maxSteerAngle = 30f;
        [SerializeField] private float steerSpeed = 5f;
        [SerializeField] private float maxLeanAngle = 45f;
        [SerializeField] private float leanSpeed = 3f;
        [SerializeField] private float centerOfMassOffset = -0.5f;
        [SerializeField] private float antiFlipTorque = 500f;

        [Header("Surface Detection")]
        [SerializeField] private LayerMask surfaceLayer;
        [SerializeField] private float surfaceCheckDistance = 0.5f;

        [Header("Visuals")]
        [SerializeField] private Transform bikeBody;
        [SerializeField] private Transform handlebars;
        [SerializeField] private ParticleSystem skidParticles;

        private Rigidbody rb;
        private PlayerStats playerStats;
        private WeatherSystem weatherSystem;
        private float currentSteerAngle;
        private float currentLeanAngle;
        private float currentMotorTorque;
        private float currentBrakeTorque;
        private float currentSpeed;
        private float nitrousBoost;
        private bool isGrounded;
        private SurfaceType currentSurface = SurfaceType.Asphalt;

        public float CurrentSpeedKmh => currentSpeed * 3.6f; // m/s to km/h
        public float CurrentSpeedMph => currentSpeed * 2.237f;
        public bool IsGrounded => isGrounded;
        public SurfaceType CurrentSurface => currentSurface;
        public Rigidbody Rigidbody => rb;
        public float MaxSteerAngle => maxSteerAngle;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            rb.centerOfMass = new Vector3(0f, centerOfMassOffset, 0f);
        }

        private void Start()
        {
            playerStats = GetComponent<PlayerStats>();
            if (playerStats == null)
                playerStats = FindObjectOfType<PlayerStats>();

            weatherSystem = FindObjectOfType<WeatherSystem>();
        }

        private void FixedUpdate()
        {
            HandlePhysics();
            DetectSurface();
            ApplyAntiFlip();
        }

        private void Update()
        {
            UpdateWheelMeshes();
            UpdateVisuals();
        }

        private void HandlePhysics()
        {
            float motorInput = Input.GetAxis("Vertical");
            float steerInput = Input.GetAxis("Horizontal");
            bool brakeInput = Input.GetButton("Jump");
            bool nitrousInput = Input.GetKey(KeyCode.LeftShift) && playerStats?.HasNitrousUnlocked == true;

            // Calculate speed
            currentSpeed = rb.linearVelocity.magnitude;

            // Surface grip multiplier
            float gripMultiplier = GetSurfaceGripMultiplier();

            // Motor torque
            float targetMotor = motorInput * (playerStats?.EnginePower ?? 150f);
            if (nitrousInput && nitrousBoost > 0f)
            {
                targetMotor *= 1.5f;
                nitrousBoost -= Time.fixedDeltaTime * 20f;
            }
            currentMotorTorque = Mathf.Lerp(currentMotorTorque, targetMotor, 0.1f);

            // Steering (speed-sensitive)
            float speedFactor = Mathf.Clamp01(1f - (currentSpeed / 50f));
            float targetSteer = steerInput * maxSteerAngle * speedFactor;
            currentSteerAngle = Mathf.Lerp(currentSteerAngle, targetSteer, steerSpeed * Time.fixedDeltaTime);

            // Braking
            float targetBrake = brakeInput ? playerStats?.BrakeForce ?? 2000f : 0f;
            currentBrakeTorque = Mathf.Lerp(currentBrakeTorque, targetBrake, 0.2f);

            // Apply to wheels
            rearWheel.motorTorque = currentMotorTorque * gripMultiplier;
            frontWheel.steerAngle = currentSteerAngle;
            frontWheel.brakeTorque = currentBrakeTorque;
            rearWheel.brakeTorque = currentBrakeTorque;

            // Leaning (visual + physics)
            float targetLean = -steerInput * maxLeanAngle * Mathf.Clamp01(currentSpeed / 10f);
            currentLeanAngle = Mathf.Lerp(currentLeanAngle, targetLean, leanSpeed * Time.fixedDeltaTime);

            // Apply lean torque for cornering feel
            Vector3 leanTorque = transform.forward * currentLeanAngle * 2f;
            rb.AddTorque(leanTorque, ForceMode.Force);

            isGrounded = frontWheel.isGrounded || rearWheel.isGrounded;
        }

        private void DetectSurface()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, surfaceCheckDistance, surfaceLayer))
            {
                string tag = hit.collider.tag;
                currentSurface = tag switch
                {
                    "WetAsphalt" => SurfaceType.WetAsphalt,
                    "Brick" => SurfaceType.Brick,
                    "MetalGrating" => SurfaceType.MetalGrating,
                    "Dirt" => SurfaceType.Dirt,
                    _ => SurfaceType.Asphalt
                };
            }
        }

        private float GetSurfaceGripMultiplier()
        {
            float surfaceGrip = currentSurface switch
            {
                SurfaceType.WetAsphalt => 0.7f,
                SurfaceType.Brick => 0.85f,
                SurfaceType.MetalGrating => 0.6f,
                SurfaceType.Dirt => 0.5f,
                _ => 1.0f
            };

            float weatherGrip = weatherSystem != null ? weatherSystem.CurrentGripMultiplier : 1.0f;
            return surfaceGrip * weatherGrip;
        }

        private void ApplyAntiFlip()
        {
            // Prevent backflips/frontflips by applying counter-torque
            Vector3 localAngular = transform.InverseTransformDirection(rb.angularVelocity);
            if (Mathf.Abs(localAngular.x) > 1f)
            {
                Vector3 counterTorque = -transform.right * localAngular.x * antiFlipTorque;
                rb.AddTorque(counterTorque, ForceMode.Force);
            }
        }

        private void UpdateWheelMeshes()
        {
            UpdateWheelPose(frontWheel, frontWheelMesh);
            UpdateWheelPose(rearWheel, rearWheelMesh);
        }

        private void UpdateWheelPose(WheelCollider collider, Transform mesh)
        {
            Vector3 pos;
            Quaternion rot;
            collider.GetWorldPose(out pos, out rot);
            mesh.position = pos;
            mesh.rotation = rot;
        }

        private void UpdateVisuals()
        {
            if (bikeBody != null)
            {
                bikeBody.localRotation = Quaternion.Euler(0f, 0f, currentLeanAngle);
            }

            if (handlebars != null)
            {
                handlebars.localRotation = Quaternion.Euler(0f, currentSteerAngle, 0f);
            }

            // Skid particles
            if (skidParticles != null)
            {
                bool isSkidding = currentBrakeTorque > 100f && currentSpeed > 5f;
                if (isSkidding && !skidParticles.isPlaying)
                    skidParticles.Play();
                else if (!isSkidding && skidParticles.isPlaying)
                    skidParticles.Stop();
            }
        }

        public void ApplyExternalForce(Vector3 force, ForceMode mode = ForceMode.Impulse)
        {
            rb.AddForce(force, mode);
        }

        public void ApplyExternalTorque(Vector3 torque, ForceMode mode = ForceMode.Impulse)
        {
            rb.AddTorque(torque, mode);
        }

        public void RefillNitrous(float amount)
        {
            nitrousBoost = Mathf.Min(nitrousBoost + amount, playerStats?.NitrousCapacity ?? 100f);
        }

        public void SetEnginePower(float power)
        {
            // Called when engine is upgraded
            // Value is read from PlayerStats each frame
        }

        public void Dismount(Vector3 ejectForce)
        {
            rb.AddForce(ejectForce, ForceMode.Impulse);
            rb.AddTorque(Random.insideUnitSphere * 5f, ForceMode.Impulse);
            // Trigger ragdoll or crash state
            GameManager.Instance?.ChangeState(GameState.GameOver);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, Vector3.down * surfaceCheckDistance);
        }
    }

    public enum SurfaceType
    {
        Asphalt,
        WetAsphalt,
        Brick,
        MetalGrating,
        Dirt
    }
}
