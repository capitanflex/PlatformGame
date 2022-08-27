using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class MovePlayer : MonoBehaviour
{
    
    public float speed = 5f;
    
    public float jumpforce = 1f;
    

    
    private bool isGrounded = false;
    private bool ternOnLeft = false;

    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    public GameObject farting;
    private Animator anim;
    public GunScript GunScript;
    public Transform PlayerPoint;
    public LayerMask Ground;
    
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        gameObject.transform.position = new Vector3(-19.3099995f,-3.47000003f,-1);

    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            Run();
            State = States.Run;
        }
        else
            State = States.Staing;
        if (Input.GetKeyDown("space") && isGrounded)
            Jump();
        //переж только в воздухе
        if (isGrounded)
        {
            farting.gameObject.SetActive(false);
        }
        else
        {
            farting.gameObject.SetActive(true);
        }
        //сторона пердежа
        if (ternOnLeft)
        {
            farting.transform.eulerAngles = new Vector3(45, 90, 0);
        }
        else
        {
            farting.transform.eulerAngles = new Vector3(145,90,0);
        }
        
        
    }

    private float Run()
    {
        float a = Input.GetAxis("Horizontal");
        Vector3 dir = transform.right * a;
        if (a < 0)//чтобы контролировать в какую сторону пердеж
        {
            ternOnLeft = true;           
        }
        else
        {
            ternOnLeft = false;
        }

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        
        sprite.flipX = dir.x < 0.00f;

        return a;
    }
    

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpforce);
        
    }

    private void CheckGround()
    {

        RaycastHit2D RayHit = Physics2D.Raycast(PlayerPoint.position, Vector2.right, Ground);
        if (RayHit.collider != null)
        {
            isGrounded = true;
            Debug.DrawRay(PlayerPoint.position, Vector2.right, Color.green);
        }
        else
        {
            isGrounded = false;
            Debug.DrawRay(PlayerPoint.position, Vector2.right, Color.red);
        }

    }

    IEnumerator JumpTime()
        {
            Jump();
            yield return new WaitForSeconds(2f);
        }

    //аниматор
    public enum States
    {
        Staing,
        Run
    }

    private States State
    {
        get { return (States) anim.GetInteger("State"); }
        set {anim.SetInteger("State", (int)value);}
    }
}
