using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecruitmentData
{
    private const float PRICE_SCALING_FACTOR = 1.075f;
    private const float PRICE_SPREAD = .25f;
    private const float PRICE_MIN = 1f - PRICE_SPREAD;
    private const float PRICE_MAX = 1f + PRICE_SPREAD;

    public Unit UnitForHire { get; set; }
    public int Fee { get; set; }

    public RecruitmentData(Unit unit)
    {
        UnitForHire = unit;
        Fee = CalcFee(unit);
    }

    private int CalcFee(Unit unit)
    {
        float startingPrice = (Mathf.Pow(PRICE_SCALING_FACTOR, unit.Level) * 100);
        return Mathf.FloorToInt(FloatExtensions.Randomize(PRICE_MIN * startingPrice, startingPrice, PRICE_MAX * startingPrice));
    }

}
