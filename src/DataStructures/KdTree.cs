using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartTransitNavigation.DataStructures;

public sealed class KdTree<TValue>
{
    private Node? _root;

    public int Count { get; private set; }

    public void Insert(double x, double y, TValue value)
    {
        _root = Insert(_root, x, y, value, depth: 0);
        Count++;
    }

    public IReadOnlyList<TValue> FindNearest(double x, double y, int count)
    {
        if (count <= 0 || _root is null)
        {
            return Array.Empty<TValue>();
        }

        var candidates = new List<Candidate>();
        SearchNearest(_root, x, y, count, candidates);

        return candidates
            .OrderBy(candidate => candidate.DistanceSquared)
            .Select(candidate => candidate.Value)
            .ToList();
    }

    private static Node Insert(Node? node, double x, double y, TValue value, int depth)
    {
        if (node is null)
        {
            return new Node(x, y, value, depth);
        }

        var compareByX = depth % 2 == 0;
        var goesLeft = compareByX ? x < node.X : y < node.Y;

        if (goesLeft)
        {
            node.Left = Insert(node.Left, x, y, value, depth + 1);
        }
        else
        {
            node.Right = Insert(node.Right, x, y, value, depth + 1);
        }

        return node;
    }

    private static void SearchNearest(Node node, double x, double y, int count, List<Candidate> candidates)
    {
        var distanceSquared = GetDistanceSquared(x, y, node.X, node.Y);
        AddCandidate(candidates, new Candidate(node.Value, distanceSquared), count);

        var compareByX = node.Depth % 2 == 0;
        var axisDistance = compareByX ? x - node.X : y - node.Y;

        var nearBranch = axisDistance < 0 ? node.Left : node.Right;
        var farBranch = axisDistance < 0 ? node.Right : node.Left;

        if (nearBranch is not null)
        {
            SearchNearest(nearBranch, x, y, count, candidates);
        }

        if (farBranch is not null && ShouldSearchFarBranch(axisDistance, count, candidates))
        {
            SearchNearest(farBranch, x, y, count, candidates);
        }
    }

    private static void AddCandidate(List<Candidate> candidates, Candidate candidate, int count)
    {
        if (candidates.Count < count)
        {
            candidates.Add(candidate);
            return;
        }

        var worstIndex = 0;
        for (var index = 1; index < candidates.Count; index++)
        {
            if (candidates[index].DistanceSquared > candidates[worstIndex].DistanceSquared)
            {
                worstIndex = index;
            }
        }

        if (candidate.DistanceSquared < candidates[worstIndex].DistanceSquared)
        {
            candidates[worstIndex] = candidate;
        }
    }

    private static bool ShouldSearchFarBranch(double axisDistance, int count, List<Candidate> candidates)
    {
        if (candidates.Count < count)
        {
            return true;
        }

        var worstDistanceSquared = candidates.Max(candidate => candidate.DistanceSquared);
        return axisDistance * axisDistance <= worstDistanceSquared;
    }

    private static double GetDistanceSquared(double firstX, double firstY, double secondX, double secondY)
    {
        var xDifference = firstX - secondX;
        var yDifference = firstY - secondY;

        return (xDifference * xDifference) + (yDifference * yDifference);
    }

    private sealed class Node
    {
        public Node(double x, double y, TValue value, int depth)
        {
            X = x;
            Y = y;
            Value = value;
            Depth = depth;
        }

        public double X { get; }

        public double Y { get; }

        public TValue Value { get; }

        public int Depth { get; }

        public Node? Left { get; set; }

        public Node? Right { get; set; }
    }

    private sealed record Candidate(TValue Value, double DistanceSquared);
}
