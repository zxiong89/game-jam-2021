using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    [SerializeField]
    private UnitCollection allUnits;

    [SerializeField]
    private Guild playerGuild;

    public UnitSimulator UnitSimulator { get; } = new UnitSimulator();

    private void Start()
    {
        playerGuild.Initialize();
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
