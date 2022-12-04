    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    public GameObject theBoom;
    public Transform shootForm;
    public float shootTime;
    float nextShoot = 0f;

    void Awake()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag =="Player" && Time.time>nextShoot)
        {
            nextShoot = Time.time + shootTime;
            Instantiate(theBoom, shootForm.position,Quaternion.identity);
        }
        
    }
}
