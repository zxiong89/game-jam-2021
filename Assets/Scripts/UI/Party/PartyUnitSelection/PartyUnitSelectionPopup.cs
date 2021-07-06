using UnityEngine;
using UnityEngine.UI;

public class PartyUnitSelectionPopup : MonoBehaviour
{
    [SerializeField]
    private PartySummaryDisplay display;

    [SerializeField]
    private PartyUnitSelector selector;

    public void PopulatePartySummary(Party party) 
    {
        display.DisplayParty(party);
    }

    public void PopulateRoster(Unit currentUnit, bool isFrontline = true)
    {
        selector.IsFrontline = isFrontline;
        selector.PopulateRoster(currentUnit);

        var scrollRect = selector.GetComponent<ScrollRect>();
        if (scrollRect != null)
        {
            scrollRect.normalizedPosition = new Vector2(0, 1);
        }
    }

    public Unit GetSelectedUnit() => selector.GetSelectedUnit();
}
