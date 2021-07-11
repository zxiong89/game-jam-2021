using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "WorldMap/QuestCollection")]
[System.Serializable]
public class QuestCollection : ScriptableObject
{
    public List<Quest> Quests = new List<Quest>();

    public void Clear() => Quests.Clear();
}
