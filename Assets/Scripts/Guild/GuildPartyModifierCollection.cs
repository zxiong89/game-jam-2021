using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Guild/PartyModifierCollection")]
public class GuildPartyModifierCollection : ScriptableObject
{
    public List<GuildPartyModifier> Modifiers = new List<GuildPartyModifier>();

    /// <summary>
    /// Calculate and flatten the current active modifiers (if any)
    /// </summary>
    /// <returns></returns>
    public GuildPartyModifier CalcModifiers()
    {
        var totalMod = new PartyStats()
        {
            PhyAtk = 1,
            MagAtk = 1,
            Def = 1,
            AtkSup = 1,
            DefSup = 1
        };
        var totalExpMod = 1f;
        var totalGoldMod = 1f;

        foreach (var mod in Modifiers)
        {
            totalMod += mod.Modifiers;
            totalExpMod += mod.ExpModifier;
            totalGoldMod += mod.GoldModifier;
        }

        return new GuildPartyModifier()
        {
            Name = "Calculated Guild Party Modifiers",
            Modifiers = totalMod,
            ExpModifier = totalExpMod,
            GoldModifier = totalGoldMod
        };
    }
}
