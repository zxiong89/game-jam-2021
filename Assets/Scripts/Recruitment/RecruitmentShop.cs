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

    private const float priceScalingFactor = 1.075f;
    private const float priceSpread = .25f;
    private const float priceMin = 1f - priceSpread;
    private const float priceMax = 1f + priceSpread;

    [SerializeField]
    private IntegerLimits[] ageLimits;

    private void Start()
    {
        var units = new Unit[4];
        int[] fees = new int[4];
        for (int i = 0; i < 4; i++)
        {
            units[i] = testFactory.RandomizeUnit(ageLimits[i]);
            fees[i] = CalcFee(units[i]);
        }

        grid.AddToGrid(units, fees);
    }

    private int CalcFee(Unit unit)
    {
        float startingPrice = (Mathf.Pow(priceScalingFactor, unit.Level) * 100);
        return Mathf.FloorToInt(FloatExtensions.Randomize( priceMin * startingPrice, startingPrice, priceMax * startingPrice));
    }
}
