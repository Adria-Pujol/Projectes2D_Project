using UnityEngine;

namespace Enemies
{
    public class EnemyGroundChecker : MonoBehaviour
    {
        public bool isGrounded;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Ground")) isGrounded = true;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            isGrounded = false;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Ground")) isGrounded = true;
        }
    }
}