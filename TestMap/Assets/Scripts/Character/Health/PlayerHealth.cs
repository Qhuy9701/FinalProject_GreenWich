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
        StartCoroutine(Flash());  
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

    IEnumerator Flash()
    {
        for (int i = 0; i < 3; i++)
        {
            GetComponent<Renderer>().enabled = false;
            yield return new WaitForSeconds(0.1f);
            GetComponent<Renderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
