using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI goldText;

    public void SetGold(int value)
    {
        goldText.text = value.ToString() + " " + GenericStrings.CurrencySymbol;
    }
}
