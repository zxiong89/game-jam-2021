using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WorldMapPanel : MonoBehaviour
{
    [SerializeField]
    private Transform content;

    [SerializeField]
    private WorldMapData data;

    [SerializeField]
    private LocationSummaryDisplay locationSummaryPrefab;

    [SerializeField]
    private ToggleGroup group;

    [SerializeField]
    private IntegerVariable questScoutingTier;

    private void Start()
    {
        foreach (var loc in data.Locations)
        {
            var summary = GameObject.Instantiate<LocationSummaryDisplay>(locationSummaryPrefab, content.transform);
            summary.SetLocationData(loc, questScoutingTier.Value);
            summary.Toggle.group = group;
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(content.gameObject.GetComponent<RectTransform>());
    }

    public LocationData GetSelectedLocation()
    {
        var toggle = ToggleExtensions.FindSelectedToggle(group);
        var summary = toggle.GetComponent<LocationSummaryDisplay>();
        return summary == null ? null : summary.Data;
    }
}
