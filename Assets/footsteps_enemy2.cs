using Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps_enemy2 : MonoBehaviour
{
    // Use this for initialization
    ShooterPatroler cc;

    void Start()
    {
        cc = GetComponent<ShooterPatroler>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((cc.isGround == true && cc._body.velocity.x > 0.5f && GetComponent<AudioSource>().isPlaying == false) ||
            (cc.isGround == true && cc._body.velocity.x < -0.5f && GetComponent<AudioSource>().isPlaying == false))
        {
            GetComponent<AudioSource>().volume = Random.Range(0.7f, 0.9f);
            GetComponent<AudioSource>().pitch = Random.Range(0.5f, 0.8f);
            GetComponent<AudioSource>().Play();

        }
    }
}
