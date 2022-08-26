using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public int a;
    public float speed;
    public SpriteRenderer SpriteRenderer;
    public Transform target;//Первая переменная хуйня
    private bool targetSearched = false; 
    private Collider2D searchcircle;
    public Animator anim;
    
    
    void Start()
    {
        StartCoroutine(DefaultMove());
    }

    private void Update()
    {
        if(!targetSearched)
        {
            if (a == 1)
            {
                rb.velocity = Vector2.left * speed;
                SpriteRenderer.flipX = false;
                anim.SetBool("Go", true);
            }

            if (a == 2)
            {
                SpriteRenderer.flipX = true;
                rb.velocity = Vector2.right * speed;
                anim.SetBool("Go", true);
            }
            if (a == 0)
            {
                
                rb.velocity = Vector2.left * 0;
                anim.SetBool("Go", false);
                anim.SetBool("Stop", true);
            }
            Debug.Log(targetSearched);
            
        }
        if(targetSearched)
        {
            
            //target.position = transform.position + transform.right;
            transform.position = Vector2.MoveTowards(transform.position, target.position, 0.03f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hero")
        {
            targetSearched = true;
        }
    }

    IEnumerator DefaultMove()
    { 
        while(true)
        {
            for(int j =0; j <1; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    a = 1;
                    yield return new WaitForSeconds(2f);
                    a = 2;
                    yield return new WaitForSeconds(2f);
                }

                a = 0;
                yield return new WaitForSeconds(3f);
            }
        }

    }

}
