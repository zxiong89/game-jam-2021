using System.Collections.Generic;
using UnityEngine;

public class RecruitmentGrid : MonoBehaviour
{
    [SerializeField]
    private RecruitmentShopRosters shopRosters;

    [SerializeField]
    private GameObject resumePrefab;

    private AdventurerTier currentTier;

    private UnitFactory unitFactory;

    public void Initialize(UnitFactory newUnitFactory)
    {
        unitFactory = newUnitFactory;
    }

    public void LoadRoster(AdventurerTier tier)
    {
        shopRosters.RefreshRosters(unitFactory);
        currentTier = tier;
        RefreshGridDisplay();
    }

    private void AddResumeToGrid(Unit unit)
    {
        GameObject resumeObj = Instantiate(resumePrefab, this.transform);
        var resume = resumeObj.GetComponent<UnitResumeDisplay>();
        var data = RecruitmentDataFactory.GetOrAddData(unit);
        resume.SetResume(data);
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
