using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public Rigidbody2D Mocha;
    void Update()
    {
        Mocha.AddForce(transform.right * 20);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(Mocha);
    }
}
