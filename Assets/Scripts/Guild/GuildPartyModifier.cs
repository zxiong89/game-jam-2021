using UnityEngine;

[CreateAssetMenu(menuName = "Guild/PartyModifiers")]
public class GuildPartyModifier : ScriptableObject
{
    public string Name;
    [TextArea]
    public string Description;

    public int Cost;
    public int Rental;

    public PartyStats Modifiers;
    public float ExpModifier;
    public float GoldModifier;
}
