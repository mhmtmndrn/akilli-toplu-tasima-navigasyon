using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace SmartTransitNavigation.Data;

public sealed class StopRepository
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    private readonly string _filePath;

    public StopRepository(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException("File path cannot be empty.", nameof(filePath));
        }

        _filePath = filePath;
    }

    public IReadOnlyList<StopRecord> GetAll()
    {
        if (!File.Exists(_filePath))
        {
            return Array.Empty<StopRecord>();
        }

        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<StopRecord>>(json, JsonOptions) ?? new List<StopRecord>();
    }

    public StopRecord? FindById(string stopId)
    {
        if (string.IsNullOrWhiteSpace(stopId))
        {
            throw new ArgumentException("Stop id cannot be empty.", nameof(stopId));
        }

        return GetAll()
            .FirstOrDefault(stop => string.Equals(stop.Id, stopId, StringComparison.OrdinalIgnoreCase));
    }
}

public sealed record StopRecord(
    string Id,
    string Name,
    double Latitude,
    double Longitude);
