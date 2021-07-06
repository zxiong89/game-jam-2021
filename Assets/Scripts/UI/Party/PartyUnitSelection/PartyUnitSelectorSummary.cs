using UnityEngine;

public class PartyUnitSelectorSummary : MonoBehaviour
{
    [SerializeField]
    private PartyEvent showDeltaEvent;

    public bool IsFrontline;

    public PartyStats? Baseline;

    private UnitDisplay unitDisplay;

    private bool wasSelected = false;

    private void Awake()
    {
        unitDisplay = GetComponent<UnitDisplay>();
    }

    public void OnValueChange(bool selected)
    {
        if (!selected)
        {
            if (wasSelected)
            {
                showDeltaEvent.Raise(new PartyEventArgs()
                {
                    PartyStats = Baseline != null ?
                        new PartyStats() - Baseline.Value : new PartyStats()
                }); ;
            }
        }
        else if (unitDisplay.currentUnit != null)
        {
            var newContributions = unitDisplay.currentUnit.CalcContribution(IsFrontline);
            showDeltaEvent.Raise(new PartyEventArgs()
            {
                PartyStats = Baseline != null ? 
                    Baseline.Value - newContributions : newContributions
            });
        }
        wasSelected = selected;
    }
}
