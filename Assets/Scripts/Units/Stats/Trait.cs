using UnityEngine;

public class Trait
{

    public string Name { get; set; }
    public string Description { get; set; }
    public Color Color { get; set; }
    public int[] StatModifiers { get; set; }
    public Trait() { }

    public Trait(TraitTemplate template)
    {
        Name = template.name;
        Description = template.Description;
        Color = template.Color;
        StatModifiers = new int[template.StatModifiers.Length];
        for (int i = 0; i < template.StatModifiers.Length; i++)
        {
            StatModifiers[i] = template.StatModifiers[i];
        }
    }
}
