using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFinal : MonoBehaviour
{


    public GameObject theGobin;
    public Transform spawnPoint;
    public float spawnTime;
    float nextSpawn = 0f;

    public GameObject theFireBall;
    public Transform spawnPoint2;
    public float spawnTime2;
    float nextSpawn2 = 0f;

    void Awake()
    {
       
    }

    void Update()
    {
       
    }

     void OnTriggerEnter2D(Collider2D other)
     {
        if (other.tag == "Player" && Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnTime;
            Instantiate(theGobin, spawnPoint.position, spawnPoint.rotation);
            nextSpawn2 = Time.time + spawnTime2;
            Instantiate(theFireBall, spawnPoint2.position, spawnPoint2.rotation);
        }
    }

}
