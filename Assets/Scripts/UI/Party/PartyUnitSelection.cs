using UnityEngine;

public class PartyUnitSelection : MonoBehaviour
{
    [SerializeField]
    private UnitDisplay unitDisplay;

    [SerializeField]
    private GameObject unitSummary;

    [SerializeField]
    private Guild guild;

    [SerializeField]
    private PartyUnitSelector selector;

    [SerializeField]
    private PartyEvent onUnitChanged;

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
        var obj = GameObject.Instantiate<PartyUnitSelector>(selector, this.transform);
        obj.Selection = this;
    }
}
