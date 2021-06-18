using System;
using UnityEngine;

namespace Enemies
{
    public class TutorialEnemy : MonoBehaviour
    {

        public Rigidbody2D _body;

        public void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
        }

        public void FixedUpdate()
        {
            if (gameObject.GetComponent<Enemy>().dead)
            {
                BoxCollider2D collider = GetComponent<BoxCollider2D>();
                collider.enabled = false;
                _body.gravityScale = 0;
            }
        }
    }
}