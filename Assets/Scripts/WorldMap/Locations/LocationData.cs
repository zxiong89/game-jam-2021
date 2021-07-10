using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WorldMap/LocationData")]
public class LocationData : ScriptableObject
{
    [SerializeField]
    private string locationName;
    public string Name { get => locationName; }

    [SerializeField]
    [TextArea]
    private string description;
    public string Description { get => description; }

    [SerializeField]
    private List<CombatData> combatEncounters;

    [SerializeField]
    private float combatEncounterRate;

    [SerializeField]
    private List<ExplorationData> explorationEncounters;

    public Encounter SpawnEncounter()
    {
        float rand = Random.Range(0f, 100f);
        
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
}
