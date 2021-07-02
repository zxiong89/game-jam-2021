using UnityEngine;

public class PartyUnitSelector : MonoBehaviour
{
    public PartyUnitSelection Selection;

    [SerializeField]
    private Guild guild;

    [SerializeField]
    private PartyEvent unitSelectedEvent;

    [SerializeField]
    private UnitEvent onUnitSelected;

    public void OnUnitSelected(Unit unit)
    {
        unitSelectedEvent.Raise(new PartyEventArgs()
        {
            Selection = this.Selection,
            Unit = unit
        });
    }
}
