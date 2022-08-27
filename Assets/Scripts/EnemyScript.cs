using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody2D Enemy;
    public int a;
    public float speed;
    public SpriteRenderer SpriteRenderer;
    public Transform target;//Первая переменная хуйня
    private bool targetSearched = false; 
    private Collider2D searchcircle;
    public Animator anim;
    public bool OnLeft;
    public RaycastHit2D CheckBarrier1;
    public LayerMask Ground;
    
    void Start()
    {
        StartCoroutine(DefaultMove());
    }

    private void Update()
    {
        
        if (!targetSearched)
        {
            if (a == 1)
            {
                Enemy.velocity = Vector2.left * speed;
                SpriteRenderer.flipX = false;
                anim.SetBool("Go", true);
                CheckBarrier1 = Physics2D.Raycast(transform.position, Vector3.left, Ground);
                Debug.DrawRay(transform.position, Vector3.left, Color.blue);
            }

            if (a == 2)
            {
                SpriteRenderer.flipX = true;
                Enemy.velocity = Vector2.right * speed;
                anim.SetBool("Go", true);
                CheckBarrier1 = Physics2D.Raycast(transform.position, Vector3.right, Ground);
                Debug.DrawRay(transform.position, Vector3.right, Color.blue);
            }

            if (a == 0)
            {

                Enemy.velocity = Vector2.left * 0;
                anim.SetBool("Go", false);
                anim.SetBool("Stop", true);
            }

            
        }
        
        if (targetSearched)
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
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Hero")
        {
            targetSearched = false;
        }
    }

    IEnumerator DefaultMove()
    { 
        while(true)
        {
            for(int j =0; j <1; j++)
            {
                for (int i = 0; i < 2; i++)
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
