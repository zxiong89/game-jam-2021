using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitUIDisplayTest : MonoBehaviour
{
    [SerializeField]
    private UnitFactory factory;

    [SerializeField]
    private GameObject[] testPrefabs;

    [SerializeField]
    private GameObject mainDisplay;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var prefab in testPrefabs) {
            GameObject displayObj = Instantiate(prefab, mainDisplay.transform);
            var display = displayObj.GetComponentInChildren<UnitDisplay>();
            display.DisplayUnit(factory.RandomizeUnit());
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }

}
