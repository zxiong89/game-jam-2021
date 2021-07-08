using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMapPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject content;

    [SerializeField]
    private WorldMapData data;

    [SerializeField]
    private LocationSummaryDisplay locationSummaryPrefab;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var l in data.Locations)
        {

        }
    }

}
