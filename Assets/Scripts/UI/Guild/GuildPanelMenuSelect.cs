using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuildPanelMenuSelect : MonoBehaviour
{
    [SerializeField]
    private GameObject guildInfoPanelPrefab;

    [SerializeField]
    private GameObject guildShopPanelPrefab;

    public void OpenGuildInfo()
    {
        if (guildInfoPanelPrefab.activeInHierarchy) return;
        guildInfoPanelPrefab.SetActive(true);
        guildShopPanelPrefab.SetActive(false);
    }

    public void OpenGuildShop()
    {
        if (guildShopPanelPrefab.activeInHierarchy) return;
        guildShopPanelPrefab.SetActive(true);
        guildInfoPanelPrefab.SetActive(false);
    }
}
