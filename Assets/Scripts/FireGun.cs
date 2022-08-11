using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    public GameObject Mocha;
    [SerializeField]private int ReloadMocha = 100;
    public Transform SpawnPoint;
    public void Update()
    {
        if (Input.GetKey(KeyCode.G) && ReloadMocha != 0)
        {
            Instantiate(Mocha, SpawnPoint.position, transform.rotation);
            Instantiate(Mocha, SpawnPoint.position + (Vector3.right * 0.1f), transform.rotation);
            Instantiate(Mocha, SpawnPoint.position + (Vector3.right * -0.1f), transform.rotation);
            ReloadMocha -= 1;
        }

        if (Input.GetKey(KeyCode.R))
        {
            ReloadMocha = 100;
        }
    }
}
