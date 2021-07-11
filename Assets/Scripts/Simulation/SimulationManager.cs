using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    [SerializeField]
    private UnitCollection allUnits;

    [SerializeField]
    private Guild playerGuild;

    [SerializeField]
    private RecruitmentShopRosters shopRosters;

    [SerializeField]
    private QuestCollection activeQuests;

    public UnitSimulator UnitSimulator { get; } = new UnitSimulator();

    public QuestSimulator QuestSimulator { get; } = new QuestSimulator();

    //Might want to move initialization elsewhere, but doing it here for now for convenience
    private void Start()
    {
        playerGuild.Initialize();
        shopRosters.Initialize();
    }

    public void PlayAtSpeed(float speed)
    {
        Time.timeScale = speed;
    }

    private void FixedUpdate()
    {
        this.UnitSimulator.UpdateUnits(allUnits.Units, playerGuild);
        this.QuestSimulator.UpdateQuests(activeQuests.Quests);
        if (shopRosters.CheckHasUpdated()) {
            EventLog.AddMessage("New adventurers are looking for employment!");
        }
    }
}
