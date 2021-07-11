using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Units/Trait")]
public class TraitTemplate : ScriptableObject
{
    public string Description
    {
        get { return CreateDescription(); }
    }

    [SerializeField]
    private Color color;

    public Color Color
    {
        get { return color; }
    }

    [SerializeField]
    private int[] statModifiers;

    public int[] StatModifiers
    {
        get { return statModifiers; }
    }

    private string CreateDescription()
    {
        var attributes = new List<string>();
        for (int i = 0; i < 5; i++)
        {
            int curMod = StatModifiers[i];
            if(curMod != 0)
            {
                string partial = (curMod > 0) ? "+" : "";
                partial += curMod;
                partial += " " + GetStatName(i);
                attributes.Add(partial);
            }
        }
        return string.Join(", ", attributes.ToArray());
    }

    private string GetStatName(int index)
    {
        switch (index)
        {
            case 0:
                return "Str";
            case 1:
                return "Dex";
            case 2:
                return "Con";
            case 3:
                return "Int";
            default:
                return "Wis";
        }
    }
}
