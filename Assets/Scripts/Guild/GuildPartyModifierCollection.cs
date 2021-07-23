using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Guild/PartyModifierCollection")]
public class GuildPartyModifierCollection : ScriptableObject
{
    public List<GuildPartyModifier> Modifiers = new List<GuildPartyModifier>();
}
