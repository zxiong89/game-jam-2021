using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitSimulator
{
    /// <summary>
    /// Time since last simulator update
    /// </summary>
    private float timeElapsed;


    public void UpdateUnits(List<Unit> activeUnits)
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed >= 20)
        {
            for (int i = activeUnits.Count - 1; i >= 0; i--)
            {
                UpdateUnit(activeUnits[i]);
                if (activeUnits[i].IsRetired) activeUnits.RemoveAt(i);
            }
            timeElapsed -= 20;
        }
    }

    private void UpdateUnit(Unit curUnit)
    {
        UpdateAge(curUnit);
        if (CheckRetired(curUnit)) return;
        UpdateLevel(curUnit);
        
    }

    private void UpdateAge(Unit curUnit)
    {
        curUnit.Age++;
    }

    private bool CheckRetired(Unit curUnit)
    {
        float rand = UnityEngine.Random.Range(0f, 1f);

        if (rand < CalcChanceToRetire(curUnit.Age))
        {
            curUnit.Retire();
            return true;
        }

        return false;
    }

    private float CalcChanceToRetire(int age)
    {
        return ((float)Math.Tanh(((double)age / 15) - 5) + 1) / 2f;
    }

    private void UpdateLevel(Unit unit)
    {
        float expToLevel = unit.ExperienceToLevel;
        int expGained = Mathf.FloorToInt(FloatExtensions.Randomize(.3f * expToLevel, 1.1f * expToLevel, .7f * expToLevel));
        unit.Experience += expGained;
    }
}
