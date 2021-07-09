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
    private int gold;
    public int Gold
    {
        get { return gold; }
        set { 
            gold = value;
            goldChangedEvent.Raise(value);
        }
    }

    public void Initialize()
    {
        Gold = 6000;
    }
}
