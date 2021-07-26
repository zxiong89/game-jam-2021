using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GuildShopPanel : MonoBehaviour
{
    [SerializeField]
    private GuildPartyModifierCollection activeList;

    [SerializeField]
    private GuildPartyModifierCollection availableList;

    [SerializeField]
    private GuildPartyModifierDisplay modifierDisplayPrefab;

    [SerializeField]
    private Guild playerGuild;
    public Guild PlayerGuild
    {
        get => playerGuild;
    }

    private List<GuildPartyModifier> modifiersToBuy;

    private void Start()
    {
        modifiersToBuy = availableList.Modifiers.Where(mod => !activeList.Modifiers.Contains(mod)).ToList();

        var transform = this.transform;

        foreach (var mod in modifiersToBuy) 
        {
            var display = GameObject.Instantiate<GuildPartyModifierDisplay>(modifierDisplayPrefab, transform);
            display.DisplayGuildPartyModifier(mod, this);
        }
    }

    public void BuyModifier(GuildPartyModifier mod)
    {

    }

    public void RentModifier(GuildPartyModifier mod)
    {

    }
}
