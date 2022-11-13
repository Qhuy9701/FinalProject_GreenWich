using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobinShoot : MonoBehaviour
{
    public GameObject theBoom;
    public Transform shootForm;
    public float shootTime;
    float nextShoot = 0f;

    Animator cannonAim ;

    void Awake()
    {
      cannonAim = GetComponentInChildren<Animator>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Time.time > nextShoot)
            {
                nextShoot = Time.time + shootTime;
                Instantiate(theBoom, shootForm.position, shootForm.rotation);
                cannonAim.SetTrigger("Shoot");
            }
        }
    }
}
