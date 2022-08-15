using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class OpenScene : MonoBehaviour
{
    public GameObject Shop;
    private bool CheckShop = false;
    public GameObject Menu;
    private bool CheckMenu = true;
    
    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    private void Awake()
    {
        Menu.SetActive(true);
    }

    public void OpenShop()
    {
        if (CheckShop == false)
        {
            Shop.SetActive(true);
            Menu.SetActive(false);
        }
    }
}
