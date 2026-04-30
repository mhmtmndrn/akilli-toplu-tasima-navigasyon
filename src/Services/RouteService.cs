using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SmartTransitNavigation.Services;

public sealed class RouteService
{
    private readonly IApiService _apiService;

    public RouteService(IApiService apiService)
    {
        _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
    }

    public async Task<RouteServiceResult> CalculateRouteAsync(
        string startStopId,
        string targetStopId,
        CancellationToken cancellationToken = default)
    {
        ValidateStopId(startStopId, nameof(startStopId));
        ValidateStopId(targetStopId, nameof(targetStopId));

        var suggestion = await _apiService
            .GetRouteSuggestionAsync(startStopId, targetStopId, cancellationToken)
            .ConfigureAwait(false);

        var stopIds = new List<string> { startStopId, targetStopId };
        return new RouteServiceResult(stopIds, suggestion);
    }

    public Task<string> GetRouteSummaryAsync(
        string routeId,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(routeId))
        {
            throw new ArgumentException("Route id cannot be empty.", nameof(routeId));
        }

        return _apiService.GetSimulationSummaryAsync(routeId, cancellationToken);
    }

    private static void ValidateStopId(string stopId, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(stopId))
        {
            throw new ArgumentException("Stop id cannot be empty.", parameterName);
        }
    }
}

public sealed record RouteServiceResult(
    IReadOnlyList<string> StopIds,
    string Message);
