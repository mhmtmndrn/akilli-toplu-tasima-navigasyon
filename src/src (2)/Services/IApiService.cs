using System.Threading;
using System.Threading.Tasks;

namespace SmartTransitNavigation.Services;

public interface IApiService
{
    Task<string> GetRouteSuggestionAsync(
        string startStopId,
        string targetStopId,
        CancellationToken cancellationToken = default);

    Task<string> GetSimulationSummaryAsync(
        string routeId,
        CancellationToken cancellationToken = default);
}
