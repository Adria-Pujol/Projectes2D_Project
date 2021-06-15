using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps_boss : MonoBehaviour
{
    // Use this for initialization
    BossAI cc;

    void Start()
    {
        cc = GetComponent<BossAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((cc._isGround == true && cc._body.velocity.x > 0.5f && GetComponent<AudioSource>().isPlaying == false) ||
            (cc._isGround == true && cc._body.velocity.x < -0.5f && GetComponent<AudioSource>().isPlaying == false))
        {
            GetComponent<AudioSource>().volume = Random.Range(0.8f, 1);
            GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.1f);
            GetComponent<AudioSource>().Play();

        }
    }
}
