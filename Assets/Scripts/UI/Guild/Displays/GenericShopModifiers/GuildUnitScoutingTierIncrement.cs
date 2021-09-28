using UnityEngine;

[RequireComponent(typeof(GuildPartyGenericShopDisplay))]
public class GuildUnitScoutingTierIncrement : GuildPartyPowScalingModifier
{
    [SerializeField]
    private IntegerVariable unitScoutingTier;

    protected override void onBuy()
    {
        unitScoutingTier.Value++;
    }

    protected override bool shouldDisableDisplay() =>
        unitScoutingTier.Value >= GameConstants.MaxUnitScoutingTiers;

    protected override double getPower() =>
        unitScoutingTier.Value;
}
