using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TraitDisplay : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI traitName;

    [SerializeField]
    private TextMeshProUGUI traitDescription;

    public void SetTrait(string name, string description, Color textColor)
    {
        traitName.text = name + ":";
        traitName.color = textColor;
        traitDescription.text = description;
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }
}
