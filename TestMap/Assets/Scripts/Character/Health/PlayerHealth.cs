using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxhealth;
    public float currentHealth;
    public Slider playerHealthSlider;
   
 
    // Start is called before the first frame update
    void Start()
    {
        Health();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Health(){
        currentHealth = maxhealth;
        playerHealthSlider.maxValue = maxhealth;
        playerHealthSlider.value = maxhealth;
        
    }

    public void TakeDamage(float damage)
    {      
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
        }
        playerHealthSlider.value = currentHealth;      
    }

    public void AddHealth(float healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth > maxhealth)
        {
            currentHealth = maxhealth;
        }
        playerHealthSlider.value = currentHealth;
    } 
}
