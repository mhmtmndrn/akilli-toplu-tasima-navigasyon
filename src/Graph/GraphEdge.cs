using System;

namespace SmartTransitNavigation.Graph;

public sealed class GraphEdge
{
    public GraphEdge(
        string fromStopId,
        string toStopId,
        string lineId,
        double cost,
        double distance,
        double durationMinutes)
    {
        if (string.IsNullOrWhiteSpace(fromStopId))
        {
            throw new ArgumentException("Source stop id cannot be empty.", nameof(fromStopId));
        }

        if (string.IsNullOrWhiteSpace(toStopId))
        {
            throw new ArgumentException("Target stop id cannot be empty.", nameof(toStopId));
        }

        if (string.IsNullOrWhiteSpace(lineId))
        {
            throw new ArgumentException("Line id cannot be empty.", nameof(lineId));
        }

        if (cost < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(cost), "Cost cannot be negative.");
        }

        if (distance < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(distance), "Distance cannot be negative.");
        }

        if (durationMinutes < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(durationMinutes), "Duration cannot be negative.");
        }

        FromStopId = fromStopId;
        ToStopId = toStopId;
        LineId = lineId;
        Cost = cost;
        Distance = distance;
        DurationMinutes = durationMinutes;
    }

    public string FromStopId { get; }

    public string ToStopId { get; }

    public string LineId { get; }

    public double Cost { get; }

    public double Distance { get; }

    public double DurationMinutes { get; }
}
