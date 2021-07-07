using UnityEngine;
using UnityEngine.UI;

public class PartyDetailsPanel : MonoBehaviour
{
    public PartyData PartyData;

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

    public void AcceptChanges()
    {
        ClosePanel();
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
