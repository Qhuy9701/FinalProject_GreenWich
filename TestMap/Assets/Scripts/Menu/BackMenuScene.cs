using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMenuScene : MonoBehaviour
{
    //back menuscene
    public void BackToMenuScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }
}
