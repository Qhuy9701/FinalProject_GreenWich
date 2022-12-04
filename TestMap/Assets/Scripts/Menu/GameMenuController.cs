using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuController : MonoBehaviour
{
    public void PlayGameButton()
    {
        Application.LoadLevel("MainScene");
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }

    public void SettingButton()
    {
        Application.LoadLevel("HowToPlayScene");
    }

    public void PlotButton()
    {
        Application.LoadLevel("PlotScene");
    }
}
