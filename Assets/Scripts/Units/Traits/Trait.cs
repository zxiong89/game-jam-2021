using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Traits/Trait")]
[System.Serializable]
public class Trait : ScriptableObject
{
    //[SerializeField]
    //public string Name;// { get; set; }
    
    [SerializeField]
    private string description;

    public string Description
    {
        get { return description; }
    }

    [SerializeField]
    private bool isPositive;
    public bool IsPositive
    {
        get { return isPositive; }
    }

    public int[] StatModifiers { get; set; }

    [SerializeField]
    public List<BaseTraitEffect> TraitEffects = new List<BaseTraitEffect>();
    
    [SerializeReference]
    public List<BaseTraitEffectArgs> TraitEffectArgs = new List<BaseTraitEffectArgs>();
 
    public Trait() { }

    public Trait(TraitTemplate template)
    {
        //Name = template.name;
        //Description = template.Description;
        //Color = template.Color;
        StatModifiers = new int[template.StatModifiers.Length];
        for (int i = 0; i < template.StatModifiers.Length; i++)
        {
            StatModifiers[i] = template.StatModifiers[i];
        }
    }

    private void OnValidate()
    {
        if(TraitEffects.Count < TraitEffectArgs.Count)
        {
            for(int i = TraitEffectArgs.Count; i > TraitEffects.Count; i--)
            {
                TraitEffectArgs.RemoveAt(i - 1);
            }
        }
        else if(TraitEffects.Count > TraitEffectArgs.Count)
        {
            while(TraitEffects.Count > TraitEffectArgs.Count)
            {
                TraitEffectArgs.Add(null);
            }
        }

        for (int i = 0; i < TraitEffects.Count; i++)
        {
            BaseTraitEffect effect = TraitEffects[i];
            if(effect != null)
            {
                BaseTraitEffectArgs args = TraitEffectArgs[i];
                if(args == null || args.GetType() != effect.GetArgType())
                {
                    TraitEffectArgs[i] = effect.GetNewArg();
                }
            }
            else
            {
                TraitEffectArgs[i] = null;
            }
        }
        
    }
}