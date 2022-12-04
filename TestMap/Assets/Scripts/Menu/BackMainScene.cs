using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMainScene : MonoBehaviour
{
    public void BackToMainScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }   
}
