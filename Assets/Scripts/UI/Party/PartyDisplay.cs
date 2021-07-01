using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PartyDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameDisplay;

    [SerializeField]
    private PartyStatsGroup stats;

    public Party CurrentParty { get; private set; }

    public void DisplayParty(Party party)
    {
        CurrentParty = party;
        if (nameDisplay != null) nameDisplay.text = CurrentParty.Name;
        stats?.DisplayPartyStats(party.Stats);
    }
}
