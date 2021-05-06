using UnityEngine;

namespace Player
{
    public class WallChecker : MonoBehaviour
    {
        [SerializeField] private LayerMask wallLayer;

        public bool isWall;

        private void OnTriggerExit2D(Collider2D collision)
        {
            isWall = false;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            isWall = collision != null && ((1 << collision.gameObject.layer) & wallLayer) != 0;
        }
    }
}