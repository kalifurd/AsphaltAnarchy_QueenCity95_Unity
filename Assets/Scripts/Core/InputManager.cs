using UnityEngine;

namespace AsphaltAnarchy.Core
{
    /// <summary>
    /// Centralized input handling with support for rebinding and context-sensitive actions.
    /// </summary>
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance { get; private set; }

        [Header("Input Axes")]
        public string throttleAxis = "Vertical";
        public string steerAxis = "Horizontal";
        public string brakeButton = "Jump";

        [Header("Action Keys")]
        public KeyCode attackKey = KeyCode.Mouse0;
        public KeyCode grabKey = KeyCode.F;
        public KeyCode hijackKey = KeyCode.G;
        public KeyCode nitrousKey = KeyCode.LeftShift;
        public KeyCode weaponSwitchLeft = KeyCode.Q;
        public KeyCode weaponSwitchRight = KeyCode.E;
        public KeyCode interactKey = KeyCode.E;
        public KeyCode pauseKey = KeyCode.Escape;
        public KeyCode mapKey = KeyCode.M;

        [Header("Gamepad")]
        public bool useGamepad = false;

        public float ThrottleInput { get; private set; }
        public float SteerInput { get; private set; }
        public bool BrakeInput { get; private set; }
        public bool AttackPressed { get; private set; }
        public bool GrabPressed { get; private set; }
        public bool HijackPressed { get; private set; }
        public bool NitrousHeld { get; private set; }
        public bool InteractPressed { get; private set; }
        public bool PausePressed { get; private set; }
        public bool MapPressed { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        private void Update()
        {
            ReadInputs();
        }

        private void ReadInputs()
        {
            ThrottleInput = Input.GetAxis(throttleAxis);
            SteerInput = Input.GetAxis(steerAxis);
            BrakeInput = Input.GetButton(brakeButton);

            AttackPressed = Input.GetKeyDown(attackKey);
            GrabPressed = Input.GetKeyDown(grabKey);
            HijackPressed = Input.GetKeyDown(hijackKey);
            NitrousHeld = Input.GetKey(nitrousKey);
            InteractPressed = Input.GetKeyDown(interactKey);
            PausePressed = Input.GetKeyDown(pauseKey);
            MapPressed = Input.GetKeyDown(mapKey);
        }

        public bool GetWeaponSwitchLeft() => Input.GetKeyDown(weaponSwitchLeft);
        public bool GetWeaponSwitchRight() => Input.GetKeyDown(weaponSwitchRight);
    }
}
