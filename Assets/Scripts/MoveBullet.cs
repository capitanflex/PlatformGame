using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public Rigidbody2D Mocha;
    void Start()
    {
        Mocha.AddForce(transform.right * 75);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(Mocha);
        
    }
}
