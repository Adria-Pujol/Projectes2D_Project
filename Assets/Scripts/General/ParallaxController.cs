using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    private float startpos;
    public GameObject cam;
    public float parallaxEffect;

    private void Awake()
    {
        startpos = transform.position.x;
        
    }

    private void FixedUpdate()
    {
        float dis = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startpos + dis, transform.position.y, transform.position.z);
    }
}
