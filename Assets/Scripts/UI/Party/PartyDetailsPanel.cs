using UnityEngine;
using UnityEngine.UI;

public class PartyDetailsPanel : MonoBehaviour
{
    public PartyData PartyData;

    [SerializeField]
    private Guild guild;

    [SerializeField]
    private PartySelectionDisplay selectionDisplay;

    [SerializeField]
    private Button acceptButton;

    [SerializeField]
    private Button cancelButton;

    [SerializeField]
    private PartyEvent partyChangesAccepted;

    [SerializeField]
    private GameObject partiesSelectionDisplay;

    [SerializeField]
    private UnitRoster inPartiesRoster;

    public void AcceptChanges()
    {
        ClosePanel();
        var added = selectionDisplay.Party.UnitDifference(PartyData.Party);
        var removed = PartyData.Party.UnitDifference(selectionDisplay.Party);
        foreach (var u in added) inPartiesRoster.Add(u);
        foreach (var u in removed) guild.Roster.Add(u);
        PartyData.Party = selectionDisplay.Party;
        partyChangesAccepted.Raise(new PartyEventArgs()
        {
            PartyData = PartyData
        });
    }

    public void ClosePanel()
    {
        this.gameObject.SetActive(false);
        if (partiesSelectionDisplay != null)
        {
            partiesSelectionDisplay.SetActive(true);
            LayoutRebuilder.ForceRebuildLayoutImmediate(partiesSelectionDisplay.GetComponent<RectTransform>());
        }
    }
}
