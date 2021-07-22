using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Guild/Guild")]
public class Guild : ScriptableObject
{
    private bool isInitializing = true;

    [SerializeField]
    public UnitRoster Roster;

    #region Gold 
    [Header("Gold")]

    [SerializeField]
    private IntEvent goldChangedEvent;

    [SerializeField]
    private IntegerVariable gold;
    public int Gold
    {
        get { return gold.Value; }
        set {
            if (!isInitializing)
            {
                int delta = value - gold.Value;
                if (delta > 0)
                {
                    GuildStatistics.GoldGained += delta;
                }
                else if (delta < 0)
                {
                    GuildStatistics.GoldSpent -= delta;
                }
            }
            gold.Value = value;
            goldChangedEvent.Raise(gold.Value);
        }
    }
    #endregion

    #region Exp and Level
    [Header("Exp and Level")]

    [SerializeField]
    private FloatVariable exp;
    public float Exp
    {
        get { return exp.Value; }
        set
        {
            exp.Value = value;
        }
    }

    private float lastExpLevel;
    private int level;
    public int Level
    {
        get
        {
            if (lastExpLevel != exp.Value)
            {
                lastExpLevel = exp.Value;
                level = setLevel(exp.Value);
            }
            return level;
        }
    }

    private int setLevel(float exp)
    {
        if (exp > FloatConstants.GuildLevel10) return 10;
        if (exp > FloatConstants.GuildLevel9) return 9;
        if (exp > FloatConstants.GuildLevel8) return 8;
        if (exp > FloatConstants.GuildLevel7) return 7;
        if (exp > FloatConstants.GuildLevel6) return 6;
        if (exp > FloatConstants.GuildLevel5) return 5;
        if (exp > FloatConstants.GuildLevel4) return 4;
        if (exp > FloatConstants.GuildLevel3) return 3;
        if (exp > FloatConstants.GuildLevel2) return 2;
        return 1;
    }
    #endregion

    public void Initialize()
    {
        goldChangedEvent.Raise(gold.Value);
        isInitializing = false;
    }
}
