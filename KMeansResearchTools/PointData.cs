namespace KMeansResearchTools;

/// <summary>
/// Represents a data point in a clustering algorithm.
/// </summary>
public class PointData
{
    /// <summary>
    /// The coordinates of the point.
    /// </summary>
    public PointF Point { get; set; }

    /// <summary>
    /// The color of the point, usually determined by which cluster it belongs to.
    /// </summary>
    public Color Color { get; set; }

    /// <summary>
    /// The centroid that this point is currently associated with.
    /// </summary>
    public CentroidData Centroid { get; set; }

    /// <summary>
    /// A unique identifier for this point.
    /// </summary>
    public Guid Id { get; set; }

    public PointData() => Id = Guid.NewGuid();
}