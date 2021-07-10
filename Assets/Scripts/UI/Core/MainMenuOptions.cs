using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuOptions : MonoBehaviour
{
    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenLoadGame()
    {

    }

    public void ExitGame() => Application.Quit();
}
