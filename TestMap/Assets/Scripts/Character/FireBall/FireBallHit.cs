using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallHit : MonoBehaviour
{
    public float FireBalldamage;
    ProjectTileController myPc;
    Animator anim;

    void Awake()
    {
        myPc = GetComponent<ProjectTileController>();
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Shootable")
        {   
            //check null
            if (myPc != null)
            {
                myPc.removeForce();
            }  
            Destroy(gameObject,1f);
            if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                //check null
               EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
               hurtEnemy.TakeDamage(FireBalldamage);
            }
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Shootable")
        {
            if (myPc != null)
            {
                myPc.removeForce();
            }
            Destroy(gameObject,1f);
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
            //check null
            if (hurtEnemy != null)
            {
                hurtEnemy.TakeDamage(FireBalldamage);
            }
                
        }
    }
}
