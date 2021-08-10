using UnityEngine;

[RequireComponent(typeof(GuildPartyGenericShopDisplay))]

public class GuildPartySlotsIncrement : GuildPartyPowScalingModifier
{
    [SerializeField]
    private PartyCollection activeParties;

    protected override void onBuy()
    {
        activeParties.NumberAvailable++;
    }

    protected override bool shouldDisableDisplay() => 
        activeParties.NumberAvailable >= activeParties.MaximumAvailable;

    protected override double getPower() =>
        activeParties.NumberAvailable;
}
