using UnityEngine;

public static class ErisMath
{
    /// <summary>
    /// Normalizes a float within min-max assuming min is less than max
    /// </summary>
    /// <param name="toNormalize"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns>Unclamped value where 0 represents min and 1 represents max</returns>
    public static float Normalize(float toNormalize, float min, float max)
    {
        return (toNormalize - min) / (max - min);
    }
}
