using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class OpenScene : MonoBehaviour
{
    public GameObject Shop;
    private bool CheckShop = false;
    public GameObject Menu;
    private bool CheckWheelchair;
    private bool CheckBed;
    public Button WheelchairSprite;
    public Button Bed;

    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
    
    private void Awake()
    {
        Menu.SetActive(true);
        Shop.SetActive(false);
    }
    
    public void OpenShop()
    {
        if (CheckShop == false)
        {
            Shop.SetActive(true);
            CheckShop = true;
            Menu.SetActive(false);
        }
    }
    public void CloseShop()
    {
        if (CheckShop == true)
        {
            Shop.SetActive(false);
            CheckShop = false;
            Menu.SetActive(true);
        }
    }
}
