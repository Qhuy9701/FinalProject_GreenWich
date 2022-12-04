using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScripts : MonoBehaviour
{
    public void Pass()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if(currentLevel > PlayerPrefs.GetInt("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", currentLevel + 1);
        }
        //debug
        Debug.Log("Current Level: " + currentLevel);
        //debug unlck level
        Debug.Log("Unlocked Level: " + PlayerPrefs.GetInt("levelsUnlocked"));
    }

    //ontriggerenter2d = player pass
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Pass();
        }
    }
}
