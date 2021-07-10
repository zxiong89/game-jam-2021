using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "WorldMap/ExplorationType")]
public class ExplorationType : ScriptableObject
{
    public FloatRange Time;
    public IntegerRange Exp;
    public IntegerRange Gold;
}
