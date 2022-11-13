using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPickUp : MonoBehaviour
{
    // Start is called before the first frame update
    public  int manaAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMana thePlayerMana = other.gameObject.GetComponent<PlayerMana>();
            thePlayerMana.addMana(manaAmount);
            Destroy(gameObject);
        }
    }
    
    //roll with y 
    void Update()
    {
        transform.Rotate(new Vector3(0, 180, 0) * Time.deltaTime);
    }
}
