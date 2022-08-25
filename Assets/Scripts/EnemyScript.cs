using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody2D rb;
    
    void Update()
    {
        rb.velocity = Vector2.left;
    }
}
