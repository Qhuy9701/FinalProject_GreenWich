using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveCung : MonoBehaviour
{
     public float enemySpeed;

    Rigidbody2D rb;
    Animator enemyAim;
    
    bool facingRight = true;
    float facingTime = 2f;
    float nextFlip = 0f;
    bool canFlip = true;
    bool enemyCheck = false;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyAim = GetComponentInChildren<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFlip)
        {
            nextFlip = Time.time + facingTime;
            flip();
        }

        if(facingRight)
        {
            rb.velocity = new Vector2(-enemySpeed, rb.velocity.y);
        }
        else if(!facingRight)
        {
            rb.velocity = new Vector2(enemySpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemySpeed = 0;
        }
    }
   
    void flip(){   
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;    
    }  
}
