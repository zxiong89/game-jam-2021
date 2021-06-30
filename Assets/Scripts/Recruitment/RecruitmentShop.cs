using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecruitmentShop : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI bannerText;

    [SerializeField]
    private RecruitmentGrid grid;

    [SerializeField]
    private GameObject PrevButton;

    [SerializeField]
    private GameObject NextButton;

    [SerializeField]
    private UnitFactory testFactory;

    [SerializeField]
    private IntegerLimits[] ageLimits;

    [SerializeField]
    private Roster guildRoster;

    [SerializeField]
    private Guild playerGuild;

    private void Start()
    {
        var units = new Unit[4];
        for (int i = 0; i < 4; i++)
        {
            units[i] = testFactory.RandomizeUnit(ageLimits[i]);
        }

        grid.AddToGrid(units);
    }

    public void BidForUnit(RecruitmentData data)
    {
        guildRoster.Units.Add(data.UnitForHire);
        grid.RemoveUnit(data);
    }


}
