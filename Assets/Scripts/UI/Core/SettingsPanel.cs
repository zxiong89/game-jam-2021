using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsPanel : MonoBehaviour
{
    public void SaveGame()
    {

    }

    public void SaveAndExit()
    {
        SaveGame();
        ExitGame();
    }


    public void ExitGame()
    {
        Application.Quit();
    }

    public void SwitchToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
