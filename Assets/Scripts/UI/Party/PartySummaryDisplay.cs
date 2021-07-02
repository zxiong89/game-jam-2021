using TMPro;
using UnityEngine;

public class PartySummaryDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameDisplay;

    [SerializeField]
    private PartyStatsGroup stats;

    public Party Party { get; private set; }

    public void DisplayParty(PartyEventArgs args)
    {
        Party = args.Party;
        if (nameDisplay != null) nameDisplay.text = Party.Name;
        stats?.DisplayPartyStats(Party.Stats);
    }
}
