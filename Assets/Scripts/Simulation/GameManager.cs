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

    [SerializeField]
    private IntegerVariable questScoutingTier;

    [SerializeField]
    private YearlyEventQueue yearlyEventQueue;
    
    [SerializeField]
    private IntegerVariable unitScoutingTier;

    public void SaveGame()
    {
        if (string.IsNullOrEmpty(filename.Value)) filename.Value = GenericStrings.DefaultFilename;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(GetFilePath(filename.Value));
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
        questScoutingTier.Value = 1;
        yearlyEventQueue.Reset();
        unitScoutingTier.Value = 1;
        UnitCollection.ActiveUnits.Clear();
        ContractCollection.ActiveContracts.Clear();
    }

    private void loadGame(string filename)
    {
        BinaryFormatter bf = new BinaryFormatter();
        var filepath = GetFilePath(filename);
        FileStream file = File.Open(filepath, FileMode.Open);
        GameSave save = (GameSave) bf.Deserialize(file);
        unpack(save);
    }

    private void unpack(GameSave save)
    {
        unitRosterManager.GuildRoster = save.UnitRosterManager.GuildRoster;
        unitRosterManager.InPartyRoster = save.UnitRosterManager.InPartyRoster;
        shopRosters.SetRosters(save.ShopRosters);
        activeQuests.Quests = save.ActiveQuests.Quests;
        // TODO activeParties.parties = save.ActiveParties.parties;
        currentTime.Value = save.CurrentTime;
        playerGold.Value = save.PlayerGold;
        // TODO yearlyEventQueue
    }

    public static string GetFilePath(string filename) =>
        Path.Combine(Application.persistentDataPath, filename);
}
