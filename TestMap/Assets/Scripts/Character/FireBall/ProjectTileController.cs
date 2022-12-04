using System.Dynamic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTileController : MonoBehaviour
{
    public float fireBallSpeed;
    Rigidbody2D myBody;
    Animator anim;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        if(transform.localRotation.z>0)
        {
            myBody.AddForce(new Vector2(-1 , 0) * fireBallSpeed , ForceMode2D.Impulse);
        }
        else
        {
            myBody.AddForce(new Vector2(1 , 0) * fireBallSpeed , ForceMode2D.Impulse);
          
        }
    }
  
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void removeForce(){
        //check null
        if (myBody != null)
        {
            myBody.velocity = new Vector2(0, 0);
            //null check
            if (anim != null)
            {
               anim.SetTrigger("Explosion");
            }
            
        }
        
    }
}
