using System;
using System.Collections.Generic;

namespace SmartTransitNavigation.Simulation;

public sealed class SimulationState
{
    public SimulationState(string vehicleId, string routeId, IReadOnlyList<string> stopIds)
    {
        if (string.IsNullOrWhiteSpace(vehicleId))
        {
            throw new ArgumentException("Vehicle id cannot be empty.", nameof(vehicleId));
        }

        if (string.IsNullOrWhiteSpace(routeId))
        {
            throw new ArgumentException("Route id cannot be empty.", nameof(routeId));
        }

        VehicleId = vehicleId;
        RouteId = routeId;
        StopIds = stopIds ?? throw new ArgumentNullException(nameof(stopIds));
        UpdatedAt = DateTimeOffset.UtcNow;
        IsCompleted = stopIds.Count == 0;
    }

    public string VehicleId { get; }

    public string RouteId { get; }

    public IReadOnlyList<string> StopIds { get; }

    public int CurrentStopIndex { get; private set; }

    public bool IsCompleted { get; private set; }

    public DateTimeOffset UpdatedAt { get; private set; }

    public string? CurrentStopId => StopIds.Count == 0 ? null : StopIds[CurrentStopIndex];

    public string? NextStopId
    {
        get
        {
            var nextIndex = CurrentStopIndex + 1;
            return nextIndex >= StopIds.Count ? null : StopIds[nextIndex];
        }
    }

    public void MoveNext()
    {
        if (IsCompleted)
        {
            return;
        }

        if (CurrentStopIndex + 1 >= StopIds.Count)
        {
            IsCompleted = true;
        }
        else
        {
            CurrentStopIndex++;
        }

        UpdatedAt = DateTimeOffset.UtcNow;
    }
}
