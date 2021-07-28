using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Party/PartyCollection")]
[System.Serializable]
public class PartyCollection : ScriptableObject
{
    [SerializeField]
    private int available = 1;

    [SerializeField]
    private List<PartyData> parties = new List<PartyData>();

    public int NumberAvailable
    {
        get => available;
        set 
        {
            if (value > MaximumAvailable) return;
            if (value < 1) return;
            available = value;
        }
    }

    public int MaximumAvailable
    {
        get => parties.Count;
    }

    public List<PartyData> Parties
    {
        get => parties.GetRange(0, available);
    }

    public void Reset()
    {
        int i = 1;
        foreach (var data in parties)
        {
            var p = new Party();
            p.Name = "Party " + i++;
            data.Party = p;
        }
        available = 1;
    }
}
