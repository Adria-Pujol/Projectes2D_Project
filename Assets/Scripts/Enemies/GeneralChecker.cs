using UnityEngine;
using UnityEngine.Serialization;

namespace Enemies
{
    public class GeneralChecker : MonoBehaviour
    {
        public bool isWall;
        public bool isObject;
        public bool isEnemy;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Wall")) isWall = true;
            if (collision.CompareTag("Object")) isObject = true;
            if (collision.CompareTag("Enemy")) isEnemy = true;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            isWall = false;
            isObject = false;
            isEnemy = false;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Wall")) isWall = true;
        }
    }
}