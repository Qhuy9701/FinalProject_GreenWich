using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float enemySpeed;

    Rigidbody2D rb;
    Animator enemyAim;
    
    // Start is called before the first frame update
    public  GameObject enemyGraphic;
    bool facingRight = true;
    public float facingTime = 1f;
    float nextFlip = 0f;
    bool canFlip = true;

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
            rb.velocity = new Vector2(enemySpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-enemySpeed, rb.velocity.y);
        }       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(facingRight && other.transform.position.x < transform.position.x)
            {
                
                flip();           
            }
            else if(!facingRight && other.transform.position.x > transform.position.x)
            {
                 
                flip();              
            }
            //TRIGGER WALK
           
            canFlip = false;
        }   

       

        //if tag = limit then turn around and move in the opposite direction
        if (other.tag == "Limit")
        {
            flip();
        }  
    }

    //circle collider
    

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(!facingRight)
            {
                rb.AddForce(new Vector2(-1, 0)*enemySpeed);
            }
            else
            {
                rb.AddForce(new Vector2(1, 0)*enemySpeed);
            }
            
            //check null
            if (enemyGraphic != null)
            {
                enemyGraphic.GetComponent<Animator>().SetBool("Run", true);
            }

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canFlip = true;
            rb.velocity = new Vector2(0, 0);
            //check null
            if (enemyGraphic != null)
            {
                enemyGraphic.GetComponent<Animator>().SetBool("Run", false);
            }         
        }
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
    
    //if collide with player set trigger = attack
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //stop and use hit
            rb.velocity = new Vector2(0, 0);
            //check null
            if (enemyGraphic != null)
            {
                enemyGraphic.GetComponent<Animator>().SetTrigger("Attack");
            }
        }
    }
}
