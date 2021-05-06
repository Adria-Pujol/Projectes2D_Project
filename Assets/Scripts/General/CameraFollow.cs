using UnityEngine;

namespace General
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;
        [SerializeField] [Range(0, 10)] private float smoothFactor;

        private Vector2 _targetPosition;
        private void FixedUpdate()
        {
            Follow();
        }

        private void Follow()
        {
            var targetPosition = new Vector3(target.position.x, target.position.y, -10) + offset;
            var smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
            transform.position = smoothPosition;
        }
    }
}