using TMPro;
using UnityEngine;

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
    private Guild playerGuild;

    private int curPage = 0;

    private void Start()
    {
        LoadPage(0);
    }

    public void LoadPage(int pageNumber)
    {
        AdventurerTier tier = AdventurerTierHelpers.Convert(pageNumber);
        grid.LoadRoster(tier);
        UpdateBanner(tier);
        UpdatePageButtons();
    }

    public void ChangePage(int difference)
    {
        curPage += difference;
        LoadPage(curPage);
    }

    private void UpdateBanner(AdventurerTier tier)
    {
        bannerText.text = tier.ToString() + " Adventurers";
    }

    private void UpdatePageButtons()
    {
        PrevButton.gameObject.SetActive(curPage > 0);
        NextButton.gameObject.SetActive(curPage < 3);
    }

    public void BidForUnit(RecruitmentData data)
    {
        if(playerGuild.Gold <= data.Fee)
        {
            Debug.Log("Ya ain't got enough dough");
            //Tell player they don't have enough gold.
        }
        else
        {
            playerGuild.Gold -= data.Fee;
            playerGuild.Roster.Add(data.UnitForHire);
            grid.RemoveUnit(data);
        }
    }
}
