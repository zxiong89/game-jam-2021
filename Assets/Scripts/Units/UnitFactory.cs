using System.Collections.Generic;
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
    private TraitFactory traitFactory;

    [SerializeField]
    private string nameJsonFile;

    private string[] names;

    [SerializeField]
    private UnitRoster freeAgentRoster;

    [SerializeField]
    private FloatVariable currentTime;
    
    [SerializeField]
    private IntegerLimits greedLimits;

    private void Awake()
    {
        LoadNames();
    }

    public Unit RandomizeUnit()
    {
        return RandomizeUnit(ageLimits);
    }

    public Unit RandomizeUnit(IntegerLimits curAgeLimits)
    {
        LoadNames();
        int n = Random.Range(0, names.Length);
        int age = (int)FloatExtensions.Randomize(curAgeLimits.Min, curAgeLimits.Max, curAgeLimits.Mean);
        int level = Random.Range(curAgeLimits.Min, age);
        var stats = new StatBlock(level, baseStatLimits, growthLimits);

        int s = Random.Range(0, classes.Length);
        UnitClassSelection selections = classes[s];
        int c = Random.Range(0, selections.Classes.Length);
        UnitClassData classData = selections.Classes[c];

        var traits = new List<Trait>();
        traits.Add(traitFactory.GetPositiveTrait());
        traits.Add(traitFactory.GetPositiveTrait());
        traits.Add(traitFactory.GetNegativeTrait());

        float updateTime = currentTime.Value + 1 + UnityEngine.Random.Range(0f, SimulationConstants.SECONDS_PER_YEAR);
        var newUnit = new Unit(names[n], level, age, stats, classData, traits);
        UnitCollection.ActiveUnits.Add(new ScheduledUnitEvent(newUnit, updateTime));
        freeAgentRoster?.Add(newUnit);

        int g = Random.Range(greedLimits.Min, greedLimits.Max);
        newUnit.Greed = g;

        return newUnit;
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
