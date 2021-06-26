using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFactory : MonoBehaviour
{
    #region Growth Limits
    [SerializeField]
    GrowthFactorLimits growthLimits;
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
        int age = 1;
        int level = 1;
        var stats = new StatBlock(level, growthLimits);
        return new Unit(level, age, stats);
    }
}
