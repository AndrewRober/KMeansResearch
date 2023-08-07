namespace KMeansResearchTools;

/// <summary>
/// Represents the data for a point in an elbow chart, used to determine the optimal number of clusters.
/// </summary>
public class ElbowChartData
{
    /// <summary>
    /// The within-cluster sum of squares for this point.
    /// </summary>
    public double WCSS { get; set; }

    /// <summary>
    /// The sum of distances of all points in the dataset to their respective centroids.
    /// </summary>
    public float SumOfDistances { get; set; }

    /// <summary>
    /// The number of centroids in the clustering solution that this point represents.
    /// </summary>
    public int centroidsCount { get; set; }
}