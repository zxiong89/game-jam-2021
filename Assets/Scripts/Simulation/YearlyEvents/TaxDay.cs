using UnityEngine;

public class TaxDay : BaseYearlyEvent
{
    public Guild PlayerGuild { get; set; }

    public override void RunEvent()
    {
        int taxes = Mathf.FloorToInt(Mathf.Pow((PlayerGuild.Level * 10), 2));
        EventLog.AddMessage("It's tax day! Paid " + taxes + "G in yearly guild taxes");
        PlayerGuild.Gold -= taxes;        
    }
}
