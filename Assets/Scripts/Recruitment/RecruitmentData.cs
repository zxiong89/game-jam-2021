using UnityEngine;

public class RecruitmentData
{
    private const float PRICE_SCALING_FACTOR = 1.125f;
    private const float PRICE_SPREAD = .2f;
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
        float startingPrice = (Mathf.Pow(PRICE_SCALING_FACTOR, unit.Level) * 30);
        float minimumPrice = PRICE_MIN * startingPrice;
        float maximumPrice = PRICE_MAX * startingPrice;
        int hiringPrice = Mathf.FloorToInt(FloatExtensions.Randomize(minimumPrice, maximumPrice, startingPrice));
        if (unit.IsApprentice()) hiringPrice /= 2;
        return hiringPrice;
    }

    public void UpdateFee()
    {
        Fee = CalcFee(UnitForHire);
    }

    public bool OfferContract(UnitContract contract)
    {
        if (contract.TotalWorth < Fee) return false;
        return true;
    }
}
