using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventLogDisplay : MonoBehaviour
{

    [SerializeField]
    private GameObject EventMessageDisplay;

    private bool isAlternateRow = false;

    private void OnEnable()
    {
        DisplayAllEventMessages();
        EventLog.OnNewMessageAdded += DisplayNewMessage;
    }

    private void OnDisable()
    {
        EventLog.OnNewMessageAdded -= DisplayNewMessage;
    }

    public void DisplayAllEventMessages()
    {
        var currentNode = EventLog.GetMessages().First;
        while(currentNode != null)
        {
            DisplayEventMessage(currentNode);
            currentNode = currentNode.Next;
        }
        RemoveOldMessages();
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }

    public void DisplayNewMessage(LinkedListNode<string> newMessage)
    {
        DisplayEventMessage(newMessage);
        RemoveOldMessages(); 
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }

    private void DisplayEventMessage(LinkedListNode<string> newMessage)
    {
        GameObject messageObj = Instantiate(EventMessageDisplay, this.transform);
        var messageDisplay = messageObj.GetComponent<EventMessageDisplay>();
        messageDisplay.DisplayMessage(newMessage.Value, isAlternateRow);
        isAlternateRow = !isAlternateRow;
    }

    public void RemoveOldMessages()
    {
        if(transform.childCount > EventLog.MESSAGE_LIMIT)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}

