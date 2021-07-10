using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Runs any initial game setup
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int newGameGold = 6000;

    [SerializeField]
    private Guild guild;

    [SerializeField]
    private UnitRosterManager unitManager;

    [SerializeField]
    private RecruitmentShopRosters shopRosters;

    [SerializeField]
    private QuestCollection activeQuests;

    [SerializeField]
    private PartyCollection activeParties;

    [SerializeField]
    private StringVariable filename;

    [SerializeField]
    private FloatVariable startingTime;

    [SerializeField]
    private IntegerVariable startingGold;

    private void Start()
    {
        if (string.IsNullOrEmpty(filename.Value)) newGame();
        else loadGame(filename.Value);
        SceneManager.LoadScene(2);
    }

    private void newGame()
    {
        unitManager.Clear();
        shopRosters.Reset();
        activeQuests.Clear();
        activeParties.Reset();
        startingTime.Value = 0f;
        startingGold.Value = newGameGold;
    }

    private void loadGame(string filename)
    {

    }
}
