using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Recruitment Shop Rosters")]
public class RecruitmentShopRosters : ScriptableObject
{
    public Dictionary<AdventurerTier, List<Unit>> rosters = new Dictionary<AdventurerTier, List<Unit>>()
        {
            { AdventurerTier.Apprentice, new List<Unit>() },
            { AdventurerTier.Experienced, new List<Unit>() },
            { AdventurerTier.Expert, new List<Unit>() },
            { AdventurerTier.Veteran, new List<Unit>() },
        };

    public void AddUnitToTier(Unit unitToAdd, AdventurerTier tier)
    {
        rosters[tier].Add(unitToAdd);
    }
    
    public List<Unit> GetRoster(AdventurerTier tier)
    {
        return rosters[tier];
    }
}
