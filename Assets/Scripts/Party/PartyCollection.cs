using UnityEngine;

[CreateAssetMenu(menuName = "Party/PartyCollection")]
public class PartyCollection : ScriptableObject
{
    public const int PARTY_COLLECTION_SIZE = 3;
    public PartyData[] Parties;

    public void Reset()
    {
        int i = 1;
        foreach (var data in Parties)
        {
            var p = new Party();
            p.Name = "Party " + i++;
            data.Party = p;
        }
    }
}
