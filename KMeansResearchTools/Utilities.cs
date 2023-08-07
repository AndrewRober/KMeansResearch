namespace KMeansResearchTools;

/// <summary>
/// Contains utility functions for calculations used in clustering algorithms.
/// </summary>
public static class Utilities
{
    /// <summary>
    /// Translates a point from its original coordinates to a percentage-based scale.
    /// </summary>
    /// <param name="originalPoint">The original point.</param>
    /// <param name="width">The width of the area the point is being translated to.</param>
    /// <param name="height">The height of the area the point is being translated to.</param>
    /// <returns>The translated point.</returns>
    public static PointF TranslatePoint(PointF originalPoint, int width, int height)
    {
        int padding = 20;
        int axisLength = Math.Min(width, height) - 2 * padding;

        float x = (originalPoint.X - padding) * 100 / axisLength;
        float y = 100 - (originalPoint.Y - padding) * 100 / axisLength;

        return new PointF((float)Math.Round(x), (float)Math.Round(y));
    }

    /// <summary>
    /// Translates a point from a percentage-based scale back to its original coordinates.
    /// </summary>
    /// <param name="translatedPoint">The translated point.</param>
    /// <param name="width">The width of the area the point is being translated from.</param>
    /// <param name="height">The height of the area the point is being translated from.</param>
    /// <returns>The original point.</returns>
    public static PointF ReverseTranslatePoint(PointF translatedPoint, int width, int height)
    {
        int padding = 20;
        int axisLength = Math.Min(width, height) - 2 * padding;

        float x = (translatedPoint.X * axisLength / 100) + padding;
        float y = padding + (100 - translatedPoint.Y) * axisLength / 100;

        return new PointF(x, y);
    }

    /// <summary>
    /// Associates each point in a list with the closest centroid.
    /// </summary>
    /// <param name="points">The list of points.</param>
    /// <param name="centroids">The list of centroids.</param>
    public static void AssociateToClosestCentroid(List<PointData> points, List<CentroidData> centroids)
    {
        foreach (var point in points)
        {
            CentroidData closestCentroid = null;
            double minDistance = double.MaxValue;

            foreach (var centroid in centroids)
            {
                double distance = CalculateEuclideanDistance(point.Point, centroid.Point);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestCentroid = centroid;
                }
            }

            point.Centroid = closestCentroid;
            point.Color = closestCentroid.Color;
        }
    }

    /// <summary>
    /// Calculates the Euclidean distance between two points.
    /// </summary>
    /// <param name="point1">The first point.</param>
    /// <param name="point2">The second point.</param>
    /// <returns>The Euclidean distance between the two points.</returns>
    public static double CalculateEuclideanDistance(PointF point1, PointF point2)
    {
        return Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
    }

    /// <summary>
    /// Calculates the centroid of a list of points.
    /// </summary>
    /// <param name="points">The list of points.</param>
    /// <returns>The centroid of the points.</returns>
    public static PointF CalculateCentroid(List<PointF> points)
    {
        float x = 0;
        float y = 0;

        foreach (var point in points)
        {
            x += point.X;
            y += point.Y;
        }

        return new PointF(x / points.Count, y / points.Count);
    }
        
    /// <summary>
    /// Finds the point in a list that is furthest from a given start point.
    /// </summary>
    /// <param name="startPoint">The start point.</param>
    /// <param name="points">The list of points.</param>
    /// <returns>The furthest point.</returns>
    public static PointF GetFurthestPoint(PointF startPoint, List<PointF> points)
    {
        PointF furthestPoint = new PointF();
        double maxDistance = 0;

        foreach (var point in points)
        {
            double distance = CalculateEuclideanDistance(startPoint, point);
            if (distance > maxDistance)
            {
                maxDistance = distance;
                furthestPoint = point;
            }
        }

        return furthestPoint;
    }

    /// <summary>
    /// Finds the point in a list that is furthest from all centroids.
    /// </summary>
    /// <param name="centroids">The list of centroids.</param>
    /// <param name="points">The list of points.</param>
    /// <returns>The point that is furthest from all centroids.</returns>
    public static PointData GetFurthestPointFromCentroids(List<CentroidData> centroids, List<PointData> points)
    {
        PointData furthestPoint = null;
        double maxDistance = 0;

        foreach (var point in points)
        {
            double minDistanceToCentroid = double.MaxValue;

            // Calculate the distance to the nearest centroid
            foreach (var centroid in centroids)
            {
                double distance = CalculateEuclideanDistance(point.Point, centroid.Point);
                if (distance < minDistanceToCentroid)
                {
                    minDistanceToCentroid = distance;
                }
            }

            // If this point is further than our current furthest, update maxDistance and furthestPoint
            if (minDistanceToCentroid > maxDistance)
            {
                maxDistance = minDistanceToCentroid;
                furthestPoint = point;
            }
        }

        return furthestPoint;
    }

    /// <summary>
    /// Optimizes the position of centroids based on a list of points.
    /// </summary>
    /// <param name="points">The list of points.</param>
    /// <param name="centroids">The list of centroids.</param>
    public static void OptimizeCentroidPosition(List<PointData> points, List<CentroidData> centroids)
    {
        foreach (var centroid in centroids)
        {
            var pointsForCentroid = points.Where(p => p.Centroid == centroid).ToList();
            centroid.Point = CalculateCentroid(pointsForCentroid.Select(p => p.Point).ToList());
        }
    }

    /// <summary>
    /// Calculates the within-cluster sum of squares (WCSS) for a given centroid and list of points.
    /// </summary>
    /// <param name="centroid">The centroid.</param>
    /// <param name="points">The list of points.</param>
    /// <param name="scaleWidth">The width of the area the points and centroid are scaled to.</param>
    /// <param name="scaleHeight">The height of the area the points and centroid are scaled to.</param>
    /// <returns>The WCSS for the given centroid and points.</returns>
    public static double CalculateWCSS(CentroidData centroid, List<PointData> points, int scaleWidth, int scaleHeight)
    {
        double wcss = 0;

        // Filter the points that belong to the specified centroid
        var clusteredPoints = points.Where(p => p.Centroid == centroid);

        foreach (var point in clusteredPoints)
        {
            double distance = CalculateEuclideanDistance(
                TranslatePoint(point.Point, scaleWidth, scaleHeight),
                TranslatePoint(centroid.Point, scaleWidth, scaleHeight));
            wcss += Math.Pow(distance, 2);
        }

        return wcss;
    }

    /// <summary>
    /// Calculates the distance between two points after they have been translated to a percentage-based scale.
    /// </summary>
    /// <param name="point1">The first point.</param>
    /// <param name="point2">The second point.</param>
    /// <param name="width">The width of the area the points are translated to.</param>
    /// <param name="height">The height of the area the points are translated to.</param>
    /// <returns>The distance between the points on the percentage-based scale.</returns>
    public static double CalculateDistance(PointData point1, PointData point2, int width, int height)
    {
        var p1 = TranslatePoint(point1.Point, width, height);
        var p2 = TranslatePoint(point2.Point, width, height);

        var dx = p1.X - p2.X;
        var dy = p1.Y - p2.Y;

        return Math.Sqrt(dx * dx + dy * dy);
    }
}