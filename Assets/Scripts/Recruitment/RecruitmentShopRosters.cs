using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Recruitment Shop Rosters")]
public class RecruitmentShopRosters : ScriptableObject
{
    [SerializeField]
    private UnitRoster[] shopRosters;

    [SerializeField]
    private UnitRoster freeAgentRoster;

    [SerializeField]
    private IntegerLimits[] ageLimits;

    [SerializeField]
    private int GRID_LIMIT = 4;

    private float timeSinceLastRefresh = 0;

    private bool unseenUpdates = true;

    public void Initialize()
    {
        timeSinceLastRefresh = 0;
    }

    public bool CheckHasUpdated()
    {
        if (unseenUpdates) return false;
        if (ShopHasUpdated())
        {
            unseenUpdates = true;
        }
        return unseenUpdates;
    }

    private bool ShopHasUpdated()
    {
        return Time.time - timeSinceLastRefresh > 60;
    }

    public void AddUnitToTier(Unit unitToAdd, AdventurerTier tier)
    {
        shopRosters[(int)tier].Add(unitToAdd);
    }
    
    public UnitRoster GetRoster(AdventurerTier tier)
    {
        return shopRosters[(int)tier];
    }

    private IntegerLimits GetAgeLimits(AdventurerTier tier)
    {
        return ageLimits[(int)tier];
    }

    public void RefreshRosters(UnitFactory factory)
    {
        if (timeSinceLastRefresh == 0 || ShopHasUpdated())
        {
            FreeUnits();
            foreach (var tier in AdventurerTierHelpers.GetValues())
            {
                List<Unit> unitsInTier = FindUnitsInTier(freeAgentRoster, tier);
                AddUnitsToShopRoster(tier, unitsInTier, factory);
            }
            timeSinceLastRefresh = Time.time;
            unseenUpdates = false;
        }
    }

    private void FreeUnits()
    {
        foreach (var roster in shopRosters)
        {
            for (int i = roster.Count - 1; i >= 0; i--)
            {
                Unit unitToFree = roster[i];
                roster.RemoveAt(i);
                freeAgentRoster.Add(unitToFree);
            }
        }
    }

    private List<Unit> FindUnitsInTier(UnitRoster freeAgentRoster, AdventurerTier tier)
    {
        IntegerLimits ageLimit = ageLimits[(int)tier];
        return freeAgentRoster.FindAll(
            (unit) => {
            return unit.Age > ageLimit.Min && unit.Age < ageLimit.Max;
        });
    }

    private void AddUnitsToShopRoster(AdventurerTier tier, List<Unit> unitsInTier, UnitFactory factory)
    {
        var newRoster = new List<Unit>();
        AddExistingUnits(unitsInTier, newRoster);
        AddNewUnits(tier, factory, newRoster);

        foreach (var unit in newRoster)
        {
            GetRoster(tier).Add(unit);
        }
    }

    private void AddExistingUnits(List<Unit> unitsInTier, List<Unit> newRoster)
    {
        for (int i = 0; i < GRID_LIMIT / 2 && i < unitsInTier.Count; i++)
        {
            int swapIndex = UnityEngine.Random.Range(i, unitsInTier.Count);
            Unit temp = unitsInTier[i];
            unitsInTier[i] = unitsInTier[swapIndex];
            unitsInTier[swapIndex] = temp;
            newRoster.Add(unitsInTier[i]);
        }
    }

    private void AddNewUnits(AdventurerTier tier, UnitFactory factory, List<Unit> newRoster)
    {
        for (int i = newRoster.Count; i < GRID_LIMIT; i++)
        {
            newRoster.Add(factory.RandomizeUnit(GetAgeLimits(tier)));
        }
    }
}
