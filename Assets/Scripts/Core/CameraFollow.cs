using UnityEngine;

namespace AsphaltAnarchy.Core
{
    /// <summary>
    /// Minimal third-person chase camera. No camera system existed anywhere
    /// in the project before this — every other player-vehicle dependency
    /// (input, stats, grab/hijack) reuses existing systems; this one didn't
    /// have anything to reuse.
    /// </summary>
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset = new Vector3(0f, 3f, -6f);
        [SerializeField] private float positionSmoothTime = 0.15f;
        [SerializeField] private float lookAtHeight = 1f;

        private Vector3 velocity;

        public void SetTarget(Transform newTarget) => target = newTarget;

        private void LateUpdate()
        {
            if (target == null) return;

            Vector3 desiredPosition = target.TransformPoint(offset);
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, positionSmoothTime);
            transform.LookAt(target.position + Vector3.up * lookAtHeight);
        }
    }
}
