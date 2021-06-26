using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    #region Fields/Properties
    private int level;
    public int Level
    {
        get => level;
        set
        {
            level = value;
            Stats?.UpdateStats(level);
        }
    }

    public StatBlock Stats;
    #endregion

    #region Growth Limits
    [SerializeField]
    GrowthFactorLimits growthLimits;
    #endregion

    #region Methods
    public void LevelUp() => Level++;
    #endregion 

    #region MonoBehavior
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
}
