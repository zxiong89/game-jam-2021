using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartiesSelectionPanel : MonoBehaviour
{
    [Header("Data")]
    [SerializeField]
    private Toggle summaryTogglePrefab;

    [SerializeField]
    private PartyData[] parties;

    [Header("Events")]
    [SerializeField]
    private PartyEvent onPartySelected;

    [Header("Display")]

    [SerializeField]
    private ToggleGroup partiesToggleGroup;

    [SerializeField]
    private Button editPartyButton;

    [SerializeField]
    private PartyDetailsPanel partyDetailsDisplay;

    private List<PartySummaryDisplay> summaryDisplays = new List<PartySummaryDisplay>();

    private void Start()
    {
        int i = 1;
        foreach (var p in parties)
        {
            p.Party = new Party();
            p.Party.Name = "Party " + i++;
            var toggle = GameObject.Instantiate<Toggle>(summaryTogglePrefab, partiesToggleGroup.transform);
            toggle.group = partiesToggleGroup;
            toggle.onValueChanged.AddListener((bool selected) =>
            {
                if (selected) editPartyButton.interactable = true;
                else disableEditParty();
            });

            var summary = toggle.GetComponentInChildren<PartySummaryDisplay>();
            summaryDisplays.Add(summary);
            summary.DisplayParty(p.Party);
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }

    private void disableEditParty() =>
        editPartyButton.interactable = (ToggleExtensions.FindSelectedToggle(partiesToggleGroup) != null);

    public void ExpandPartyDetails()
    {
        Toggle toggle = ToggleExtensions.FindSelectedToggle(partiesToggleGroup);
        toggle.isOn = false;

        this.gameObject.SetActive(false);

        var summary = toggle.GetComponentInChildren<PartySummaryDisplay>();
        if (partyDetailsDisplay != null) {
            partyDetailsDisplay.gameObject.SetActive(true);
            partyDetailsDisplay.PartyData = findPartyData(summary.Party);
        }

        onPartySelected.Raise(new PartyEventArgs()
        {
            Party = summary.Party
        });
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }

    private PartyData findPartyData(Party party)
    {
        foreach(var p in parties)
        {
            if (p.Party == party) return p;
        }
        return null;
    }

    public void UpdateSummaryDisplay(PartyEventArgs args)
    {
        if (args.PartyData == null) return;

        for (var i = 0; i < parties.Length; i++)
        {
            if (parties[i] == args.PartyData)
            {
                summaryDisplays[i].DisplayParty(parties[i].Party);
                break;
            }
        }
    }
}
