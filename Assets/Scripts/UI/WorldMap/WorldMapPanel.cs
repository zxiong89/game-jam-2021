using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldMapPanel : MonoBehaviour
{
    [SerializeField]
    private Transform content;

    [SerializeField]
    private WorldMapData data;

    [SerializeField]
    private LocationSummaryDisplay locationSummaryPrefab;

    private void Start()
    {
        foreach (var loc in data.Locations)
        {
            var display = GameObject.Instantiate<LocationSummaryDisplay>(locationSummaryPrefab, content.transform);
            display.SetLocationData(loc);
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(content.gameObject.GetComponent<RectTransform>());
    }

}
