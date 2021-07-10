using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Guild")]
public class Guild : ScriptableObject
{
    [SerializeField]
    private IntEvent goldChangedEvent;

    [SerializeField]
    public UnitRoster Roster;

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

    public void Initialize()
    {
        goldChangedEvent.Raise(gold.Value);
    }
}
