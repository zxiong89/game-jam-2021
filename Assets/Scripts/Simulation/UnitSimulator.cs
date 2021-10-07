using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitSimulator
{
    /// <summary>
    /// Time since last simulator update
    /// </summary>
    private float timeElapsed;

    public void UpdateUnits(Guild playerGuild, float currentTime, UnitRoster freeAgentRoster)
    {
        while(UnitCollection.ActiveUnits.Peek()?.UpdateTime <= currentTime)
        {
            Unit curUnit = UnitCollection.ActiveUnits.GetNextAndRepeat(SimulationConstants.SECONDS_PER_YEAR).Unit;
            UpdateUnit(curUnit, freeAgentRoster);
        }

        while (ContractCollection.ActiveContracts.Peek()?.UpdateTime <= currentTime)
        {
            Unit unit = ContractCollection.ActiveContracts.GetNext().Unit;
            UpdateContract(unit, freeAgentRoster);
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

    private void UpdateUnit(Unit curUnit, UnitRoster freeAgentRoster)
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

    private void UpdateContract(Unit unit, UnitRoster freeAgentRoster)
    {
        unit.EndContract();
        freeAgentRoster.Add(unit);
        PopupMessage.ShowPopup(new PopupEventArgs()
        {
            Text = "The contract for " + unit.DisplayName + " has ended.",
            AcceptTextOverride = "Renegotiate",
            AcceptButtonSize = new Vector2(220,75),
            AcceptCallback = (popup) =>
            {
                PopupMessage.ShowPopup(new PopupEventArgs()
                {
                    Text = "Add hiring workflow here!"
                });
            },
            CloseTextOverride = "End"
        });
    }
}
