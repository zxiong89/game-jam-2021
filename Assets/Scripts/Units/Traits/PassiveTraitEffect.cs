using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PassiveTraitEffect : BaseTraitEffect
{
    public override TraitEffectType GetEffectType()
    {
        return TraitEffectType.Passive;
    }

    public void ApplyEffect(Unit unit, PassiveEffectArgs args)
    {
        args.CurrentUnit = unit;
        ApplyEffect(args);
    }

    public void RemoveEffect(Unit unit, PassiveEffectArgs args)
    {
        args.CurrentUnit = unit;
        RemoveEffect(args);
    }
}
