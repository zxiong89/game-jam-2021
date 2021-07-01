using TMPro;
using UnityEngine;

public class PartySummaryDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameDisplay;

    [SerializeField]
    private PartyStatsGroup stats;

    public Party Party { get; private set; }

    public void DisplayParty(Party party)
    {
        Party = party;
        if (nameDisplay != null) nameDisplay.text = Party.Name;
        stats?.DisplayPartyStats(party.Stats);
    }
}
