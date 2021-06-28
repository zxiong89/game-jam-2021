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
    private void Start()
    {
        AddTrait("Sleepy", "zzz", Color.green);
        AddTrait("Verbose", "super long text that should wrap on at least one line to see how this looks right now", Color.red);
        AddTrait("Quiet", "...", Color.yellow);
        AddTrait("Surprised", "O.O", Color.grey);
    }
}
