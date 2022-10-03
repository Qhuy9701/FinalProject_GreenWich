using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallHit : MonoBehaviour
{
    public float FireBalldamage;
    ProjectTileController myPc;

    void Awake()
    {
        myPc = GetComponent<ProjectTileController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Shootable")
        {
            myPc.removeForce();          
            Destroy(gameObject);
            if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
               EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
               hurtEnemy.addDamege(FireBalldamage);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Shootable")
        {
            myPc.removeForce();
            Destroy(gameObject);
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
            //check null
            if (hurtEnemy != null)
            {
                hurtEnemy.addDamege(FireBalldamage);
            }
                
        }
    }
}
