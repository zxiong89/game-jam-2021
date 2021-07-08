using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "WorldMap/QuestCollection")]
public class QuestCollection : ScriptableObject
{
    public List<Quest> Quests = new List<Quest>();
    public bool IsQuesting(Party party)
    {
        foreach(var q in Quests)
        {
            if (q.Party == party) return true;
        }
        return false;
    }
}
