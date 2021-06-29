using System.Numerics;
using System.Collections.Generic;
using Engine.ErrorHandler;

public static class PoutineMath
{
    /// <summary>
    /// Given an arbitrary set of points returns a bounding box encompassing all of the points.
    /// </summary>
    /// <param name="points"></param>
    /// <returns>Vector4 (minX, minY, maxX, maxY)</returns>
    public static Vector4 GetBoundingBox(IEnumerable<Vector2> points)
    {
        float minX = float.MaxValue;
        float minY = float.MaxValue;
        float maxX = float.MinValue;
        float maxY = float.MinValue;

        foreach (var point in points)
        {
            if (point.X < minX)
            {
                minX = point.X;
            }

            if (point.Y < minY)
            {
                minY = point.Y;
            }

            if (point.X > maxX)
            {
                maxX = point.X;
            }

            if (point.Y > maxY)
            {
                maxY = point.Y;
            }
        }

        return new Vector4(minX, minY, maxX, maxY);
    }

    /// <summary>
    /// Gets the average of an arbitrary collection of points
    /// </summary>
    /// <param name="points"></param>
    /// <returns>Vector2 representing the mean</returns>
    public static Vector2 GetMeanOfPoints(List<Vector2> points)
    {
        var mean = Vector2.Zero;

        foreach (var point in points)
        {
            mean += point;
        }

        mean /= points.Count;

        return mean;
    }

    /// <summary>
    /// Given 4 points to form a rectangle returns the center and dimensions.
    /// </summary>
    /// <param name="points">Vector4(minX, minY, maxX, maxY)</param>
    /// <returns>Vector4(centerX, centerY, width, height)</returns>
    public static Vector4 GetRectangleFromPoints(Vector4 points)
    {
        var centerX = (points.X + points.Z) / 2;
        var centerY = (points.Y + points.W) / 2;
        var width = points.Z - points.X;
        var height = points.W - points.Y;

        return new Vector4(centerX, centerY, width, height);
    }
}
