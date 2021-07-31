using System.Collections;
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

    private void addTier2CombatData(StringBuilder sb)
    {
        List<float> minAtks = new List<float>();
        List<float> maxAtks = new List<float>();

        List<float> minDefs = new List<float>();
        List<float> maxDefs = new List<float>();

        foreach (var data in combatEncounters)
        {
            if (data.Type.IsBoss) continue;
            
            minAtks.Add(data.Type.Atk.Min);
            maxAtks.Add(data.Type.Atk.Max);

            minDefs.Add(data.Type.Def.Min);
            maxDefs.Add(data.Type.Def.Max);
        }

        sb.AppendLine($"Scouted Creature Attack Range: {FloatExtensions.ToString(Mathf.Min(minAtks.ToArray()))} - {FloatExtensions.ToString(Mathf.Max(maxAtks.ToArray()))}");
        sb.AppendLine($"Scouted Creature Defense Range: {FloatExtensions.ToString(Mathf.Min(minDefs.ToArray()))} - {FloatExtensions.ToString(Mathf.Max(maxDefs.ToArray()))}");
    }

    private void addTier2ExplorationData(StringBuilder sb)
    {
        List<float> min = new List<float>();
        List<float> max = new List<float>();

        foreach (var data in explorationEncounters)
        {
            if (data.Type.IsSpecial) continue;

            min.Add(data.Type.Time.Min);
            max.Add(data.Type.Time.Max);
        }

        sb.AppendLine($"Scouted Exploration Time Range: {FloatExtensions.ToString(Mathf.Min(min.ToArray()))} - {FloatExtensions.ToString(Mathf.Max(max.ToArray()))}");
    }

    private void addTier3CombatData(StringBuilder sb)
    {
        List<float> normalMinAtks = new List<float>();
        List<float> normalMaxAtks = new List<float>();
        List<float> normalMinDefs = new List<float>();
        List<float> normalMaxDefs = new List<float>();

        List<float> bossMinAtks = new List<float>();
        List<float> bossMaxAtks = new List<float>();
        List<float> bossMinDefs = new List<float>();
        List<float> bossMaxDefs = new List<float>();

        float maxSpawn = 0f;
        float normalSpawn = 0f;

        foreach (var data in combatEncounters)
        {
            maxSpawn += data.SpawnRate;
            if (data.Type.IsBoss)
            {
                bossMinAtks.Add(data.Type.Atk.Min);
                bossMaxAtks.Add(data.Type.Atk.Max);

                bossMinDefs.Add(data.Type.Def.Min);
                bossMaxDefs.Add(data.Type.Def.Max);
            }
            else
            {
                normalSpawn += data.SpawnRate;
                normalMinAtks.Add(data.Type.Atk.Min);
                normalMaxAtks.Add(data.Type.Atk.Max);

                normalMinDefs.Add(data.Type.Def.Min);
                normalMaxDefs.Add(data.Type.Def.Max);
            }
        }

        sb.AppendLine($"There is a {FloatExtensions.ToString(normalSpawn / maxSpawn * 100)} chance to encounter non-boss creatures.");

        sb.ToString();
        sb.AppendLine($"Scouted Non-Boss Attack Range: {FloatExtensions.ToString(Mathf.Min(normalMinAtks.ToArray()))} - {FloatExtensions.ToString(Mathf.Max(normalMaxAtks.ToArray()))}");
        sb.AppendLine($"Scouted Non-Boss Defense Range: {FloatExtensions.ToString(Mathf.Min(normalMinDefs.ToArray()))} - {FloatExtensions.ToString(Mathf.Max(normalMaxDefs.ToArray()))}");

        sb.ToString();
        sb.AppendLine($"Scouted Boss Attack Range: {FloatExtensions.ToString(Mathf.Min(bossMinAtks.ToArray()))} - {FloatExtensions.ToString(Mathf.Max(bossMaxAtks.ToArray()))}");
        sb.AppendLine($"Scouted Boss Defense Range: {FloatExtensions.ToString(Mathf.Min(bossMinDefs.ToArray()))} - {FloatExtensions.ToString(Mathf.Max(bossMaxDefs.ToArray()))}");
    }

    private void addTier3ExplorationData(StringBuilder sb)
    {
        List<float> min = new List<float>();
        List<float> max = new List<float>();

        foreach (var data in explorationEncounters)
        {
            if (data.Type.IsSpecial) continue;

            min.Add(data.Type.Time.Min);
            max.Add(data.Type.Time.Max);
        }

        sb.Append($"Scouted Exploration Time Range: {FloatExtensions.ToString(Mathf.Min(min.ToArray()))} - {FloatExtensions.ToString(Mathf.Max(max.ToArray()))}");
    }
}
