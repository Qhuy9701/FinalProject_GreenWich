﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{

    public float aliveTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, aliveTime);
               
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //tag = ground destroy object 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
