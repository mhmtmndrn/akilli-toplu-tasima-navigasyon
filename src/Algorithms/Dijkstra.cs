using System;
using System.Collections.Generic;
using SmartTransitNavigation.DataStructures;
using SmartTransitNavigation.Graph;

namespace SmartTransitNavigation.Algorithms;

public sealed class Dijkstra
{
    public DijkstraResult FindShortestPath(TransitGraph graph, string startStopId, string targetStopId)
    {
        ArgumentNullException.ThrowIfNull(graph);

        if (!graph.ContainsNode(startStopId) || !graph.ContainsNode(targetStopId))
        {
            return DijkstraResult.NoPath();
        }

        var distances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);
        var previousStops = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        var visitedStops = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var heap = new MinHeap<string>();

        foreach (var node in graph.Nodes)
        {
            distances[node.StopId] = double.PositiveInfinity;
        }

        distances[startStopId] = 0;
        heap.Insert(startStopId, 0);

        while (heap.TryExtractMin(out var currentStopId, out var currentCost))
        {
            if (currentStopId is null || !visitedStops.Add(currentStopId))
            {
                continue;
            }

            if (string.Equals(currentStopId, targetStopId, StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            foreach (var edge in graph.GetEdges(currentStopId))
            {
                var nextCost = currentCost + edge.Cost;
                if (nextCost >= distances[edge.ToStopId])
                {
                    continue;
                }

                distances[edge.ToStopId] = nextCost;
                previousStops[edge.ToStopId] = currentStopId;
                heap.Insert(edge.ToStopId, nextCost);
            }
        }

        if (double.IsPositiveInfinity(distances[targetStopId]))
        {
            return DijkstraResult.NoPath();
        }

        return new DijkstraResult(
            BuildPath(previousStops, startStopId, targetStopId),
            distances[targetStopId],
            hasPath: true);
    }

    private static IReadOnlyList<string> BuildPath(
        IReadOnlyDictionary<string, string> previousStops,
        string startStopId,
        string targetStopId)
    {
        var path = new List<string>();
        var currentStopId = targetStopId;

        path.Add(currentStopId);

        while (!string.Equals(currentStopId, startStopId, StringComparison.OrdinalIgnoreCase))
        {
            currentStopId = previousStops[currentStopId];
            path.Add(currentStopId);
        }

        path.Reverse();
        return path;
    }
}

public sealed class DijkstraResult
{
    public DijkstraResult(IReadOnlyList<string> stopIds, double totalCost, bool hasPath)
    {
        StopIds = stopIds;
        TotalCost = totalCost;
        HasPath = hasPath;
    }

    public IReadOnlyList<string> StopIds { get; }

    public double TotalCost { get; }

    public bool HasPath { get; }

    public static DijkstraResult NoPath()
    {
        return new DijkstraResult(Array.Empty<string>(), double.PositiveInfinity, hasPath: false);
    }
}
