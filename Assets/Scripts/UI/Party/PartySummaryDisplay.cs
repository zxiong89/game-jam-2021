using TMPro;
using UnityEngine;

public class PartySummaryDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameDisplay;

    [SerializeField]
    private PartyStatsGroup stats;

    public Party Party { get; private set; }

    public void DisplayParty(PartyEventArgs args) => DisplayParty(args.Party);

    public void DisplayParty(Party party)
    {
        Party = party;
        Party.UpdatePartyStats();
        if (nameDisplay != null) nameDisplay.text = Party.Name;
        stats?.DisplayPartyStats(Party.Stats);
    }

    public void DisplayPartyDelta(PartyEventArgs args)
    {
        stats.DisplayPartyStatsDelta(args.PartyStats);
    }
}
