using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTest : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //IF TAG = PLAYER DESTROY
    void OnTriggerEnter2D(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
