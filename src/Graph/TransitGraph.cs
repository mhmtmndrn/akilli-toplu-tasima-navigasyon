using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartTransitNavigation.Graph;

public sealed class TransitGraph
{
    private readonly Dictionary<string, GraphNode> _nodes = new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<string, List<GraphEdge>> _adjacency = new(StringComparer.OrdinalIgnoreCase);

    public int NodeCount => _nodes.Count;

    public int EdgeCount { get; private set; }

    public IReadOnlyCollection<GraphNode> Nodes => _nodes.Values.ToList();

    public void AddNode(string stopId)
    {
        if (string.IsNullOrWhiteSpace(stopId))
        {
            throw new ArgumentException("Stop id cannot be empty.", nameof(stopId));
        }

        if (_nodes.ContainsKey(stopId))
        {
            return;
        }

        _nodes[stopId] = new GraphNode(stopId);
        _adjacency[stopId] = new List<GraphEdge>();
    }

    public void AddEdge(
        string fromStopId,
        string toStopId,
        string lineId,
        double cost,
        double distance,
        double durationMinutes)
    {
        AddNode(fromStopId);
        AddNode(toStopId);

        var edge = new GraphEdge(fromStopId, toStopId, lineId, cost, distance, durationMinutes);
        _adjacency[fromStopId].Add(edge);
        EdgeCount++;
    }

    public bool ContainsNode(string stopId)
    {
        return _nodes.ContainsKey(stopId);
    }

    public IReadOnlyList<GraphEdge> GetEdges(string stopId)
    {
        if (!_adjacency.TryGetValue(stopId, out var edges))
        {
            return Array.Empty<GraphEdge>();
        }

        return edges;
    }

    public IReadOnlyList<GraphEdge> GetEdgesBetween(string fromStopId, string toStopId)
    {
        return GetEdges(fromStopId)
            .Where(edge => string.Equals(edge.ToStopId, toStopId, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}
