﻿using UnityEngine;

[System.Serializable]
public struct ExplorationStats
{
    public string Description;
    public float Time;
    public float Exp;
    public float Gold;

    public static ExplorationStats Create(ExplorationData data)
    {
        if (data.Description == null || data.Description.Length < 0)
        {
            Debug.LogError("Empty descriptions for a given exploration data");
            return new ExplorationStats();
        }

        int i = Random.Range(0, data.Description.Length - 1);
        var type = data.Type;
        return new ExplorationStats()
        {
            Description = data.Description[i],
            Time = FloatRange.Random(type.Time),
            Exp = FloatRange.Random(type.Exp),
            Gold = FloatRange.Random(type.Gold)
        };
    }
}
