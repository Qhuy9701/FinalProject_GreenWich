using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomController : MonoBehaviour
{
    public float boomSpeedHight;
    public float boomSpeedLow;
    public float boomAgle;
    Rigidbody2D cannonRB;


     void Awake()
    {
         cannonRB = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
       cannonRB.AddForce (new Vector2(Random.Range(-boomAgle,boomAgle), Random.Range(boomSpeedLow,boomSpeedHight)),ForceMode2D.Impulse) ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
