using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{

    PlayerController cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((cc.isGround == true && cc._movInputCtx > 0.5f && GetComponent<AudioSource>().isPlaying == false ) || 
            (cc.isGround == true &&  cc._movInputCtx < -0.5f && GetComponent<AudioSource>().isPlaying == false))
        {
            GetComponent<AudioSource>().volume = Random.Range(0.8f, 1);
            GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.1f);
            GetComponent<AudioSource>().Play();

        }
    }
}
