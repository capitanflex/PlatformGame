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
   
    void Update()
    {   
        if(GetComponent<FireGun>().CanFire == true)
        { 
            BulletStatus.text = "Urine supply: " + GetComponent<FireGun>().ReloadMocha;
        }
        else
        {
            BulletStatus.text = "Reload...";
        }

    void OpenInvertory()
    {
        if (CheckInvertory == false && Input.GetKeyDown("E"))
        {
            Invertory.SetActive(true);
            CheckInvertory = true;
        }
    }

    void CloseInvertory()
    {
        if (CheckInvertory != false  && Input.GetKeyDown("E"))
        {
            Invertory.SetActive(false);
            CheckInvertory = false;
        }
    }
}
}
