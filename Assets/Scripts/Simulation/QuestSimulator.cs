using System.Collections.Generic;
using UnityEngine;

public class QuestSimulator 
{
    public void UpdateQuests(List<Quest> quests)
    {
        foreach (var q in quests) 
        { 
            q.Adventure(); 
        }
    }
}
