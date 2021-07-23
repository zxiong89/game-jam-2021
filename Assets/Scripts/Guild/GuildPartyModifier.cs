using UnityEngine;

[CreateAssetMenu(menuName = "Guild/PartyModifiers")]
public class GuildPartyModifier : ScriptableObject
{
    public string Name;
    public PartyStats Modifiers;
    public float ExpModifier;
    public float GoldModifier;
}
