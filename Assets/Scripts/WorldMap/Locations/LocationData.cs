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
        var rand = Random.Range(0, 100);
        
        if (rand < combatEncounterRate && combatEncounters.Count > 0)
        {
            if (combatEncounters.Count == 0)
            {
                Debug.LogError("No combat encounters to spawn");
                return null;
            }

            return new Combat(combatEncounters[Random.Range(0, combatEncounters.Count - 1)]);
        }
        else if (explorationEncounters.Count == 0)
        {
            Debug.LogError("No exploration encounters to spawn");
            return null;
        }

        return new Exploration(explorationEncounters[Random.Range(0, explorationEncounters.Count - 1)]);
    }
}
