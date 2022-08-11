using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{


  public float offset;
  private Vector2 mousPos;
  public Rigidbody2D _rigidbody2D;
  public Camera cam;
  private Transform spriteTransform;
  public SpriteRenderer _spriteRenderer;
  private HingeJoint2D HingeJoint2D;

  private bool isFliped = false;
  
  
  
  private void Awake()
  {
    spriteTransform = GetComponentInChildren<Transform>();
    HingeJoint2D = GetComponent<HingeJoint2D>();
    // _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
  }


  private void Update()
  {
    mousPos = cam.ScreenToWorldPoint(Input.mousePosition);
    
    
    // float rotZ = Mathf.Atan2(difference.y, difference.z) * Mathf.Rad2Deg;
    // transform.rotation = Quaternion.Euler(0f, 0f,rotZ + offset);
  }

  private void FixedUpdate()
  {
    Vector2 lookDir = mousPos - _rigidbody2D.position;
    float angle = Mathf.Atan2(lookDir.y, lookDir.x)* Mathf.Rad2Deg - offset;
    _rigidbody2D.rotation = angle;
  }

  public void FlipSprite(Vector3 dir)
  {
    if (dir.x < 0.00f && !isFliped)
    {
      _spriteRenderer.flipY = dir.x < 0.00f;
      spriteTransform.position += new Vector3(0.2f, 0.35f, 0);
      isFliped = true;
      // HingeJoint2D.anchor += new Vector2(0, 0.2f);
    }
    if (dir.x > 0.00f && isFliped)
    {
      _spriteRenderer.flipY = false;
      spriteTransform.position -= new Vector3(0.2f, 0.35f, 0);
      isFliped = false;
      // HingeJoint2D.anchor -= new Vector2(0, 0.2f);
    }

  }
}
