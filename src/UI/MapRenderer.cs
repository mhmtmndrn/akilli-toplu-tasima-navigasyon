using System;
using System.Collections.Generic;

namespace SmartTransitNavigation.UI;

public sealed class MapRenderer
{
    public void RenderEmptyMap()
    {
        Console.WriteLine("+----------------------+");
        Console.WriteLine("|   Transit Map Area   |");
        Console.WriteLine("+----------------------+");
    }

    public void RenderSelectedPoints(SelectedPoint startPoint, SelectedPoint targetPoint)
    {
        Console.WriteLine("Selected points:");
        Console.WriteLine($"Start : {FormatPoint(startPoint)}");
        Console.WriteLine($"Target: {FormatPoint(targetPoint)}");
    }

    public void RenderNearestStops(IReadOnlyList<string> stopNames)
    {
        if (stopNames.Count == 0)
        {
            Console.WriteLine("No nearest stop data available.");
            return;
        }

        for (var index = 0; index < stopNames.Count; index++)
        {
            Console.WriteLine($"{index + 1}. {stopNames[index]}");
        }
    }

    public void RenderRoute(IReadOnlyList<string> stopNames, double totalCost)
    {
        if (stopNames.Count == 0)
        {
            Console.WriteLine("No route result available.");
            return;
        }

        Console.WriteLine(string.Join(" -> ", stopNames));
        Console.WriteLine($"Total cost: {totalCost:0.##}");
    }

    private static string FormatPoint(SelectedPoint point)
    {
        return $"{point.Latitude:0.000000}, {point.Longitude:0.000000}";
    }
}
