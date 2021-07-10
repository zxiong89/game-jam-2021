using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventLog
{
    public const int MESSAGE_LIMIT = 50;

    private static LinkedList<string> messages = new LinkedList<string>();

    public static event Action<LinkedListNode<string>> OnNewMessageAdded;

    public static void AddMessage(string message)
    {
        messages.AddLast(message);
        while(messages.Count > MESSAGE_LIMIT)
        {
            messages.RemoveFirst();
        }
        OnNewMessageAdded?.Invoke(messages.Last);
    }

    public static LinkedList<string> GetMessages()
    {
        return messages;
    }
}
