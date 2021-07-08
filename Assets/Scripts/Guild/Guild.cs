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

    public void Initialize()
    {
        gold = 15000;
    }

    public int Gold
    {
        get { return gold; }
        set { 
            gold = value;
            goldChangedEvent.Raise(value);
        }
    }


}
