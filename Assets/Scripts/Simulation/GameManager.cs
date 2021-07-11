using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
    private UnitRosterManager unitRosterManager;

    [SerializeField]
    private RecruitmentShopRosters shopRosters;

    [SerializeField]
    private QuestCollection activeQuests;

    [SerializeField]
    private PartyCollection activeParties;

    [SerializeField]
    private StringVariable filename;

    [SerializeField]
    private FloatVariable currentTime;

    [SerializeField]
    private IntegerVariable playerGold;

    public void SaveGame()
    {
        if (string.IsNullOrEmpty(filename.Value)) filename.Value = "gamesave.save";
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + filename);
        GameSave save = cacheGameState();
        bf.Serialize(file, save);
    }

    private GameSave cacheGameState()
    {
        return new GameSave()
        {
            UnitRosterManager = unitRosterManager,
            ShopRosters = shopRosters,
            ActiveQuests = activeQuests,
            ActiveParties = activeParties,
            CurrentTime = currentTime.Value,
            PlayerGold = playerGold.Value
        };
    }

    public void StartNewOrLoadGame()
    {
        if (string.IsNullOrEmpty(filename.Value)) newGame();
        else loadGame(filename.Value);
        SceneManager.LoadScene(2);
    }

    private void newGame()
    {
        unitRosterManager.Clear();
        shopRosters.Reset();
        activeQuests.Clear();
        activeParties.Reset();
        currentTime.Value = 0f;
        playerGold.Value = newGameGold;
    }

    private void loadGame(string filename)
    {

    }
}
