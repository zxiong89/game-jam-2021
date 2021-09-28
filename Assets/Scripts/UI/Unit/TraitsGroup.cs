using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraitsGroup : MonoBehaviour
{
    [SerializeField]
    private GameObject traitsContainer;

    [SerializeField]
    private GameObject traitsPrefab;

    public void DisplayTraits(List<Trait> traits, int scoutingTier)
    {
        if (scoutingTier <= 1)
        {
            this.gameObject.SetActive(false);
            return;
        }

        foreach(var trait in traits)
        {
            AddTrait(trait);
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }
    public void AddTrait(Trait trait)
    {
        GameObject newTraitObj = Instantiate(traitsPrefab, traitsContainer.transform);
        var newTrait = newTraitObj.GetComponent<TraitDisplay>();
        newTrait.SetTrait(trait.Name, trait.Description, trait.Color);
    }
}
