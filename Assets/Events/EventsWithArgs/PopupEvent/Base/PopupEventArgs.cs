using System;
using UnityEngine;

/// <summary>
/// The arguments for creating a popup.
/// By default, the popup is a "Close" popup.
/// Provide and AcceptCallback for a "Accept/Cancel" popup.
/// </summary>
[System.Serializable]
public struct PopupEventArgs
{
    public GameObject Content { get; set; }

    public string CloseTextOverride { get; set; }

    public string AcceptTextOverride { get; set; }

    public Action<GameObject> AcceptCallback { get; set; }

    public Action<GameObject> CancelCallback { get; set; }
}
