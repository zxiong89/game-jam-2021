﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    [SerializeField]
    private UnitCollection allUnits;

    public UnitSimulator UnitSimulator { get; } = new UnitSimulator();

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
