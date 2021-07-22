using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartiesSelectionPanel : MonoBehaviour
{
    [Header("Data")]
    [SerializeField]
    private Toggle summaryTogglePrefab;

    [SerializeField]
    private PartyCollection activeParties;

    [SerializeField]
    private QuestCollection activeQuests;

    [SerializeField]
    private QuestCollection pastQuests;

    [SerializeField]
    private Guild guild;

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
    private Button lastQuestButton;

    [SerializeField]
    private PopupEvent createPopup;

    [SerializeField]
    private WorldMapPanel worldMapPrefab;

    [SerializeField]
    private QuestLogPopup questLogPopupPrefab;

    private List<PartySummaryDisplay> summaryDisplays = new List<PartySummaryDisplay>();

    private void Start()
    {
        foreach (var p in activeParties.Parties)
        {
            var toggle = GameObject.Instantiate<Toggle>(summaryTogglePrefab, partiesToggleGroup.transform);
            toggle.group = partiesToggleGroup;
            toggle.onValueChanged.AddListener((bool selected) =>
            {
                var selectedToggle = ToggleExtensions.FindSelectedToggle(partiesToggleGroup);
                var partyData = selectedToggle != null ? findPartyDataFromToggle(selectedToggle) : null;
                changeEditButtonState(partyData);
                changeQuestButtonStates(partyData);
            });

            var summary = toggle.GetComponentInChildren<PartySummaryDisplay>();
            summaryDisplays.Add(summary);
            summary.DisplayParty(p.Party);
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }

    private void changeEditButtonState(PartyData partyData)
    {
        if (partyData == null) editPartyButton.interactable = false;
        else editPartyButton.interactable = (partyData.Party.FindQuestInCollection(activeQuests) == null);
    }

    private void changeQuestButtonStates(PartyData partyData)
    {
        if (partyData != null && partyData.Party.UnitCount() > 0)
        {
            var isQuesting = partyData.Party.IsQuesting(activeQuests);
            assignButton.gameObject.SetActive(!isQuesting);
            recallButton.gameObject.SetActive(isQuesting);
            lastQuestButton.gameObject.SetActive(partyData.Party.FindQuestInCollection(pastQuests) != null);
            return;
        }
        assignButton.gameObject.SetActive(false);
        recallButton.gameObject.SetActive(false);
        lastQuestButton.gameObject.SetActive(false);
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
        foreach (var p in activeParties.Parties)
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

        for (var i = 0; i < activeParties.Parties.Length; i++)
        {
            if (activeParties.Parties[i] == args.PartyData)
            {
                summaryDisplays[i].DisplayParty(activeParties.Parties[i].Party);
                break;
            }
        }
    }

    public void OpenQuestAssignment()
    {
        var partyData = findSelectedPartyDataAndDeselect();
        if (partyData == null) return;

        var content = GameObject.Instantiate<WorldMapPanel>(worldMapPrefab);
        createPopup.Raise(new PopupEventArgs()
        {
            Content = content.gameObject,
            AcceptTextOverride = "Assign",
            AcceptCallback = (GameObject obj) => assignQuestToParty(partyData.Party, content.GetSelectedLocation())
        });
    }

    private void assignQuestToParty(Party party, LocationData locationData)
    {
        if (party == null) return;
        if (locationData == null) return;

        var oldQuest = party.FindQuestInCollection(pastQuests);
        if (oldQuest != null) pastQuests.Quests.Remove(oldQuest);

        var newQuest = new Quest(party, locationData);
        activeQuests.Quests.Add(newQuest);
        pastQuests.Quests.Add(newQuest);
    }

    public void RecallParty()
    {
        var partyData = findSelectedPartyDataAndDeselect();
        if (partyData == null) return;

        var quest = partyData.Party.StopQuesting(activeQuests);
        guild.Gold += quest.GoldEarned;
        guild.Exp += quest.ExpGained * FloatConstants.GuildExpPercent;
    }

    public void OpenLastQuestLog()
    {
        var partyData = findSelectedPartyDataAndDeselect();
        if (partyData == null) return;
        var quest = partyData.Party.FindQuestInCollection(pastQuests);
        if (quest == null) return;

        var content = GameObject.Instantiate<QuestLogPopup>(questLogPopupPrefab);
        content.SetQuestLog(quest);
        createPopup.Raise(new PopupEventArgs()
        {
            Content = content.gameObject
        });
    }
}
