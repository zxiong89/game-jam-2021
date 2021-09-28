using UnityEngine;

public class RecruitmentData
{
    private const float PRICE_SCALING_FACTOR = 1.125f;
    private const float PRICE_SPREAD = .2f;
    private const float PRICE_MIN = 1f - PRICE_SPREAD;
    private const float PRICE_MAX = 1f + PRICE_SPREAD;
    private const int WAGE_DIVISOR = 10;

    public Unit UnitForHire { get; set; }
    public int HiringFee { get; set; }
    public int Wage { get { return HiringFee / WAGE_DIVISOR; } }

    public RecruitmentData(Unit unit)
    {
        UnitForHire = unit;
        HiringFee = CalcFee(unit, false);
    }

    private int CalcFee(Unit unit, bool mustIncrease)
    {
        float startingPrice = (Mathf.Pow(PRICE_SCALING_FACTOR, unit.Level) * 30);
        float minimumPrice = (!mustIncrease) ? PRICE_MIN * startingPrice : Mathf.Max(PRICE_MIN * startingPrice, HiringFee + WAGE_DIVISOR);
        float maximumPrice = (!mustIncrease) ? PRICE_MAX * startingPrice : Mathf.Max(PRICE_MAX * startingPrice, HiringFee + WAGE_DIVISOR);
        startingPrice = minimumPrice + (maximumPrice - minimumPrice) / 2;
        int hiringPrice = Mathf.FloorToInt(FloatExtensions.Randomize(minimumPrice, maximumPrice, startingPrice));
        if (unit.IsApprentice()) hiringPrice /= 2;
        return hiringPrice;
    }

    public void UpdateFee(Unit unit, bool mustIncrease)
    {
        HiringFee = CalcFee(unit, mustIncrease);
    }

    public bool OfferContract(UnitContract contract)
    {
        if (contract.TotalWorth < Fee) return false;
        return true;
    }
}
