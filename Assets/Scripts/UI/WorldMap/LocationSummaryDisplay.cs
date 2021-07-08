using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LocationSummaryDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameDisplay;

    [SerializeField]
    private TextMeshProUGUI description;

    private LocationData data;

    public void SetLocationData(LocationData data)
    {
        this.data = data;
        DisplayLocationData();
    }

    public void DisplayLocationData()
    {
        nameDisplay.text = data.Name;
        description.text = data.Description;
        LayoutRebuilder.ForceRebuildLayoutImmediate(this.GetComponent<RectTransform>());
    }

    public void AssignOrRecallParties()
    {

    }
}
