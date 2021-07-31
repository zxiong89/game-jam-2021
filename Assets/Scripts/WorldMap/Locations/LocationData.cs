﻿using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "WorldMap/LocationData")]
[System.Serializable]
public class LocationData : ScriptableObject
{
    private const float MaxEncounterRange = 100f;
    private const float MinEncounterRange = 0f;

    [SerializeField] 
    private string locationName;
    public string Name { get => locationName; }

    [SerializeField]
    [TextArea]
    private string description;

    [SerializeField]
    private List<CombatData> combatEncounters;

    [SerializeField]
    private float combatEncounterRate;

    [SerializeField]
    private List<ExplorationData> explorationEncounters;

    public Encounter SpawnEncounter()
    {
        float rand = Random.Range(MinEncounterRange, MaxEncounterRange);
        
        if (rand < combatEncounterRate && combatEncounters.Count > 0)
        {
            return spawnCombatEncounter();
        }

        return spawnExplorationEncounter();
    }

    private Encounter spawnCombatEncounter()
    {
        if (combatEncounters.Count == 0)
        {
            Debug.LogError("No combat encounters to spawn");
            return null;
        }

        float max = 0f;
        foreach(var data in combatEncounters)
        {
            max += data.SpawnRate;
        }

        float i = Random.Range(0, max);
        foreach(var data in combatEncounters)
        {
            if (i <= data.SpawnRate) return new Combat(data);
            i -= data.SpawnRate; 
        }

        return new Combat(combatEncounters[0]); // fail-safe but should never hit
    }

    private Encounter spawnExplorationEncounter()
    {
        if (explorationEncounters.Count == 0)
        {
            Debug.LogError("No exploration encounters to spawn");
            return null;
        }

        float max = 0f;
        foreach (var data in explorationEncounters)
        {
            max += data.SpawnRate;
        }

        float i = Random.Range(0, max);
        foreach (var data in explorationEncounters)
        {
            if (i <= data.SpawnRate) return new Exploration(data);
            i -= data.SpawnRate;
        }

        return new Exploration(explorationEncounters[0]); // fail-safe but should never hit
    }

    public string ScoutLocation(int tier)
    {
        var sb = new StringBuilder();
        sb.Append(description);
        bool maxTier = tier >= GameConstants.MaxQuestScoutingTiers;

        if (tier > 1)
        {
            sb.AppendLine();
            sb.Append($"Combat/Exploration Ratio: 1:{FloatExtensions.ToString(MaxEncounterRange / combatEncounterRate)}");
        }

        if (tier == 2)
        {
            addTier2CombatData(sb);
            addTier2ExplorationData(sb);
        }
        else if (maxTier)
        {
            addTier3CombatData(sb);
            addTier3ExplorationData(sb);
        }

        return sb.ToString();
    }

    private float minFloat(float f1, float f2) => f1 > f2 ? f2 : f1;

    private string formatRange(float f1, float f2) => $"{FloatExtensions.ToString(f1)} - {FloatExtensions.ToString(f2)}";


    private void addTier2CombatData(StringBuilder sb)
    {
        float normalMinAtk = float.MaxValue;
        float normalMaxAtk = float.MinValue;
        float normalMinDef = float.MaxValue;
        float normalMaxDef = float.MinValue;

        foreach (var data in combatEncounters)
        {
            if (data.Type.IsBoss) continue;
            
            normalMinAtk = minFloat(normalMinAtk, data.Type.Atk.Min);
            normalMaxAtk = minFloat(normalMaxAtk, data.Type.Atk.Max);
            normalMinDef = minFloat(normalMinDef, data.Type.Def.Min);
            normalMaxDef = minFloat(normalMaxDef, data.Type.Def.Max);
        }

        sb.AppendLine($"Scouted Creature Attack Range: {formatRange(normalMinAtk, normalMaxAtk)}");
        sb.AppendLine($"Scouted Creature Defense Range: {formatRange(normalMinDef, normalMaxDef)}");
    }

    private void addTier2ExplorationData(StringBuilder sb)
    {
        float normalMinTime = float.MaxValue;
        float normalMaxTime = float.MinValue;

        foreach (var data in explorationEncounters)
        {
            if (data.Type.IsLair) continue;

            normalMinTime = minFloat(normalMinTime, data.Type.Time.Min);
            normalMaxTime = minFloat(normalMaxTime, data.Type.Time.Max);
        }

        sb.AppendLine($"Scouted Exploration Time Range: {formatRange(normalMinTime, normalMaxTime)}");
    }

