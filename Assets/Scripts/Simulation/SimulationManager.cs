﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    [SerializeField]
    private UnitCollection allUnits;

    public UnitSimulator UnitSimulator { get; } = new UnitSimulator();

    public void Resume()
    {
        Time.fixedDeltaTime = .5f;
    }

    public void Pause()
    {
        Time.fixedDeltaTime = 0;
    }

    private void FixedUpdate()
    {
        this.UnitSimulator.UpdateUnits(allUnits.Units);
        //Update Quests
    }
}