using UnityEngine;

[System.Serializable]
public abstract class BaseTraitEffect : ScriptableObject 
{
    public abstract TraitEffectType GetEffectType();

    public abstract BaseTraitEffectArgs GetNewArg();

    public abstract System.Type GetArgType();

    protected abstract void ApplyEffect(BaseTraitEffectArgs args);

    protected abstract void RemoveEffect(BaseTraitEffectArgs args);
}

public enum TraitEffectType 
{
    Passive,
    Party
}


