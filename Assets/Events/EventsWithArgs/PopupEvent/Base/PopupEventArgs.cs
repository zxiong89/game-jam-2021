using System;
using UnityEngine;

[System.Serializable]
public struct PopupEventArgs
{
    public GameObject Content { get; set; }

    public Action<GameObject> AcceptCallback { get; set; }
}
