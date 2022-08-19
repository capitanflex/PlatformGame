using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tron : MonoBehaviour
{
    public GameObject ObjTron;
    public int HealthTron= 10;
    private SpriteRenderer ChangeTron;
    public Sprite BrokenTron0;
    public Sprite BrokenTron1;
    private void Awake()
    {
        Instantiate(ObjTron, new Vector3(26, -2.3f,0), quaternion.Euler(0,0,0));
        ChangeTron = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }


    void Update()
    {
       if (HealthTron <= 5)
       {
           
       }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "enemy")
        {
            HealthTron -= 1; 
        }
    }

    public void SceneDefeat(int SceneID)
    {
        if (HealthTron <= 0)
        {
            SceneManager.LoadScene(SceneID);
        }
    }
}
