using UnityEngine;
using UnityEngine.UI;

public class PartyPanel : MonoBehaviour
{
    [SerializeField]
    private PartySummaryDisplay partySummaryPrefab;

    [SerializeField]
    private PartyData[] parties;

    private void Start()
    {
        var transform = this.transform;
        foreach (var p in parties)
        {
            var summary = GameObject.Instantiate<PartySummaryDisplay>(partySummaryPrefab, transform);
            summary.DisplayParty(p.Party);
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }
}
