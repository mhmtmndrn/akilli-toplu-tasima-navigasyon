using System;
using System.Collections.Generic;

namespace SmartTransitNavigation.UI;

public sealed class ConsoleMenu
{
    private readonly MapRenderer _mapRenderer;

    public ConsoleMenu(MapRenderer mapRenderer)
    {
        _mapRenderer = mapRenderer ?? throw new ArgumentNullException(nameof(mapRenderer));
    }

    public void ShowMainMenu()
    {
        Console.WriteLine("Smart Transit Navigation");
        Console.WriteLine("1. Select start point");
        Console.WriteLine("2. Select target point");
        Console.WriteLine("3. Show nearest stops");
        Console.WriteLine("4. Show route result");
        Console.WriteLine("0. Exit");
    }

    public SelectedPoint SelectStartPoint()
    {
        return ReadPoint("start");
    }

    public SelectedPoint SelectTargetPoint()
    {
        return ReadPoint("target");
    }

    public void ShowNearestStops(IReadOnlyList<string> stopNames)
    {
        Console.WriteLine("Nearest stops:");
        _mapRenderer.RenderNearestStops(stopNames);
    }

    public void ShowRouteResult(IReadOnlyList<string> stopNames, double totalCost)
    {
        Console.WriteLine("Route result:");
        _mapRenderer.RenderRoute(stopNames, totalCost);
    }

    private static SelectedPoint ReadPoint(string pointType)
    {
        Console.WriteLine($"Enter {pointType} latitude:");
        var latitudeText = Console.ReadLine();

        Console.WriteLine($"Enter {pointType} longitude:");
        var longitudeText = Console.ReadLine();

        _ = double.TryParse(latitudeText, out var latitude);
        _ = double.TryParse(longitudeText, out var longitude);

        return new SelectedPoint(latitude, longitude);
    }
}

public sealed record SelectedPoint(double Latitude, double Longitude);
