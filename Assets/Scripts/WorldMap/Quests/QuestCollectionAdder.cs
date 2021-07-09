using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCollectionAdder : MonoBehaviour
{
    [SerializeField]
    private QuestCollection activeQuests;

    public void AddToQuest(PartyEventArgs args)
    {
        activeQuests.Quests.Add(new Quest(args.Party, args.Location));
    }
}