    private void addTier3CombatData(StringBuilder sb)
    {
        float normalMinAtk = float.MaxValue;
        float normalMaxAtk = float.MinValue;
        float normalMinDef = float.MaxValue;
        float normalMaxDef = float.MinValue;
        float normalMinGold = float.MaxValue;
        float normalMaxGold = float.MinValue;
        float normalMinExp = float.MaxValue;
        float normalMaxExp = float.MinValue;

        float bossMinAtk = float.MaxValue;
        float bossMaxAtk = float.MinValue;
        float bossMinDef = float.MaxValue;
        float bossMaxDef = float.MinValue;
        float bossMinGold = float.MaxValue;
        float bossMaxGold = float.MinValue;
        float bossMinExp = float.MaxValue;
        float bossMaxExp = float.MinValue;

        float maxSpawn = 0f;
        float bossSpawn = 0f;

        foreach (var data in combatEncounters)
        {
            maxSpawn += data.SpawnRate;
            if (data.Type.IsBoss)
            {
                bossSpawn += data.SpawnRate;
                bossMinAtk = minFloat(bossMinAtk, data.Type.Atk.Min);
                bossMaxAtk = minFloat(bossMaxAtk, data.Type.Atk.Max);
                bossMinDef = minFloat(bossMinDef, data.Type.Def.Min);
                bossMaxDef = minFloat(bossMaxDef, data.Type.Def.Max);

                bossMinGold = minFloat(bossMinGold, data.Type.Gold.Min);
                bossMaxGold = minFloat(bossMaxGold, data.Type.Gold.Max);
                bossMinExp = minFloat(bossMinExp, data.Type.Exp.Min);
                bossMaxExp = minFloat(bossMaxExp, data.Type.Exp.Max);
            }
            else
            {
                normalMinAtk = minFloat(normalMinAtk, data.Type.Atk.Min);
                normalMaxAtk = minFloat(normalMaxAtk, data.Type.Atk.Max);
                normalMinDef = minFloat(normalMinDef, data.Type.Def.Min);
                normalMaxDef = minFloat(normalMaxDef, data.Type.Def.Max);

                normalMinGold = minFloat(normalMinGold, data.Type.Gold.Min);
                normalMaxGold = minFloat(normalMaxGold, data.Type.Gold.Max);
                normalMinExp = minFloat(normalMinExp, data.Type.Exp.Min);
                normalMaxExp = minFloat(normalMaxExp, data.Type.Exp.Max);
            }
        }

        sb.AppendLine($"There is a {FloatExtensions.ToString(bossSpawn / maxSpawn * 100)} chance to encounter bosses.");

        sb.ToString();
        sb.AppendLine($"Scouted Non-Boss Attack Range: {formatRange(normalMinAtk, normalMaxAtk)}");
        sb.AppendLine($"Scouted Non-Boss Defense Range: {formatRange(normalMinDef, normalMaxDef)}");
        sb.AppendLine($"Scouted Non-Boss Gold Range: {formatRange(normalMinGold, normalMaxGold)}");
        sb.AppendLine($"Scouted Non-Boss Exp Range: {formatRange(normalMinExp, normalMaxExp)}");

        if (bossSpawn <= 0f) return;

        sb.ToString();
        sb.AppendLine($"Scouted Boss Attack Range: {formatRange(bossMinAtk, bossMaxAtk)}");
        sb.AppendLine($"Scouted Boss Defense Range: {formatRange(bossMinDef, bossMaxDef)}");
        sb.AppendLine($"Scouted Boss Gold Range: {formatRange(bossMinGold, bossMaxGold)}");
        sb.AppendLine($"Scouted Boss Exp Range: {formatRange(bossMinExp, bossMaxExp)}");
    }

    private void addTier3ExplorationData(StringBuilder sb)
    {
        float normalMinTime = float.MaxValue;
        float normalMaxTime = float.MinValue;
        float normalMinGold = float.MaxValue;
        float normalMaxGold = float.MinValue;
        float normalMinExp = float.MaxValue;
        float normalMaxExp = float.MinValue;

        float lairMinTime = float.MaxValue;
        float lairMaxTime = float.MinValue;
        float lairMinGold = float.MaxValue;
        float lairMaxGold = float.MinValue;
        float lairMinExp = float.MaxValue;
        float lairMaxExp = float.MinValue;

        float maxSpawn = 0f;
        float lairSpawn = 0f;

        foreach (var data in explorationEncounters)
        {
            maxSpawn += data.SpawnRate;

            if (data.Type.IsLair)
            {
                lairSpawn += data.SpawnRate;
                lairMinTime = minFloat(lairMinTime, data.Type.Time.Min);
                lairMaxTime = minFloat(lairMaxTime, data.Type.Time.Max);
                lairMinGold = minFloat(lairMinGold, data.Type.Gold.Min);
                lairMaxGold = minFloat(lairMaxGold, data.Type.Gold.Max);
                lairMinExp = minFloat(lairMinExp, data.Type.Exp.Min);
                lairMaxExp = minFloat(lairMaxExp, data.Type.Exp.Max);
            }
            else
            {
                normalMinTime = minFloat(normalMinTime, data.Type.Time.Min);
                normalMaxTime = minFloat(normalMaxTime, data.Type.Time.Max);
                normalMinGold = minFloat(normalMinGold, data.Type.Gold.Min);
                normalMaxGold = minFloat(normalMaxGold, data.Type.Gold.Max);
                normalMinExp = minFloat(normalMinExp, data.Type.Exp.Min);
                normalMaxExp = minFloat(normalMaxExp, data.Type.Exp.Max);
            }

        }

        sb.AppendLine($"There is a {FloatExtensions.ToString(lairSpawn / maxSpawn * 100)} chance to discover a lair.");

        sb.AppendLine();
        sb.AppendLine($"Scouted Non-Lair Time Range: {formatRange(normalMinTime, normalMaxTime)}");
        sb.AppendLine($"Scouted Non-Lair Gold Range: {formatRange(normalMinGold, normalMaxGold)}");
        sb.AppendLine($"Scouted Non-Lair Exp Range: {formatRange(normalMinExp, normalMaxExp)}");

        if (lairSpawn <= 0f) return;

        sb.AppendLine();
        sb.AppendLine($"Scouted Lair Time Range: {formatRange(lairMinTime, lairMaxTime)}");
        sb.AppendLine($"Scouted Lair Gold Range: {formatRange(lairMinGold, lairMaxGold)}");
        sb.AppendLine($"Scouted Lair Exp Range: {formatRange(lairMinExp, lairMaxExp)}");
    }
}
