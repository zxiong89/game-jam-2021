using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Guild/PartyModifierCollection")]
public class GuildPartyModifierCollection : ScriptableObject
{
    public List<GuildPartyModifier> Modifiers = new List<GuildPartyModifier>();

    /// <summary>
    /// Flatten an array of collections of guild party modifiers. Summation from 1.
    /// </summary>
    /// <param name="collections"></param>
    /// <returns></returns>
    public static GuildPartyModifier CalcModifiers(GuildPartyModifierCollection[] collections)
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

        foreach (var col in collections)
        {
            var result = col.calcModifier();
            totalMod += result.Modifiers;
            totalExpMod += result.ExpModifier;
            totalGoldMod += result.GoldModifier;
        }

        return new GuildPartyModifier()
        {
            Modifiers = totalMod,
            ExpModifier = totalExpMod,
            GoldModifier = totalGoldMod
        };
    }

    /// <summary>
    /// Flatten this collection of guild party modifiers. This is a summation from 0.
    /// </summary>
    /// <returns></returns>
    private GuildPartyModifier calcModifier()
    {
        var totalMod = new PartyStats()
        {
            PhyAtk = 0,
            MagAtk = 0,
            Def = 0,
            AtkSup = 0,
            DefSup = 0
        };
        var totalExpMod = 0f;
        var totalGoldMod = 0f;

        foreach (var mod in Modifiers)
        {
            totalMod += mod.Modifiers;
            totalExpMod += mod.ExpModifier;
            totalGoldMod += mod.GoldModifier;
        }

        return new GuildPartyModifier()
        {
            Modifiers = totalMod,
            ExpModifier = totalExpMod,
            GoldModifier = totalGoldMod
        };
    }
}
