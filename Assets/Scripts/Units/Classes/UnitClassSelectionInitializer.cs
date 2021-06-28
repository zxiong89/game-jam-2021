using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UnitClassSelectionInitializer : MonoBehaviour
{
    public string DirectoryPath;
    public List<UnitClassSelectionData> Selections;

    private void Awake()
    {
        writeSelections();
    }

    private void loadSelections()
    {
        if (Selections == null) return;
        foreach (var s in Selections)
        {
            Resources.Load<TextAsset>(Path.Combine(DirectoryPath, s.Filename));
        }
        Resources.UnloadUnusedAssets();
    }

    private void writeSelections()
    {
        if (Selections == null) return;

        foreach (var s in Selections)
        {
            Debug.Log(JsonUtility.ToJson(s.Selection.Classes));
        }
    }
}
