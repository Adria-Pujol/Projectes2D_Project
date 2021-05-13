using UnityEngine;

namespace Player
{
    public class WallChecker : MonoBehaviour
    {
        [SerializeField] private LayerMask wallLayer;

        public bool isWall;
        public bool isRightGround;

        private void OnTriggerExit2D(Collider2D collision)
        {
            isWall = false;
            isRightGround = false;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            isWall = collision != null && ((1 << collision.gameObject.layer) & wallLayer) != 0;
            if (collision.CompareTag("Ground") || collision.CompareTag("Object"))
            {
                isRightGround = true;
            }
        }
    }
}