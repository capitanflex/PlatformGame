using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    
    public float speed = 5f;
    
    public float jumpforce = 1f;
    

    private bool isGrounded = false;
    private bool ternOnLeft = false;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    public GameObject farting;
    private Animator anim;
    public GunScript GunScript;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();

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
        if (Input.GetKey("space") && isGrounded)
            Jump();
        //переж только в воздухе
        if (isGrounded)
            farting.gameObject.SetActive(false);
        else
            farting.gameObject.SetActive(true);
        //сторона пердежа
        if (ternOnLeft)
            farting.transform.eulerAngles = new Vector3(45,90,0);
        else

            farting.transform.eulerAngles = new Vector3(145,90,0);
        
        
    }

    private void Run()
    {
        float a = Input.GetAxis("Horizontal");
        Vector3 dir = transform.right * a;
        if (a < 0)//чтобы контролировать в какую сторону пердеж
        {
            ternOnLeft = true;
        }
        else
            ternOnLeft = false;
        

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        sprite.flipX = dir.x < 0.00f;
        GunScript.FlipSprite(dir);
        
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpforce);
        
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.25f);
        isGrounded = collider.Length >= 1;
        
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
