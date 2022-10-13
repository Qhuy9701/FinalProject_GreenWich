using System.Dynamic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    //animation
    private Animator anim;
    //Rigidbody2D
    private Rigidbody2D rb;
    public bool FacingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private  int extraJumps;
    public int extraJumpValue;


    //shoot value
    public Transform gunTip;
    public GameObject bullet;
    float fireRate = 0.5f;
    float nextFire = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);     
        if (move > 0 && !FacingRight)
        {
            Flip();
        }
        else if (move < 0 && FacingRight)
        {
            Flip();
        }

        //create jump character
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce));  
            anim.SetInteger("Status", 2);      
        } 
        //---------------------------------------------------------------------------------//     
        else if(Input.GetKey(KeyCode.Space))
        {
            if(isGrounded)
            {
                isGrounded = false;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                anim.SetInteger("Status", 1);
            }              
        }
        //---------------------------------------------------------------------------------//  
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            if(isGrounded)
            {
                isGrounded = false;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                anim.SetInteger("Status", 1);
            } 
        }
        //---------------------------------------------------------------------------------//    
        else if (Input.GetKey(KeyCode.W))
        {
            fireBullet();
            anim.SetInteger("Status", 3);   
           
        }
        //---------------------------------------------------------------------------------// 
        else if (Input.GetKey(KeyCode.E))
        {
            anim.SetInteger("Status", 4);   
           
        }
        //---------------------------------------------------------------------------------// 
  
        else
        {
           anim.SetInteger("Status", 0);

        }

        anim.SetFloat("Speed", Mathf.Abs(move));
    }

    private void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpValue;
        }
        if(Input.GetKeyDown(KeyCode.Space) && extraJumps >0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
    void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="Groud")
        {
            anim.SetInteger("Status", 0);
        }
        else if(other.gameObject.tag=="Wood")
        {
            anim.SetInteger("Status", 0);
        }
    } 
    
    void fireBullet()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (FacingRight)
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
