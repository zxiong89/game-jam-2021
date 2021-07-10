using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Quest
{
    public const int STARTING_TURNS = 10;
    public const int MAX_RESTING_TURNS = 5;
    public const float HEALING_FACTOR = 0.05f;

    public bool IsActive { get; set; } 
    public LocationData LocationData { get; private set; }
    
    public Party Party { get; private set; }
    
    private Encounter curEncounter;
    
    private float partyHp;
    private float maxPartyHp;

    private int expGained;

    private int goldEarned;
    public int GoldEarned { get => goldEarned; }

    private Dictionary<string, int> defeated = new Dictionary<string, int>();
    private Dictionary<string, int> explored = new Dictionary<string, int>();

    public Quest(Party party, LocationData location)
    {
        LocationData = location;
        Party = party;
        maxPartyHp = party.CalcTotalDef();
        partyHp = maxPartyHp;
        IsActive = true;
        party.LastQuest = this;
    }

    public string Log()
    {
        if (IsActive) return $"No log to display. {Party.Name} is currently adventuring in {LocationData.Name}.";
        var sb = new StringBuilder();
        sb.AppendLine($"{Party.Name} adventured in {LocationData.Name}");
        sb.AppendLine($"  Earned {goldEarned} gold");
        sb.AppendLine($"  Gained {expGained} EXP");
        sb.AppendLine();
        if (defeated.Keys.Count > 0)
        {
            sb.AppendLine();
            sb.AppendLine("  Defeated:");
            sb.Append(formatLogCounter(defeated));
        }
        if (explored.Keys.Count > 0)
        {
            sb.AppendLine();
            sb.AppendLine("  Found:");
            sb.Append(formatLogCounter(explored));
        }
        return sb.ToString();
    }

    private string formatLogCounter(Dictionary<string, int> logCounter)
    {
        var sb = new StringBuilder();
        foreach (var key in logCounter.Keys)
        {
            sb.AppendLine(formatLogCounterKey(logCounter, key));
        }
        return sb.ToString();
    }

    private string formatLogCounterKey(Dictionary<string, int> logCounter, string key) =>
        $"    {logCounter[key]} x {key}";

    public void Adventure(int turns = STARTING_TURNS)
    {
        do
        {
            turns = runAndProcess(turns);
        } while (turns > 0);
    }

    private int runAndProcess(int turns)
    {
        if (partyHp <= 0) return restAndHeal(turns);

        if (curEncounter == null || curEncounter.IsComplete())
        {
            if (curEncounter != null)
            {
                var logCounter = curEncounter is Combat ? defeated : explored;

                if (logCounter.ContainsKey(curEncounter.LogString()))
                {
                    logCounter[curEncounter.LogString()]++;
                }
                else
                {
                    logCounter.Add(curEncounter.LogString(), 1);
                }
            }
            curEncounter = LocationData.SpawnEncounter();
        }

        var results = curEncounter.Run(Party, turns);
        if (results.DamageTaken != null) partyHp -= results.DamageTaken.Value;
        if (results.GoldGained != null) goldEarned += results.GoldGained.Value;
        if (results.ExpGained != null)
        {
            Party.GiveExp(results.ExpGained.Value);
            expGained += results.ExpGained.Value;
        }

        return results.turnsRemaining;
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
