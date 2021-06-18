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
        if (collision.CompareTag("Wall"))
        {
            isWall = true;
        }
        if (collision.CompareTag("Ground"))
        {
            isRightGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isWall = false;
        isWall = false;
        isRightGround = false;
    }
}
