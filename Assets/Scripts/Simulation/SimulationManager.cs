using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    [SerializeField]
    private UnitCollection allUnits;

    [SerializeField]
    private Guild playerGuild;

    [SerializeField]
    private UnitRoster inPartyRoster;

    [SerializeField]
    private RecruitmentShopRosters shopRosters;

    [SerializeField]
    private UnitRoster freeAgentRoster;

    [SerializeField]
    private QuestCollection activeQuests;

    [SerializeField]
    private TimedEventCollection timedEvents;

    [SerializeField]
    private FloatVariable currentTime;

    [SerializeField]
    private YearlyEventQueue yearlyEventQueue;

    public UnitSimulator UnitSimulator { get; } = new UnitSimulator();

    public QuestSimulator QuestSimulator { get; } = new QuestSimulator();

    public TimedEventHandler TimedEventHandler { get; } = new TimedEventHandler();

    private YearlyEventSimulator YearlyEventSimulator = new YearlyEventSimulator();

    private UnitEventSimulator UnitEventSimulator = new UnitEventSimulator();
    
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
        this.UnitSimulator.UpdateUnits(allUnits, playerGuild, currentTime.Value, freeAgentRoster);
        this.QuestSimulator.UpdateQuests(activeQuests.Quests);
        shopRosters.CheckHasUpdated();
        this.TimedEventHandler.UpdateTimedEvents(timedEvents.timedEvents);
        this.YearlyEventSimulator.UpdateYearlyEvents(yearlyEventQueue, currentTime.Value);
        this.UnitEventSimulator.UpdateUnitEvents(freeAgentRoster, playerGuild, inPartyRoster, allUnits);
    }
}
