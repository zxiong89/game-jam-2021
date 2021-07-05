using UnityEngine;

public class PartyUnitSelectorSummary : MonoBehaviour
{
    [SerializeField]
    private PartyEvent showDeltaEvent;

    public bool IsFrontline;

    public PartyStats? Baseline;

    private UnitDisplay unitDisplay;

    private void Awake()
    {
        unitDisplay = GetComponent<UnitDisplay>();
    }

    public void OnValueChange(bool selected)
    {
        if (selected && unitDisplay.currentUnit != null)
        {
            var newContributions = unitDisplay.currentUnit.CalcContribution(IsFrontline);
            showDeltaEvent.Raise(new PartyEventArgs()
            {
                PartyStats = Baseline != null ? 
                    Baseline.Value - newContributions : newContributions
            });
        }
    }
}
