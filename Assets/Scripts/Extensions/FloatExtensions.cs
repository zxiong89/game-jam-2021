using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FloatExtensions
{
    public static float Average(params float[] args)
    {
        double sum = 0;
        foreach (var f in args)
        {
            sum += f;
        }
        return (float)(sum / args.Length);
    }
}
