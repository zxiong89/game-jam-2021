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

    public void SetTrait(string name, string description, bool isPositive)
    {
        traitName.text = name + ":";
        traitName.color = (isPositive) ? new Color(0, .89f, 1f) : new Color(1f, .13f, 0);
        traitDescription.text = description;
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }
}
