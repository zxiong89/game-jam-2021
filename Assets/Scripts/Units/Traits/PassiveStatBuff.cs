using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Traits/PassiveEffects/PassiveStatBuff")]
[System.Serializable]
public class PassiveStatBuff : PassiveTraitEffect
{
    public override Type GetArgType()
    {
        return typeof(PassiveStatBuffArgs);
    }

    public override BaseTraitEffectArgs GetNewArg()
    {
        return new PassiveStatBuffArgs();
    }

    protected override void ApplyEffect(BaseTraitEffectArgs uncastArgs)
    {
        var args = uncastArgs as PassiveStatBuffArgs;
        if (args == null) return;
        args.CurrentUnit.Stats.GetStat(args.StatToIncrease).passiveModifier += args.Amount;
    }

    protected override void RemoveEffect(BaseTraitEffectArgs uncastArgs)
    {
        var args = uncastArgs as PassiveStatBuffArgs;
        if (args == null) return;
        args.CurrentUnit.Stats.GetStat(args.StatToIncrease).passiveModifier -= args.Amount;
    }
}
