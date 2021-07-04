using UnityEngine;

public class PartyUnitSelection : MonoBehaviour
{
    [Header("Display")]

    [SerializeField]
    private UnitDisplay unitDisplay;

    [SerializeField]
    private GameObject unitSummary;

    [Header("Data")]

    [SerializeField]
    private Guild guild;

    [Header("Events")]

    [SerializeField]
    private PartyEvent onUnitChanged;

    [Header("Pop-up")]

    [SerializeField]
    private PopupEvent createPopupEvent;

    [SerializeField]
    private PartyUnitSelector selector;

    public Unit Unit
    {
        get => unitDisplay?.currentUnit;
        set
        {
            if (unitDisplay != null)
            {
                unitDisplay.DisplayUnit(value);
                unitSummary.SetActive(unitDisplay.currentUnit != null);
            }
        }
    }

    public void StartUnitSelection()
    {
        var obj = GameObject.Instantiate<PartyUnitSelector>(selector);
        obj.Selection = this;
        obj.PopulateRoster();

        createPopupEvent.Raise(new PopupEventArgs()
        {
            Content = obj.gameObject
        });
    }
}
