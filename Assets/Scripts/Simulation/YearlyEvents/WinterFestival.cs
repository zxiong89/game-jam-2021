using UnityEngine;

public class WinterFestival : BaseYearlyEvent
{
    public Guild PlayerGuild { get; set; }

    public UnitRoster InPartyRoster { get; set; }

    public override void RunEvent()
    {
        int unitCount = PlayerGuild.Roster.Count + InPartyRoster.Count;
        if (unitCount == 0) return;

        int totalGold = unitCount * 20;
        PopupMessage.ShowPopup(new PopupEventArgs()
        {
            Text = "It's the winter festival! A time for sharing and celebrating the achievements of the year!\n" +
            "Would you like to give your guild members a bonus?\n" + 
            "20G x " + unitCount.ToString() + " = " + totalGold + "G",

            AcceptTextOverride = "Spread cheer!",
            AcceptCallback = (popup) => AcceptCalled(popup, totalGold),
            CloseTextOverride = "Decline",
            PausesTime = true

        });
    }

    private void AcceptCalled(GameObject popup, int totalGold)
    {
        PlayerGuild.Gold -= totalGold;
        PopupMessage.ShowPopup(new PopupEventArgs()
        {
            Text = "Joyous calls and revelry can be heard throughout your guild as the celebrations run late into the night.",
            PausesTime = true
        });
    }
}
