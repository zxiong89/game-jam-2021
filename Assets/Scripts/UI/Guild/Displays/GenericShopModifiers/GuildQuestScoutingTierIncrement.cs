using System;
using UnityEngine;

[RequireComponent(typeof(GuildPartyGenericShopDisplay))]

public class GuildQuestScoutingTierIncrement : GuildPartyPowScalingModifier
{
    [SerializeField]
    private IntegerVariable questScoutingTier;

    protected override void onBuy()
    {
        questScoutingTier.Value++;
    }

    protected override bool shouldDisableDisplay() =>
        questScoutingTier.Value >= GameConstants.MaxQuestScoutingTiers;

    protected override double getPower() =>
        questScoutingTier.Value;
}
