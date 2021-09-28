using System;

[System.Serializable]
public struct SubStatsDisplay 
{
    public LabelValueDisplay[] StatDisplay;

    public void SetActive(bool value)
    {
        foreach (var display in StatDisplay)
        {
            display.gameObject.SetActive(value);
        }
    }
}
