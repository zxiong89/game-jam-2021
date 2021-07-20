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

    public void Initialize()
    {
        goldChangedEvent.Raise(gold.Value);
    }
}
