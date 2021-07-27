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

    [SerializeField]
    private TimedEventCollection timedEvents;

    public UnitSimulator UnitSimulator { get; } = new UnitSimulator();

    public QuestSimulator QuestSimulator { get; } = new QuestSimulator();

    public TimedEventHandler TimedEventHandler { get; } = new TimedEventHandler();

    private float setSpeed = 1;

    private float activePauses = 0;

    //Might want to move initialization elsewhere, but doing it here for now for convenience
    private void Start()
    {
        playerGuild.Initialize();
        shopRosters.Initialize();
    }

    public void PlayAtSpeed(float speed)
    {
        setSpeed = speed;
        Time.timeScale = speed;
    }

    public void Resume()
    {
        activePauses--;
        if(activePauses == 0)
        {
            Time.timeScale = setSpeed;
        }
        else if (activePauses < 0)
        {
            throw new System.Exception("Tried to resume simulation too many times. Check for unpaired Pause/Resume");
        }
    }

    public void Pause()
    {
        if(activePauses == 0)
        { 
            Time.timeScale = 0;
        }
        activePauses++;
    }

    private void FixedUpdate()
    {
        this.UnitSimulator.UpdateUnits(allUnits.Units, playerGuild);
        this.QuestSimulator.UpdateQuests(activeQuests.Quests);
        shopRosters.CheckHasUpdated();
        this.TimedEventHandler.UpdateTimedEvents(timedEvents.timedEvents);
    }
}
