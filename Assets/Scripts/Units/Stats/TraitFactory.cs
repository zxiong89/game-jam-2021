using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Units/TraitFactory")]
public class TraitFactory : ScriptableObject
{
    [SerializeField]
    private TraitTemplate[] positiveTraits;

    [SerializeField]
    private TraitTemplate[] negativeTraits;
    private Trait GetNewTrait(TraitTemplate[] traits)
    {
        int index = Random.Range(0, traits.Length);
        return new Trait(traits[index]);
    }

    public Trait GetPositiveTrait()
    {
        return GetNewTrait(positiveTraits);
    }

    public Trait GetNegativeTrait()
    {
        return GetNewTrait(negativeTraits);
    }
}
