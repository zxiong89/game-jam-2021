using UnityEngine;

public class TraitsGroup : MonoBehaviour
{
    [SerializeField]
    private GameObject traitsContainer;

    [SerializeField]
    private GameObject traitsPrefab;

    public void AddTrait(string name, string description, Color color)
    {
        GameObject newTraitObj = Instantiate(traitsPrefab, traitsContainer.transform);
        var newTrait = newTraitObj.GetComponent<TraitDisplay>();
        newTrait.SetTrait(name, description, color);
    }
}
