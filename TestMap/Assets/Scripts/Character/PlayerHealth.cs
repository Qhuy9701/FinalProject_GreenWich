using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxhealth;
    float currentHealth;
    public Slider playerhealthSlider;
    public  GameObject enemyGraphic;
 
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxhealth;
        playerhealthSlider.maxValue = maxhealth;
        playerhealthSlider.value = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamage(float damage)
    {
        if(damage <= 0) return;
        
        currentHealth -= damage;
        
        playerhealthSlider.value = currentHealth;      
        if(currentHealth <= 0)
        {
            makeDead();
            //if the character dies go back to the starting point
            Application.LoadLevel(Application.loadedLevel);
        }
        
    }

    


    public void makeDead()
    {
        Destroy(gameObject);    
    }
    //if the character falls out of the camera then start over
    
}
