﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameEvent))]
public class GameEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GameEvent gameEvent = (GameEvent) target;
        if (!gameEvent)
        {
            return;
        }

        if (GUILayout.Button("Raise Event"))
        {
            gameEvent.Raise();
        }
    }
}
