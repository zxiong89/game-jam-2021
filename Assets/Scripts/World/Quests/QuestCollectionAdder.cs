using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCollectionAdder : MonoBehaviour
{
    [SerializeField]
    private QuestCollection questCollection;

    public void AddToQuest(PartyEventArgs args)
    {
        questCollection.Quests.Add(new Quest(args.Party, args.Location));
    }
}
