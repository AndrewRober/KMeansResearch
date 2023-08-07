namespace KMeansResearchTools;

/// <summary>
/// Represents a centroid in a clustering algorithm.
/// </summary>
public class CentroidData
{
    /// <summary>
    /// The coordinates of the centroid.
    /// </summary>
    public PointF Point { get; set; }

    /// <summary>
    /// The color of the centroid, used to color the points that belong to this centroid.
    /// </summary>
    public Color Color { get; set; }

    /// <summary>
    /// A unique identifier for this centroid.
    /// </summary>
    public Guid Id { get; set; }

    public CentroidData() => Id = Guid.NewGuid();
}