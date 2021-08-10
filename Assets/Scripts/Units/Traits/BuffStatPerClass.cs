using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Traits/PartyEffects/BuffStatPerClass")]
public class BuffStatPerClass : PartyTraitEffect
{
    public override System.Type GetArgType()
    {
        return typeof(BuffStatPerClassArgs);
    }

    public override BaseTraitEffectArgs GetNewArg()
    {
        return new BuffStatPerClassArgs();
    }

    protected override void ApplyEffect(BaseTraitEffectArgs uncastArgs)
    {
        BuffStatPerClassArgs args = uncastArgs as BuffStatPerClassArgs;
        args.CurrentParty.ApplyToParty((unit, isFront) => {
            if(MeetsCondition(unit, args)){
                args.CurrentUnit.Stats.GetStat(args.StatToIncrease).partyModifier += args.IncreaseAmount;
            }
        });
    }

    protected override void RemoveEffect(BaseTraitEffectArgs uncastArgs)
    {
        BuffStatPerClassArgs args = uncastArgs as BuffStatPerClassArgs;
        foreach (var unit in args.CurrentParty.FrontLine)
        {
            if (MeetsCondition(unit, args))
            {
                args.CurrentUnit.Stats.GetStat(args.StatToIncrease).passiveModifier -= args.IncreaseAmount;
            }
        }
        foreach (var unit in args.CurrentParty.BackLine)
        {
            if (MeetsCondition(unit, args))
            {
                args.CurrentUnit.Stats.GetStat(args.StatToIncrease).passiveModifier -= args.IncreaseAmount;
            }
        }
    }
    
    private bool MeetsCondition(Unit unit, BuffStatPerClassArgs args)
    {
        return unit != args.CurrentUnit && unit.Class.Data.PrimaryStat == args.ClassPrimaryStat;
    }
}
