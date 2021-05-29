using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWallChecker : MonoBehaviour
{
    [SerializeField] private LayerMask wallLayer;

    public bool isWall;
    public bool isRightGround;
    private void OnTriggerStay2D(Collider2D collision)
    {
        isWall = collision != null && ((1 << collision.gameObject.layer) & wallLayer) != 0;
        if (collision.CompareTag("Ground"))
        {
            isRightGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isWall = false;
        isRightGround = false;
    }
}
