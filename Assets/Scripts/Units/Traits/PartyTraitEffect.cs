using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PartyTraitEffect : BaseTraitEffect
{
    public override TraitEffectType GetEffectType()
    {
        return TraitEffectType.Party;
    }

    public virtual void ApplyEffect(Unit unit, Party party, PartyTraitEffectArgs args) {
        args.CurrentUnit = unit;
        args.CurrentParty = party;
        ApplyEffect(args);
    }

    public virtual void RemoveEffect(Unit unit, Party party, PartyTraitEffectArgs args)
    {
        args.CurrentUnit = unit;
        args.CurrentParty = party;
        RemoveEffect(args);
    }

}
