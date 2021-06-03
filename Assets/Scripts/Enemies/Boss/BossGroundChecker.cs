using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGroundChecker : MonoBehaviour
{
    public bool isGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground")) isGrounded = true;
        if (collision.CompareTag("Platform")) isGrounded = true;
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
