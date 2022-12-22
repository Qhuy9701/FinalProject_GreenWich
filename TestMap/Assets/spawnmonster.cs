using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmonster : MonoBehaviour
{
    [SerializeField] private GameObject monster;
    [SerializeField] private Transform spawnpoint;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         //if monster destroy = count--;
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       
        if(other.tag =="Player")
        {  
            Instantiate(monster, spawnpoint.position, Quaternion.identity);
        }
    }
}
