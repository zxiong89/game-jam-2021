using UnityEngine;

public class UnitFactory : MonoBehaviour
{
    #region Growth Limits

    [SerializeField]
    private IntegerLimits baseStatLimits;

    [SerializeField]
    private GrowthFactorLimits growthLimits;

    [SerializeField]
    private IntegerLimits ageLimits;

    [SerializeField]
    private UnitClassSelection[] classes;

    #endregion

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    public Unit RandomizeUnit()
    {
        int age = (int) FloatExtensions.Randomize(ageLimits.Min, ageLimits.Max, ageLimits.Mean);
        int level = Random.Range(1, age);
        var stats = new StatBlock(level, baseStatLimits, growthLimits);

        int s = Random.Range(0, classes.Length - 1);
        UnitClassSelection selections = classes[s];
        int c = Random.Range(0, selections.Classes.Length - 1);
        UnitClassData classData = selections.Classes[c];

        return new Unit("jeff", level, age, stats, classData);
    }
}
