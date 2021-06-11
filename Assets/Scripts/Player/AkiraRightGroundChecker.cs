using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkiraRightGroundChecker : MonoBehaviour
{
    public bool isRightGround;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isRightGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isRightGround = false;
    }
}