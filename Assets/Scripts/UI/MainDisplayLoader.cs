using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Loads a prefab into the main display.
/// Might want to load by Resource address if references get too memory intensive
/// </summary>
public class MainDisplayLoader : MonoBehaviour
{
    [SerializeField]
    private Globals globals;

    public void LoadMenuOption(GameObject prefab)
    {
        ClearDisplay();
        GameObject displayObj = Instantiate(prefab, transform);
        var display = displayObj.GetComponent<IMainDisplay>();
        display.LoadGlobals(globals);
    }

    private void ClearDisplay()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            var curChild = transform.GetChild(i);
            Destroy(curChild.gameObject);
        }
    }
}