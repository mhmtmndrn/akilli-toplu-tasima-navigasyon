using System;
using System.Collections.Generic;

namespace SmartTransitNavigation.Models;

public sealed class TransitLine
{
    public TransitLine(string id, string name, IReadOnlyList<string> stopIds)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("Line id cannot be empty.", nameof(id));
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Line name cannot be empty.", nameof(name));
        }

        Id = id;
        Name = name;
        StopIds = stopIds ?? throw new ArgumentNullException(nameof(stopIds));
    }

    public string Id { get; }

    public string Name { get; }

    public IReadOnlyList<string> StopIds { get; }
}
