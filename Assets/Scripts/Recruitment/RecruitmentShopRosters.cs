using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Recruitment Shop Rosters")]
public class RecruitmentShopRosters : ScriptableObject
{
    public List<Unit>[] tierRosters = new List<Unit>[4] { new List<Unit>(), new List<Unit>(), new List<Unit>(), new List<Unit>() };

    public void AddUnitToTier(Unit unitToAdd, int tier)
    {
        tierRosters[tier].Add(unitToAdd);
    }

    public void AddApprentice(Unit unitToAdd) => AddUnitToTier(unitToAdd, 0);
    public void AddExperienced(Unit unitToAdd) => AddUnitToTier(unitToAdd, 1);
    public void addExpert(Unit unitToAdd) => AddUnitToTier(unitToAdd, 2);
    public void addVeteran(Unit unitToAdd) => AddUnitToTier(unitToAdd, 3);
}
