using System;

public static class FloatExtensions
{
    private readonly static Random rand = new Random();
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
    /// Using a normal distrubution, get a random between the range.
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static float Randomize(float min, float max, float mean)
    {
        var guassian = NextGaussian();
        var variance = guassian < 0.0 ? (min - mean) : (max - mean);
        return (float)(mean + variance * guassian);
    }

    /// <summary>
    /// Return a number between -1 to 1, inclusive, in a normal distrubution
    /// Based on https://stackoverflow.com/questions/218060/random-gaussian-variables
    /// </summary>
    /// <param name="mean"></param>
    /// <param name="stdDev"> Standard deviation. </param>
    /// <returns></returns>
    public static double NextGaussian(float stdDev = 1/3f)
    {
        double randNormal;
        do
        {
            randNormal = nextGaussian(rand, stdDev);
        } while (randNormal < -1 || randNormal > 1);

        return randNormal;
    }

    /// <summary>
    /// Return a number based on a normal distrubution 
    /// </summary>
    /// <param name="rand"></param>
    /// <param name="stdDev"></param>
    /// <returns></returns>
    private static double nextGaussian(Random rand, float stdDev)
    {
        double u1 = rand.NextDouble();
        double u2 = rand.NextDouble();
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
        return stdDev * randStdNormal;
    }

    public static string ToString(float f) => f.ToString("N0");
}
