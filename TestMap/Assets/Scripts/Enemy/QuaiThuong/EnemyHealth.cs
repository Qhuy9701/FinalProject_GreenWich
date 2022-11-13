using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public float maxhealth;
    float currentHealth;
    public GameObject enemyHealthEF;
    public Slider enemyhealthSlider;
    public bool drop;

    public GameObject theDrop;

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

    public void TakeDamage(float dame)
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
        gameObject.SetActive(false);
        Instantiate(enemyHealthEF, transform.position, transform.rotation);
        {
            Instantiate(theDrop, transform.position, transform.rotation);
        }
    }
}
