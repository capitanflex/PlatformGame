using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class FireGun : MonoBehaviour
{
    public GameObject Mocha;
    public int ReloadMocha = 100;
    public Transform SpawnPoint;
    private bool CanFire = true;
    public Text BulletStatus;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        
        if (Input.GetKey(KeyCode.Mouse0) && ReloadMocha > 0 && CanFire)
        {
            Instantiate(Mocha, SpawnPoint.position, transform.rotation);
            ReloadMocha -= 1;
            
        }
        
        
        
        if (Input.GetKey(KeyCode.R))
        {
            
            StartCoroutine(Reload());
            
        }
        
    
         BulletStatus.text = "Запас саки:"  + ReloadMocha;
    }

    IEnumerator Reload()
    {
            
            CanFire = false;
            
            yield return new WaitForSeconds(2f);
            ReloadMocha = 100;
            CanFire = true;
            

    }
    

}
