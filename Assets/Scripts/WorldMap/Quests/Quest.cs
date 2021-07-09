using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public const int STARTING_TURNS = 10;
    public const int MAX_RESTING_TURNS = 5;
    public const float HEALING_FACTOR = 0.05f;

    public LocationData LocationData { get; private set; }
    public Party Party { get; private set; }
    private Encounter curEncounter;
    private float partyHp;
    private float maxPartyHp;
    private float goldEarned;

    public Quest(Party party, LocationData location)
    {
        LocationData = location;
        Party = party;
        maxPartyHp = party.CalcTotalDef();
        partyHp = maxPartyHp;
    }

    public void Adventure(int turns = STARTING_TURNS)
    {
        if (curEncounter == null || curEncounter.IsComplete())
        {
            curEncounter = LocationData.SpawnEncounter();
        }

        do
        {
            turns = runAndProcess(turns);
        } while (turns > 0);
    }

    private int runAndProcess(int turns)
    {
        if (partyHp <= 0) return restAndHeal(turns);
        var results = curEncounter.Run(Party, turns);
        if (results.DamageTaken != null) partyHp -= results.DamageTaken.Value;
        if (results.GoldGained != null) goldEarned += results.GoldGained.Value;
        if (results.ExpGained != null) awardExp(results.ExpGained.Value);
        return results.turnsRemaining;
    }

    private void awardExp(float exp)
    {

    }

    private int restAndHeal(int turns)
    {
        int turnsToRest = Math.Min(turns, MAX_RESTING_TURNS);
        partyHp += heal(turns);
        partyHp = Mathf.Max(partyHp, maxPartyHp);
        return turns - turnsToRest;
    }

    private float heal(int turns) => Party.CalcTotalDef() * HEALING_FACTOR * turns;
}
