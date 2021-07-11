using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    public void SaveGame()
    {
        gameManager.SaveGame();
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
