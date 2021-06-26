using System;

public static class FloatExtensions
{
    /// <summary>
    /// Returns the average of a number of float variables
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public static float Average(params float[] args)
    {
        double sum = 0;
        foreach (var f in args)
        {
            sum += f;
        }
        return (float)(sum / args.Length);
    }

    /// <summary>
    /// Using a guassian distrubution, get a random between the range.
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static float Randomize(float min, float max)
    {
        float mean = (min + max) / 2f;
        float stdDev = (max - min) / 2f;
        Random rand = new Random(); 
        double u1 = 1.0 - rand.NextDouble(); 
        double u2 = 1.0 - rand.NextDouble();
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                     Math.Sin(2.0 * Math.PI * u2); 
        double randNormal =
                     mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)

        return (float)randNormal;
    }
}
