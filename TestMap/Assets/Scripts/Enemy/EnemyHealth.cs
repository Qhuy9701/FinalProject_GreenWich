using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public float maxhealth;
    float currentHealth;
    public Slider enemyhealthSlider;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxhealth;
        //check null
        if(enemyhealthSlider != null)
        {
            enemyhealthSlider.maxValue = maxhealth;
            enemyhealthSlider.value = maxhealth;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDamege(float dame)
    {
        enemyhealthSlider.gameObject.SetActive(true);
        currentHealth -= dame;

        //check null
        if(enemyhealthSlider != null)
        {
            enemyhealthSlider.value = currentHealth;
        }
        if (currentHealth <= 0)
        {
            makeDead();
        }

    }

    public void makeDead()
    {
        Destroy(gameObject);
       
    }
}
