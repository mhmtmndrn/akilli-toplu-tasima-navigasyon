using System.Threading;
using System.Threading.Tasks;

namespace SmartTransitNavigation.Services;

public sealed class MockAiService : IApiService
{
    public Task<string> GetRouteSuggestionAsync(
        string startStopId,
        string targetStopId,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var message = $"Mock suggestion from {startStopId} to {targetStopId}.";
        return Task.FromResult(message);
    }

    public Task<string> GetSimulationSummaryAsync(
        string routeId,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var message = $"Mock simulation summary for route {routeId}.";
        return Task.FromResult(message);
    }
}
