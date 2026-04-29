using System;

namespace SmartTransitNavigation.Models;

public sealed class Stop
{
    public Stop(string id, string name, double latitude, double longitude)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("Stop id cannot be empty.", nameof(id));
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Stop name cannot be empty.", nameof(name));
        }

        Id = id;
        Name = name;
        Latitude = latitude;
        Longitude = longitude;
    }

    public string Id { get; }

    public string Name { get; }

    public double Latitude { get; }

    public double Longitude { get; }
}
