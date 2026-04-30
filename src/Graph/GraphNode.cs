using System;

namespace SmartTransitNavigation.Graph;

public sealed class GraphNode
{
    public GraphNode(string stopId)
    {
        if (string.IsNullOrWhiteSpace(stopId))
        {
            throw new ArgumentException("Stop id cannot be empty.", nameof(stopId));
        }

        StopId = stopId;
    }

    public string StopId { get; }
}
