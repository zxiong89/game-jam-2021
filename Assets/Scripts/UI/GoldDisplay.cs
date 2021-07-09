using TMPro;
using UnityEngine;

public class GoldDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI goldText;

    public void SetGold(int value)
    {
        goldText.text = value.ToString() + " " + GenericStrings.CurrencySymbol;
    }
}
