using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Guild/Guild")]
public class Guild : ScriptableObject
{
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
            gold.Value = value;
            goldChangedEvent.Raise(gold.Value);
        }
    }
    #endregion

    #region Exp and Level
    [Header("Exp and Level")]

    [SerializeField]
    private FloatEvent expChangedEvent;

    [SerializeField]
    private IntEvent levelChangedEvent;

    [SerializeField]
    private FloatVariable exp;
    public float Exp
    {
        get { return exp.Value; }
        set
        {
            exp.Value = value;
            expChangedEvent.Raise(exp.Value);
            levelChangedEvent.Raise(Level);
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
        if (exp < 10e27f) return 10;
        if (exp < 10e24f) return 9;
        if (exp < 10e21f) return 8;
        if (exp < 10e18f) return 7;
        if (exp < 10e15f) return 6;
        if (exp < 10e12f) return 5;
        if (exp < 10e9f) return 4;
        if (exp < 10e6f) return 3;
        if (exp < 10e3f) return 2;
        return 1;
    }
    #endregion

    public void Initialize()
    {
        goldChangedEvent.Raise(gold.Value);
        expChangedEvent.Raise(exp.Value);
    }
}
