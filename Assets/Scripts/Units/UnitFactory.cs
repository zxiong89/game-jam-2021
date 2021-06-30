using System.IO;
using UnityEngine;

public class UnitFactory : MonoBehaviour
{
    [SerializeField]
    private IntegerLimits baseStatLimits;

    [SerializeField]
    private GrowthFactorLimits growthLimits;

    [SerializeField]
    private IntegerLimits ageLimits;

    [SerializeField]
    private UnitClassSelection[] classes;

    [SerializeField]
    private string nameJsonFile;

    private string[] names;

    private void Awake()
    {
        LoadNames();
    }

    public Unit RandomizeUnit()
    {
        LoadNames();
        int n = Random.Range(0, names.Length - 1);
        int age = (int) FloatExtensions.Randomize(ageLimits.Min, ageLimits.Max, ageLimits.Mean);
        int level = Random.Range(1, age);
        var stats = new StatBlock(level, baseStatLimits, growthLimits);

        int s = Random.Range(0, classes.Length - 1);
        UnitClassSelection selections = classes[s];
        int c = Random.Range(0, selections.Classes.Length - 1);
        UnitClassData classData = selections.Classes[c];

        return new Unit(names[n], level, age, stats, classData);
    }

    /// <summary>
    /// Load names from the Json.
    /// Names22K - https://github.com/dominictarr/random-name
    /// Names5k - https://github.com/smashew/NameDatabases
    /// </summary>
    private void LoadNames()
    {
        if (names != null && names.Length > 0) return;
        var asset = Resources.Load<TextAsset>(string.Format("Json/{0}", nameJsonFile));
        StringArrayWrapper wrapper = JsonUtility.FromJson<StringArrayWrapper>(asset.text);
        names = wrapper.Items;
        Resources.UnloadAsset(asset);
    }
}
