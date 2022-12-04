using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RsMonster : MonoBehaviour
{
   //if monster and player are null then respawn monster.
    public GameObject monster;
    public GameObject respawnPoint;
    
    void Start()
    {
        monster = GameObject.Find("Monster");
        respawnPoint = GameObject.Find("RespawnPoint");
    }

    void Update()
    {
       //if monster and player are null then respawn monster.
        if (monster == null)
        {
            Instantiate(monster, respawnPoint.transform.position, Quaternion.identity);
        }
    }
}
