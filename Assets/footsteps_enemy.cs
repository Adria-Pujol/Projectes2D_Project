using UnityEngine;
using System.Collections;
using Enemies;

public class footsteps_enemy : MonoBehaviour
{

    // Use this for initialization
    PatrolEnemy cc;

    void Start()
    {
        cc = GetComponent<PatrolEnemy>();
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
