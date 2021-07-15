using System;
using System.Collections.Generic;

public static class EventLog
{
    public const int MESSAGE_LIMIT = 50;

    private static LinkedList<string> messages = new LinkedList<string>();

    public static event Action<LinkedListNode<string>> OnNewMessageAdded;

    public static event Action<bool> NotifyUnreadMessages;

    public static void AddMessage(string message)
    {
        messages.AddLast(message);
        while(messages.Count > MESSAGE_LIMIT)
        {
            messages.RemoveFirst();
        }

        if(OnNewMessageAdded != null)
        {
            OnNewMessageAdded.Invoke(messages.Last);
            NotifyUnreadMessages?.Invoke(false);
        }
        else
        {
            NotifyUnreadMessages?.Invoke(true);
        }
    }

    public static LinkedList<string> GetMessages()
    {
        NotifyUnreadMessages.Invoke(false);
        return messages;
    }
}