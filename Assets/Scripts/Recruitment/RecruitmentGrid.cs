using System.Collections.Generic;
using UnityEngine;

public class RecruitmentGrid : MonoBehaviour
{
    [SerializeField]
    private IntegerLimits[] ageLimits;

    [SerializeField]
    private RecruitmentShopRosters shopRosters;

    [SerializeField]
    private GameObject resumePrefab;

    [SerializeField]
    private int GRID_LIMIT = 4;

    private AdventurerTier currentTier;

    private UnitFactory unitFactory;

    public void Initialize(UnitFactory newUnitFactory)
    {
        unitFactory = newUnitFactory;
    }

    public void LoadRoster(AdventurerTier tier)
    {
        if (true)
        {
            shopRosters.RefreshRosters(unitFactory);
        }
        UnitRoster roster = shopRosters.GetRoster(tier);
        //for (int i = 0; i < GRID_LIMIT; i++)
        //{
        //    Unit unitToAdd;
        //    if(i < roster.Count)
        //    {
        //        unitToAdd = roster[i];
        //    }
        //    else
        //    {
        //        unitToAdd = AddNewUnitToRoster(roster, tier);
        //    }
        //}
        currentTier = tier;
        RefreshGridDisplay();
    }

    private Unit AddNewUnitToRoster(UnitRoster roster, AdventurerTier tier)
    {
        var newUnit = unitFactory.RandomizeUnit(ageLimits[(int)tier]);
        roster.Add(newUnit);
        return newUnit;
    }

    private void AddResumeToGrid(Unit unit)
    {
        GameObject resumeObj = Instantiate(resumePrefab, this.transform);
        var resume = resumeObj.GetComponent<UnitResumeDisplay>();
        resume.SetResume(unit.RecruitmentData);
    }

    public void RefreshGridDisplay()
    {
        ClearGrid();
        foreach(var unit in shopRosters.GetRoster(currentTier))
        {
            AddResumeToGrid(unit);
        }
    }

    public void ClearGrid()
    {
        for (int i = transform.childCount; i > 0; i--)
        {
            Destroy(transform.GetChild(i - 1).gameObject);
        }
    }
}
