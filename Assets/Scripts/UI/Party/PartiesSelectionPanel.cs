using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartiesSelectionPanel : MonoBehaviour
{
    [Header("Data")]
    [SerializeField]
    private Toggle summaryTogglePrefab;

    [SerializeField]
    private PartyCollection allParties;

    [SerializeField]
    private QuestCollection allQuests;

    [Header("Events")]
    [SerializeField]
    private PartyEvent onPartySelected;

    [Header("Display")]

    [SerializeField]
    private ToggleGroup partiesToggleGroup;

    [Header("Editing")]

    [SerializeField]
    private Button editPartyButton;

    [SerializeField]
    private PartyDetailsPanel partyDetailsDisplay;

    [Header("Questing")]

    [SerializeField]
    private Button assignButton;

    [SerializeField]
    private Button recallButton;

    [SerializeField]
    private PopupEvent createPopup;

    [SerializeField]
    private WorldMapPanel worldMapPrefab;

    private List<PartySummaryDisplay> summaryDisplays = new List<PartySummaryDisplay>();

    private void Start()
    {
        int i = 1;
        foreach (var p in allParties.Parties)
        {
            p.Party = new Party();
            p.Party.Name = "Party " + i++;
            var toggle = GameObject.Instantiate<Toggle>(summaryTogglePrefab, partiesToggleGroup.transform);
            toggle.group = partiesToggleGroup;
            toggle.onValueChanged.AddListener((bool selected) =>
            {
                var selectedToggle = ToggleExtensions.FindSelectedToggle(partiesToggleGroup);
                changeEditButtonState(selected, selectedToggle);
                changeQuestButtonStates(selectedToggle);
            });

            var summary = toggle.GetComponentInChildren<PartySummaryDisplay>();
            summaryDisplays.Add(summary);
            summary.DisplayParty(p.Party);
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }

    private void changeEditButtonState(bool selected, Toggle toggle)
    {
        if (selected) editPartyButton.interactable = true;
        else editPartyButton.interactable = (toggle != null);
    }

    private void changeQuestButtonStates(Toggle toggle)
    {
        if (toggle != null)
        {
            var partyData = findPartyDataFromToggle(toggle);
            if (partyData != null)
            {
                var isQuesting = partyData.Party.IsQuesting(allQuests);
                assignButton.gameObject.SetActive(!isQuesting);
                recallButton.gameObject.SetActive(isQuesting);
                return;
            }
        }
        assignButton.gameObject.SetActive(false);
        recallButton.gameObject.SetActive(false);
    }

    private PartyData findSelectedPartyDataAndDeselect()
    {
        Toggle toggle = ToggleExtensions.FindSelectedToggle(partiesToggleGroup);
        toggle.isOn = false;
        return findPartyDataFromToggle(toggle); ;
    }

    private PartyData findPartyDataFromToggle(Toggle toggle)
    {
        var summary = toggle.GetComponentInChildren<PartySummaryDisplay>();
        foreach (var p in allParties.Parties)
        {
            if (p.Party == summary.Party) return p;
        }
        return null;
    }

    public void ExpandPartyDetails()
    {
        var partyData = findSelectedPartyDataAndDeselect();

        this.gameObject.SetActive(false);

        if (partyDetailsDisplay != null) {
            partyDetailsDisplay.gameObject.SetActive(true);
            partyDetailsDisplay.PartyData = partyData;
            LayoutRebuilder.ForceRebuildLayoutImmediate(partyDetailsDisplay.GetComponent<RectTransform>());
        }

        onPartySelected.Raise(new PartyEventArgs()
        {
            Party = partyData.Party
        });
    }

    public void UpdateSummaryDisplay(PartyEventArgs args)
    {
        if (args.PartyData == null) return;

        for (var i = 0; i < allParties.Parties.Length; i++)
        {
            if (allParties.Parties[i] == args.PartyData)
            {
                summaryDisplays[i].DisplayParty(allParties.Parties[i].Party);
                break;
            }
        }
    }

    public void OpenQuestAssignment()
    {
        var toggle = findSelectedPartyDataAndDeselect();
        var content = GameObject.Instantiate<WorldMapPanel>(worldMapPrefab);
        createPopup.Raise(new PopupEventArgs()
        {
            Content = content.gameObject
        });
    }
}
