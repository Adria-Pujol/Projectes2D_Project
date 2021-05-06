using UnityEngine;

namespace Player
{
    public class GroundChecker : MonoBehaviour
    {
        public bool isGrounded;
        public bool isTopWalled;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Ground")) isGrounded = true;

            if (collision.CompareTag("Wall")) isTopWalled = true;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            isGrounded = false;
            isTopWalled = false;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Ground")) isGrounded = true;

            if (collision.CompareTag("Wall")) isTopWalled = true;
        }
    }
}