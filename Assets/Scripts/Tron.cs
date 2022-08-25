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
    public SpriteRenderer ChangeTron;

    public Animator anim;
    private void Awake()
    {
        
        ChangeTron = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }


    void Update()
    {
       if (HealthTron <= 5)
       {
           anim.SetBool("isBroken", true);
       }
       if (HealthTron <= 3)
       {
           anim.SetBool("isBroken2", true);
           anim.SetBool("isBroken", false);
       }
     
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Enemy")
        {
            
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
