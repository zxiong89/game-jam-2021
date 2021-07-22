using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuildStatusDisplay : MonoBehaviour
{
    [SerializeField]
    private Guild playerGuild;

    [SerializeField]
    private LabelValueDisplay levelDisplay;

    [SerializeField]
    private GuildExpDisplay expDisplay;

    private void Start()
    {
        levelDisplay.SetValue(playerGuild.Level);
        expDisplay.SetValue(playerGuild.Exp);
        rebuildLayout();
    }

    public void SetLevelDisplay(int level)
    {
        levelDisplay.SetValue(playerGuild.Level);
        rebuildLayout();
    }

    public void SetExpDisplay(float exp)
    {
        expDisplay.SetValue(playerGuild.Exp);
        rebuildLayout();
    }

    private void rebuildLayout() => 
        LayoutRebuilder.ForceRebuildLayoutImmediate(this.GetComponent<RectTransform>());
}
