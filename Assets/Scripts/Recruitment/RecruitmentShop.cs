using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecruitmentShop : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI bannerText;

    [SerializeField]
    private RecruitmentGrid grid;

    [SerializeField]
    private GameObject PrevButton;

    [SerializeField]
    private GameObject NextButton;

    [SerializeField]
    private UnitFactory testFactory;

    private void Start()
    {
        var units = new Unit[4];
        for (int i = 0; i < 4; i++)
        {
            units[i] = testFactory.RandomizeUnit();
        }
        int[] fees = new int[4] { 200, 200, 200, 200 };

        grid.AddToGrid(units, fees);
    }
}
