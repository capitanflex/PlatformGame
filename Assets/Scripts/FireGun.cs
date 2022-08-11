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
            Instantiate(Mocha, SpawnPoint.position, Quaternion.Euler(0,0,0));
            ReloadMocha -= 1;
        }

        if (Input.GetKey(KeyCode.R))
        {
            ReloadMocha = 100;
        }
    }
}
