using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuOptions : MonoBehaviour
{
    [SerializeField]
    private StringVariable filename;

    [SerializeField]
    private Button loadButton;

    public void StartNewGame()
    {
        filename.Value = "";
        SceneManager.LoadScene(1);
    }

    public void OpenLoadGame()
    {
        filename.Value = GenericStrings.DefaultFilename;
        SceneManager.LoadScene(1);
    }

    public void ExitGame() => Application.Quit();

    private void Start()
    {
        loadButton.interactable = File.Exists(GameManager.GetFilePath(GenericStrings.DefaultFilename));
    }
}
