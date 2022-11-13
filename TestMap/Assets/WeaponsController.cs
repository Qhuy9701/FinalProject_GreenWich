using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsController : MonoBehaviour
{
    public float weponsSpeedHight;
    public float weponsSpeedLow;
    public float weponsAngle;

    Rigidbody2D wsrb;

    private void Awake()
    {
        wsrb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        wsrb.AddForce(new Vector2(Random.Range(-weponsAngle, weponsAngle), Random.Range(weponsSpeedLow, weponsSpeedHight)), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
