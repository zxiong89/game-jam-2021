using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Units/TraitFactory")]
public class TraitFactory : ScriptableObject
{
    [SerializeField]
    private Trait[] positiveTraits;

    [SerializeField]
    private Trait[] negativeTraits;
    private Trait GetNewTrait(Trait[] traits)
    {
        int index = Random.Range(0, traits.Length);
        return traits[index];
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
