using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class LevelManager : MonoBehaviour
{
    int levelsUnlocked;
    [SerializeField] GameObject lockmap2;
    [SerializeField] GameObject lockmap3;

    public Button[] levelButtons;

    void Start()
    {
        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelsUnlocked)
            {
                levelButtons[i].interactable = false;
                lockmap2.SetActive(false);   
                lockmap3.SetActive(false); 
            }
            else
            {
                levelButtons[i].interactable = true;
                lockmap2.SetActive(true);  
                lockmap3.SetActive(true); 
            }
        }

        // for (int i = 0; i < levelsUnlocked; i++)
        // {
        //     if (i + 1 <= levelsUnlocked)
        //     {
        //         levelButtons[i].interactable = true;    
        //         //lock map show
        //         lockmap2.SetActive(true);  
        //         lockmap3.SetActive(true);       
        //     }
        // }
    }
    
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }  
}
