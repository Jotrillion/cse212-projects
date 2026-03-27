using System.Collections.Generic;

/// <summary>
/// Represents the root object of the USGS earthquake GeoJSON feed.
/// </summary>
public class FeatureCollection
{
    /// <summary>
    /// List of earthquake features for the day.
    /// </summary>
    public List<Feature> Features { get; set; }
}

/// <summary>
/// Represents a single earthquake feature in the GeoJSON feed.
/// </summary>
public class Feature
{
    /// <summary>
    /// Properties of the earthquake (magnitude, place, etc.).
    /// </summary>
    public Properties Properties { get; set; }
    /// <summary>
    /// Geometry information (location coordinates).
    /// </summary>
    public Geometry Geometry { get; set; }
    /// <summary>
    /// Unique identifier for the feature.
    /// </summary>
    public string Id { get; set; }
}

/// <summary>
/// Contains earthquake details such as magnitude and place.
/// </summary>
public class Properties
{
    /// <summary>
    /// Magnitude of the earthquake. Nullable if not present.
    /// </summary>
    public double? Mag { get; set; }
    /// <summary>
    /// Location description of the earthquake.
    /// </summary>
    public string Place { get; set; }
    // Other properties can be added if needed
}

/// <summary>
/// Represents the geometry/location of the earthquake.
/// </summary>
public class Geometry
{
    /// <summary>
    /// Type of geometry (usually "Point").
    /// </summary>
    public string Type { get; set; }
    /// <summary>
    /// Coordinates of the earthquake (longitude, latitude, depth).
    /// </summary>
    public List<double> Coordinates { get; set; }
}