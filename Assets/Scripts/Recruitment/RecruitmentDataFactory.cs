using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RecruitmentDataFactory
{
    private static readonly Dictionary<Unit, RecruitmentData> Cache = new Dictionary<Unit, RecruitmentData>();

    public static RecruitmentData GetOrAddData(Unit unit)
    {
        if (Cache.ContainsKey(unit)) return Cache[unit];

        var data = new RecruitmentData(unit);
        Cache.Add(unit, data);

        return data;
    }

    public static void Clear()
    {
        Cache.Clear();
    }

    public static bool OfferContract(Unit unit, UnitContract contract)
    {
        var data = GetOrAddData(unit);

        if (!data.OfferContract(contract)) return false;

        unit.Contract = contract;
        return true;
    }
}
