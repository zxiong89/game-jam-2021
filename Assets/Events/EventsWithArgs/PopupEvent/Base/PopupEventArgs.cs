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
    /// <summary>
    /// Fill this in for a basic text popup
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Provide a gameobject for popups with custom layouts. The Text property
    /// is ignored if this is provided
    /// </summary>
    public GameObject Content { get; set; }

    public string CloseTextOverride { get; set; }

    public string AcceptTextOverride { get; set; }

    public Action<GameObject> AcceptCallback { get; set; }

    public Vector2? AcceptButtonSize { get; set; }

    public Action<GameObject> CancelCallback { get; set; }

    public Vector2? CancelButtonSize { get; set; }

    public bool PausesTime { get; set; }
}