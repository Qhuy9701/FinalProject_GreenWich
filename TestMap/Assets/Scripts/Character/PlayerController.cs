using System.Dynamic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxSpeed;
    public int jumpHeight;
    bool facingRight;
    bool grounded;

    Rigidbody2D myBody;
    Animator myAim;

    //khai bao bien de ban
    public Transform gunTip;
    public GameObject bullet;
    float fireRate = 0.5f;
    float nextFire = 0;

    private void Start()
    {
        myBody = GetComponent<Rigidbody2D>();

        myAim = GetComponent<Animator>();

        facingRight = true;
    }

    private void FixedUpdate()
    {
   
        //create move character 
        float move = Input.GetAxis("Horizontal");
        myBody.velocity = new Vector2(move * maxSpeed, myBody.velocity.y);
        //debug log number
        //create flip character
        
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }

    

        //create jump character
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            myBody.AddForce(new Vector2(0, jumpHeight));
           
        }
        
       
        if(Input.GetKey(KeyCode.UpArrow))
        {
            if(grounded)
            {
                grounded = false;
                myBody.velocity = new Vector2(myBody.velocity.x, jumpHeight);
                myAim.SetInteger("Status", 2);
            }              
        }            
        else if (Input.GetKey(KeyCode.Space))
        {
            fireBullet();    
            myAim.SetInteger("Status", 3);    
        }
        else
        {
            myAim.SetInteger("Status", 0);
        }
       

        //user clicks 2 space buttons that uparrow at the same time, set state = 3
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.UpArrow))
        {
            fireBullet(); 
            myAim.SetInteger("Status", 3);
        }

        //set status character
        myAim.SetFloat("Speed", Mathf.Abs(move));     
         
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="Groud")
        {
            grounded = true;
            myAim.SetInteger("Status", 0);
        }
        else if(other.gameObject.tag=="Wood")
        {
            grounded = true;
            myAim.SetInteger("Status", 0);
        }
    } 
    
    void fireBullet()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                
            }
            else
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
                    
        }
    }     

    //The character will flash if it collides with an obstacle.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Shootable")
        {
            StartCoroutine(Flash());            
        }
    }

    IEnumerator Flash()
    {
        for (int i = 0; i < 3; i++)
        {
            GetComponent<Renderer>().enabled = false;
            yield return new WaitForSeconds(0.1f);
            GetComponent<Renderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
    }

    //character can move through rock_1
    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag=="Rock_1")
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
    
   
}
