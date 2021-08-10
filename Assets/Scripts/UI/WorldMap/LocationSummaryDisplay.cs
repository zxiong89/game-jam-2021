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

    public void SetLocationData(LocationData data, int tier)
    {
        this.Data = data;
        DisplayLocationData(tier);
    }

    public void DisplayLocationData(int tier)
    {
        nameDisplay.text = Data.Name;
        description.text = Data.ScoutLocation(tier);
        LayoutRebuilder.ForceRebuildLayoutImmediate(this.GetComponent<RectTransform>());
    }
}
