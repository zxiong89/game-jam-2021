using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Custom Inspector to be able to fire events directly.
/// You may define one of these per event argument type.
/// Don't forget to define the script as a custom inspector with the class attribute:
/// [CustomEditor(typeof(BaseGameEvent))]
/// </summary>
/// <typeparam name="T">The event argument</typeparam>
public abstract class BaseGameEventEditor<T> : Editor
{
    /// <summary>
    /// Overridden Inspector GUI display and logic
    /// </summary>
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        BaseGameEvent<T> gameEvent = (BaseGameEvent<T>)target;
        if (!gameEvent)
        {
            return;
        }

        DisplayEditorFields();

        if (CanDisplayButton())
        {
            if (GUILayout.Button("Raise Event"))
            {
                T args = CreateEventArgs();
                gameEvent.Raise(args);
            }
        }
    }

    /// <summary>
    /// Implement which fields can be set and used for the "Raise Event" button.
    /// Create a private field and add it to the GUI with (T)EditorGUILayout.ObjectField(fieldName, typeof(T), allowSceneObjects: true)
    /// E.g. sprite = (Sprite)EditorGUILayout.ObjectField(sprite, typeof(Sprite), allowSceneObjects: true);
    /// </summary>
    protected abstract void DisplayEditorFields();

    /// <summary>
    /// Create and return the event arguments to be passed when the "Raise Event" button 
    /// </summary>
    /// <returns></returns>
    protected abstract T CreateEventArgs();

    /// <summary>
    /// Override this to choose when to disable the "Raise Event" button
    /// </summary>
    /// <returns>True if the Raise Event button can be displayed and clicked</returns>
    protected virtual bool CanDisplayButton()
    {
        return true;
    }
}
