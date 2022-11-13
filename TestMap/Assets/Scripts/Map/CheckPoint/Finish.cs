using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private bool levelComplete = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player"&& !levelComplete)
        {
            levelComplete = true;
            Invoke("CompleteLevel", 2f);
        }
    }   

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
