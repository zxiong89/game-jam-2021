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

    public UnitSimulator UnitSimulator { get; } = new UnitSimulator();

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
        this.UnitSimulator.UpdateUnits(allUnits.Units);
        //Update Quests
    }
}
