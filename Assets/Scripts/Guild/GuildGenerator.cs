using UnityEngine;

public class GuildGenerator : MonoBehaviour
{
    [SerializeField]
    private Guild guild;

    [SerializeField]
    private UnitFactory factory;

    public void GenerateGuild()
    {
        for (var i = 0; i < 10; i++)
        {
            guild.Roster.Add(factory.RandomizeUnit());
        }
    }
}
