using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Recruitment Shop Rosters")]
public class RecruitmentShopRosters : ScriptableObject
{
    [SerializeField]
    private UnitRoster[] shopRosters;
  
    public void AddUnitToTier(Unit unitToAdd, AdventurerTier tier)
    {
        shopRosters[(int)tier].Add(unitToAdd);
    }
    
    public UnitRoster GetRoster(AdventurerTier tier)
    {
        return shopRosters[(int)tier];
    }
}
