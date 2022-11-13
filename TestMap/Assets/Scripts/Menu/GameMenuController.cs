using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuController : MonoBehaviour
{
    public void PlayGameButton()
    {
        Application.LoadLevel("Map1");
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }

    public void SettingButton()
    {
        Application.LoadLevel("Setting");
    }
}
