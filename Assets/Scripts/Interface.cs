using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public Text BulletStatus;
    

    

    
    void Update()
    {   
        if(GetComponent<FireGun>().CanFire == true)
        { 
            BulletStatus.text = "Запас саки: " + GetComponent<FireGun>().ReloadMocha;
        }
        else
        {
            BulletStatus.text = "Заряжаем саку...";
        }

        
    }
}
