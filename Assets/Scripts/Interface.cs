using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public Text BulletStatus;
    public GameObject Invertory;
    public bool CheckInvertory = false;

    void FixedUpdate()
    {
        if (GetComponent<FireGun>().CanFire == true)
        {
            BulletStatus.text = "Urine supply: " + GetComponent<FireGun>().ReloadMocha;
        }
        else
        {
            BulletStatus.text = "Reload...";
        }

        if (CheckInvertory == false)
        {
            OpenInvertory();
        }

        if (CheckInvertory == true)
        {
            CloseInvertory();
        }
        
    }

    void OpenInvertory()
    {
        if (CheckInvertory == false && Input.GetKeyDown(KeyCode.E))
        {
            Invertory.SetActive(true);
            StartCoroutine(Pause());
            
        }
    }

    void CloseInvertory()
    {
        if (CheckInvertory == true  && Input.GetKeyDown(KeyCode.E))
        {
            Invertory.SetActive(false);
            CheckInvertory = false;
            
        }
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(0.1f);
        CheckInvertory = true;
    }

    
}

