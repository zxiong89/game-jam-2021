﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFactory : MonoBehaviour
{
    #region Growth Limits
    [SerializeField]
    GrowthFactorLimits growthLimits;

    [SerializeField]
    IntegerLimits ageLimits;
    #endregion

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    public Unit RandomizeUnit()
    {
        int age = Random.Range(ageLimits.Min, ageLimits.Max);
        int level = Random.Range(1, age);
        var stats = new StatBlock(level, growthLimits);
        return new Unit(level, age, stats);
    }
}
