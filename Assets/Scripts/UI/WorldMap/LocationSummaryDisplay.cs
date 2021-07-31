using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LocationSummaryDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameDisplay;

    [SerializeField]
    private TextMeshProUGUI description;

    public Toggle Toggle;

    public LocationData Data { get; private set; }

    public void SetLocationData(LocationData data)
    {
        this.Data = data;
        DisplayLocationData();
    }

    public void DisplayLocationData()
    {
        nameDisplay.text = Data.Name;
        description.text = Data.ScoutLocation(1);
        LayoutRebuilder.ForceRebuildLayoutImmediate(this.GetComponent<RectTransform>());
    }
}
