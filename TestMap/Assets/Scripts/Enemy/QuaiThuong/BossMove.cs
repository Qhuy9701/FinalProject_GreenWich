using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    public float enemySpeed;

    Rigidbody2D rb;

    Animator enemyAim;

    public  GameObject enemyGraphic;

    bool facingRight = true;
    public float facingTime = 1f;
    float nextFlip = 0f;
    bool canFlip = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyAim = GetComponentInChildren<Animator>();
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
            rb.velocity = new Vector2(enemySpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-enemySpeed, rb.velocity.y);
        }       
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyAim = GetComponentInChildren<Animator>();
    }

    void flip(){
        if(!canFlip)      
        return;       
        facingRight = !facingRight;
        //checknull
        if (enemyGraphic != null)
        {
            Vector3 theScale = enemyGraphic.transform.localScale;
            theScale.x *= -1;
            enemyGraphic.transform.localScale = theScale;
        }  
    }  
    //if tag = player move to player position
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //trigger attack
            enemyAim.SetTrigger("Attack");
        }
    }
}
