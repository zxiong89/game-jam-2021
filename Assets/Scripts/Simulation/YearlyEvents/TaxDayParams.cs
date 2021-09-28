using UnityEngine;

[CreateAssetMenu(menuName = "YearlyEvents/TaxDayParams")]
public class TaxDayParams : BaseYearlyEventParams<TaxDay>
{
    [SerializeField]
    private Guild playerGuild;

    public override TaxDay CreateInitialEventHelper()
    {
        var taxDay = base.CreateInitialEventHelper();
        taxDay.PlayerGuild = playerGuild;
        return taxDay;
    }
}
