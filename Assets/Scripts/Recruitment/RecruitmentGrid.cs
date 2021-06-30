﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecruitmentGrid : MonoBehaviour
{
    [SerializeField]
    private UnitFactory testFactory;

    [SerializeField]
    private IntegerLimits[] ageLimits;

    [SerializeField]
    private RecruitmentShopRosters shopRosters;

    [SerializeField]
    private GameObject resumePrefab;

    [SerializeField]
    private int GRID_LIMIT = 4;

    private List<RecruitmentData> potentialRecruits = new List<RecruitmentData>();

    private int currentTier;

    public void LoadRoster(int tier)
    {
        currentTier = tier;
        List<Unit> roster = shopRosters.tierRosters[tier];
        for (int i = 0; i < GRID_LIMIT; i++)
        {
            Unit unitToAdd;
            if(i < roster.Count)
            {
                unitToAdd = roster[i];
            }
            else
            {
                unitToAdd = AddNewUnitToRoster(roster, tier);
            }
            AddResumeToGrid(unitToAdd, i);
        }
    }

    private Unit AddNewUnitToRoster(List<Unit> roster, int tier)
    {
        var newUnit = testFactory.RandomizeUnit(ageLimits[tier]);
        roster.Add(newUnit);
        return newUnit;
    }

    private void AddResumeToGrid(Unit unit, int index)
    {
        GameObject resumeObj;
        if(index < transform.childCount)
        {
            resumeObj = transform.GetChild(index).gameObject;
        }
        else
        {
            resumeObj = Instantiate(resumePrefab, this.transform);
        }
        var resume = resumeObj.GetComponent<UnitResumeDisplay>();
        resume.SetResume(new RecruitmentData(unit));
    }

    public void AddToGrid(Unit[] units)
    {       
        ClearGrid();
        for (int i = 0; i < units.Length; i++)
        {
            var data = new RecruitmentData(units[i]);
            potentialRecruits.Add(data);

            var newResumeObj = Instantiate(resumePrefab, this.transform);
            var resumeDisplay = newResumeObj.GetComponent<UnitResumeDisplay>();
            resumeDisplay.SetResume(data);
        }
    }

    public void ClearGrid()
    {
        for (int i = transform.childCount; i > 0; i--)
        {
            Destroy(transform.GetChild(i - 1).gameObject);
        }
    }

    public void RemoveUnit(RecruitmentData removalData)
    {
        int index = potentialRecruits.FindIndex((data) => data == removalData);
        Destroy(transform.GetChild(index).gameObject);
        potentialRecruits.RemoveAt(index);
    }
}