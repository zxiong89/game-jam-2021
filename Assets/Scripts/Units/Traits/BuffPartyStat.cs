using System;
using UnityEngine;
[CreateAssetMenu(menuName = "Traits/PartyEffects/BuffPartyStat")]
public class BuffPartyStat : PartyTraitEffect
{
    public override Type GetArgType()
    {
        return typeof(BuffPartyStatArgs);
    }

    public override BaseTraitEffectArgs GetNewArg()
    {
        return new BuffPartyStatArgs();
    }

    protected override void ApplyEffect(BaseTraitEffectArgs uncastArgs)
    {
        BuffPartyStatArgs args = uncastArgs as BuffPartyStatArgs;
        args.CurrentParty.ApplyToParty((unit, isFront) =>
        {
            if(unit != args.CurrentUnit)
            {
                unit.Stats.GetStat(args.StatToIncrease).partyModifier += args.Amount;
            }
        });
    }

    protected override void RemoveEffect(BaseTraitEffectArgs uncastArgs)
    {
        BuffPartyStatArgs args = uncastArgs as BuffPartyStatArgs;
        args.CurrentParty.ApplyToParty((unit, isFront) =>
        {
            if(unit != args.CurrentUnit)
            {
                unit.Stats.GetStat(args.StatToIncrease).partyModifier -= args.Amount;
            }
        });
    }
}
