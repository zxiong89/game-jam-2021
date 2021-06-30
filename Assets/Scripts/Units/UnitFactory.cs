using UnityEngine;

public class UnitFactory : MonoBehaviour
{
    #region Growth Limits
    [SerializeField]
    GrowthFactorLimits growthLimits;

    [SerializeField]
    IntegerLimits ageLimits;
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
        return RandomizeUnit(ageLimits);
    }

    public Unit RandomizeUnit(IntegerLimits curAgeLimits)
    {
        int age = (int)FloatExtensions.Randomize(curAgeLimits.Min, curAgeLimits.Max, curAgeLimits.Mean);
        int level = Random.Range(curAgeLimits.Min, age);
        var stats = new StatBlock(level, growthLimits);
        return new Unit("Jeff", level, age, stats);
    }
}
