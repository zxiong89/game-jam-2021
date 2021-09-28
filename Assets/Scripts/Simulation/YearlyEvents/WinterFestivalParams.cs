using UnityEngine;
[CreateAssetMenu(menuName = "YearlyEvents/WinterFestivalParams")]
public class WinterFestivalParams : BaseYearlyEventParams<WinterFestival>
{
    [SerializeField]
    private Guild playerGuild;

    [SerializeField]
    private UnitRoster inPartyRoster;

    public override WinterFestival CreateInitialEventHelper()
    {
        var winterFest = base.CreateInitialEventHelper();
        winterFest.PlayerGuild = playerGuild;
        winterFest.InPartyRoster = inPartyRoster;
        return winterFest;
    }
}
