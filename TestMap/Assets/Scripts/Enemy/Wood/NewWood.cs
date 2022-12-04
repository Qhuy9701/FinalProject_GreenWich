using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWood : MonoBehaviour
{
    public GameObject theWood;
    public Transform spawnPoint;

    void Awake()
    {
       
    }

    void Update()
    {
       //if the wood = null create new wood in spawn point 
        if(theWood == null)
        {
            Instantiate(theWood, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
