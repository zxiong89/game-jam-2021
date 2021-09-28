using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitSimulator
{
    /// <summary>
    /// Time since last simulator update
    /// </summary>
    private float timeElapsed;

    public void UpdateUnits(UnitCollection activeUnits, Guild playerGuild, float currentTime, UnitRoster freeAgentRoster)
    {
        while(activeUnits.Units.Peek()?.UpdateTime <= currentTime)
        {
            Unit curUnit = activeUnits.Units.GetNextAndRepeat();
            UpdateUnit(curUnit, freeAgentRoster,activeUnits);
        }

        timeElapsed += Time.deltaTime;

        if(timeElapsed >= SimulationConstants.SECONDS_PER_YEAR)
        {
            PayWages(playerGuild);
            timeElapsed -= SimulationConstants.SECONDS_PER_YEAR;
        }
    }

    private void PayWages(Guild playerGuild)
    {
        int totalWages = 0;
        foreach (var unit in playerGuild.Roster)
        {
            totalWages += PayWages(unit);
        }
        if (totalWages > 0)
        {
            playerGuild.Gold -= totalWages;
            EventLog.AddMessage("Paid " + totalWages.ToString() + " G in wages to guild members.");
        }
    }

    private int PayWages(Unit curUnit)
    {
        int amountToPay;
        if(!curUnit.IsApprentice() && curUnit.IsInPlayerGuild() && curUnit.Contract != null)
        {
            amountToPay = curUnit.Contract.GoldPerMonth;
        }
        else
        {
            amountToPay = 0;
        }
        return amountToPay;
    }

    private void UpdateUnit(Unit curUnit, UnitRoster freeAgentRoster, UnitCollection activeUnits)
    {
        UpdateAge(curUnit);
        if (CheckRetired(curUnit, activeUnits)) return;
        UpdateLevel(curUnit);
        UpdateRecruitmentInfo(curUnit, freeAgentRoster);
    }

    private void UpdateAge(Unit curUnit)
    {
        curUnit.Age++;
    }

    private bool CheckRetired(Unit curUnit, UnitCollection activeUnits)
    {
        float rand = UnityEngine.Random.Range(0f, 1f);

        if (rand < CalcChanceToRetire(curUnit.Age))
        {

            if (curUnit.IsInPlayerGuild())
            {
                var args = new PopupEventArgs()
                {
                    Text = curUnit.DisplayName + " has retired.",
                    PausesTime = true
                };
                PopupMessage.ShowPopup(args);
                EventLog.AddMessage(curUnit.DisplayName + " has retired.", false);
            }
            curUnit.Retire();
            activeUnits.Units.Remove(curUnit);
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

    private void UpdateRecruitmentInfo(Unit unit, UnitRoster freeAgentRoster)
    {
        if (unit.IsInPlayerGuild())
        {
            if (UnityEngine.Random.Range(0, 10) != 0) return;
            unit.RecruitmentData.UpdateFee(unit, true);
            PopupMessage.ShowPopup(new PopupEventArgs()
            {
                PausesTime = true,
                Text = unit.DisplayName + " is requesting a raise to " + unit.RecruitmentData.Wage + "G.",
                AcceptTextOverride = "Give raise",
                AcceptCallback = (content) => { },
                AcceptButtonSize = new Vector2 (200, 75),
                CloseTextOverride = "Let go",
                CancelCallback = (content) => {
                    freeAgentRoster.Add(unit);
                },
            });
        }
        else if(unit.IsInShop())
        {
            unit.RecruitmentData.UpdateFee(unit, false);
        }
    }
}
