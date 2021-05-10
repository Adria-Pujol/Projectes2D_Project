using Player;
using UnityEngine;

namespace General
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] [Range(0, 10)] private float smoothFactor;
        [SerializeField] private float rightFactor;
        [SerializeField] private float upFactor;

        private Vector2 _targetPosition;
        private float direction;
        private bool playerDirection;

        private void FixedUpdate()
        {
            playerDirection = target.GetComponent<PlayerController>().isFacingRight;
            if (playerDirection)
                direction = 1;
            else
                direction = -1;
            Follow();
        }

        private void Follow()
        {
            var targetPosition = new Vector3(target.position.x + rightFactor * direction, target.position.y + upFactor,
                -10);
            var smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
            transform.position = smoothPosition;
        }
    }
}