using UnityEngine;

public class PartyUnitSelectorSummary : MonoBehaviour
{
    [SerializeField]
    private PartyEvent showDeltaEvent;

    public bool IsFrontline;

    private UnitDisplay unitDisplay;

    private void Awake()
    {
        unitDisplay = GetComponent<UnitDisplay>();
    }

    public void OnValueChange(bool selected)
    {
        if (selected && unitDisplay.currentUnit != null)
        {
            showDeltaEvent.Raise(new PartyEventArgs()
            {
                PartyStats = unitDisplay.currentUnit.CalcContribution(IsFrontline)
            });
        }
    }
}
