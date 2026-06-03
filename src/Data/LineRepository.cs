using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace SmartTransitNavigation.Data;

public sealed class LineRepository
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    private readonly string _lineFilePath;
    private readonly string _routeFilePath;

    public LineRepository(string lineFilePath, string routeFilePath)
    {
        if (string.IsNullOrWhiteSpace(lineFilePath))
        {
            throw new ArgumentException("Line file path cannot be empty.", nameof(lineFilePath));
        }

        if (string.IsNullOrWhiteSpace(routeFilePath))
        {
            throw new ArgumentException("Route file path cannot be empty.", nameof(routeFilePath));
        }

        _lineFilePath = lineFilePath;
        _routeFilePath = routeFilePath;
    }

    public IReadOnlyList<LineRecord> GetAllLines()
    {
        if (!File.Exists(_lineFilePath))
        {
            return Array.Empty<LineRecord>();
        }

        var json = File.ReadAllText(_lineFilePath);
        return JsonSerializer.Deserialize<List<LineRecord>>(json, JsonOptions) ?? new List<LineRecord>();
    }

    public IReadOnlyList<RouteRecord> GetAllRoutes()
    {
        if (!File.Exists(_routeFilePath))
        {
            return Array.Empty<RouteRecord>();
        }

        var json = File.ReadAllText(_routeFilePath);
        return JsonSerializer.Deserialize<List<RouteRecord>>(json, JsonOptions) ?? new List<RouteRecord>();
    }

    public LineRecord? FindLineById(string lineId)
    {
        if (string.IsNullOrWhiteSpace(lineId))
        {
            throw new ArgumentException("Line id cannot be empty.", nameof(lineId));
        }

        return GetAllLines()
            .FirstOrDefault(line => string.Equals(line.Id, lineId, StringComparison.OrdinalIgnoreCase));
    }

    public IReadOnlyList<RouteRecord> GetRoutesByLineId(string lineId)
    {
        if (string.IsNullOrWhiteSpace(lineId))
        {
            throw new ArgumentException("Line id cannot be empty.", nameof(lineId));
        }

        return GetAllRoutes()
            .Where(route => string.Equals(route.LineId, lineId, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}

public sealed record LineRecord(
    string Id,
    string Name,
    string Type,
    IReadOnlyList<string> StopIds);

public sealed record RouteRecord(
    string Id,
    string LineId,
    string FromStopId,
    string ToStopId,
    double DistanceKm,
    double DurationMinutes,
    double Cost);
