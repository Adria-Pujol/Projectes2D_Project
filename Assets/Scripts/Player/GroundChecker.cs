using UnityEngine;

namespace Player
{
    public class GroundChecker : MonoBehaviour
    {
        public bool isGrounded;
        public bool isTopWalled;
        public bool isSpike;
        public bool isInObject;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Ground")) isGrounded = true;
            if (collision.CompareTag("Spike")) isSpike = true;
            if (collision.CompareTag("Wall")) isTopWalled = true;
            if (collision.CompareTag("Object")) isInObject = true;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            isGrounded = false;
            isTopWalled = false;
            isSpike = false;
            isInObject = false;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Ground")) isGrounded = true;

            if (collision.CompareTag("Wall")) isTopWalled = true;
        }
    }
}