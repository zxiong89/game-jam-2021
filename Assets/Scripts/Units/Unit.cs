using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    #region Stat blocks
    [SerializeField]
    private StrengthStat Str;

    [SerializeField]
    private ConstitutionStat Con;

    [SerializeField]
    private DexterityStat Dex;

    [SerializeField]
    private IntelligenceStat Int;

    [SerializeField]
    private WisdomStat Wis;
    #endregion

    #region Methods
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
