using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SmartTransitNavigation.Simulation;

public sealed class VehicleSimulator
{
    private readonly List<SimulationState> _states = new();

    public Task<SimulationState> StartSimulationAsync(
        string vehicleId,
        string routeId,
        IReadOnlyList<string> stopIds,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var state = new SimulationState(vehicleId, routeId, stopIds);
        _states.Add(state);

        return Task.FromResult(state);
    }

    public Task<SimulationState?> GetStateAsync(
        string vehicleId,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var state = _states.Find(item =>
            string.Equals(item.VehicleId, vehicleId, StringComparison.OrdinalIgnoreCase));

        return Task.FromResult(state);
    }

    public Task<SimulationState?> AdvanceAsync(
        string vehicleId,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var state = _states.Find(item =>
            string.Equals(item.VehicleId, vehicleId, StringComparison.OrdinalIgnoreCase));

        state?.MoveNext();

        return Task.FromResult(state);
    }
}
