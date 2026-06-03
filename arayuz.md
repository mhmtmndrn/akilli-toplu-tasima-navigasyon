using SmartTransitNavigation.Algorithms;
using SmartTransitNavigation.DataStructures;
using SmartTransitNavigation.Graph;
using SmartTransitNavigation.Models;
using SmartTransitNavigation.UI;

var stops = new[]
{
    new Stop("B01", "Balat", 40.2550, 28.9400),
    new Stop("B02", "Emek", 40.2450, 28.9300),
    new Stop("B03", "Korupark", 40.2380, 28.9450),
    new Stop("B04", "Organize Sanayi", 40.2320, 28.9650),
    new Stop("B05", "Hamitler/Fethiye", 40.2260, 28.9850),
    new Stop("B06", "Bağlarbaşı/Esentepe", 40.2190, 29.0000),
    new Stop("B07", "İhsaniye", 40.2120, 29.0120),
    new Stop("B08", "Karaman", 40.2070, 29.0250),
    new Stop("B09", "Bursaspor/Acemler", 40.2080, 29.0360),
    new Stop("B10", "Paşa Çiftliği", 40.2050, 29.0450),
    new Stop("B11", "Sırameşeler", 40.2010, 29.0505),
    new Stop("B12", "Kültürpark", 40.1988, 29.0535),
    new Stop("B13", "Merinos", 40.1972, 29.0568),
    new Stop("B14", "Osmangazi", 40.1956, 29.0606),
    new Stop("B15", "Şehreküstü", 40.1904, 29.0638),
    new Stop("B16", "Demirtaşpaşa", 40.1874, 29.0695),
    new Stop("B17", "Gökdere", 40.1880, 29.0780),
    new Stop("B18", "Yıldırım/Davutdede", 40.1900, 29.0880),
    new Stop("B19", "Duaçınarı", 40.1940, 29.1000),
    new Stop("B20", "Yüksek İhtisas Hastanesi", 40.1980, 29.1120),
    new Stop("B21", "Arabayatağı", 40.2010, 29.1250),
    new Stop("B22", "Mimar Sinan/BTÜ", 40.2030, 29.1400),
    new Stop("B23", "Hacivat", 40.2050, 29.1540),
    new Stop("B24", "Şirinevler", 40.2070, 29.1680),
    new Stop("B25", "Otosansit", 40.2090, 29.1820),
    new Stop("B26", "Cumalıkızık/Değirmenönü", 40.2110, 29.1960),
    new Stop("B27", "Gürsu", 40.2150, 29.2050),
    new Stop("B28", "Kestel", 40.1980, 29.2100),
    new Stop("U01", "Üniversite", 40.2250, 28.8700),
    new Stop("U02", "Batıkent", 40.2220, 28.8850),
    new Stop("U03", "Yüzüncüyıl", 40.2200, 28.8980),
    new Stop("U04", "Özlüce/29 Ekim", 40.2180, 28.9120),
    new Stop("U05", "Ertuğrul", 40.2160, 28.9250),
    new Stop("U06", "Altınşehir", 40.2140, 28.9380),
    new Stop("U07", "Küçük Sanayi", 40.2120, 28.9500),
    new Stop("U08", "Ataevler", 40.2110, 28.9620),
    new Stop("U09", "Beşevler", 40.2100, 28.9750),
    new Stop("U10", "Fatih Sultan Mehmet", 40.2090, 28.9900),
    new Stop("U11", "Nilüfer", 40.2085, 29.0060),
    new Stop("U12", "Odunluk", 40.2080, 29.0220),
    new Stop("O01", "Terminal", 40.2660, 29.0560),
    new Stop("O02", "BUTTIM", 40.2580, 29.0610),
    new Stop("O03", "Demirtas", 40.2850, 29.0750),
    new Stop("O04", "Sehir Hastanesi", 40.2320, 28.9350),
    new Stop("O05", "Gorukle", 40.2320, 28.8450),
    new Stop("O06", "Hasanaga TOKI", 40.2100, 28.7850),
    new Stop("O07", "Mudanya", 40.3770, 28.8830),
    new Stop("O08", "Guzelyali", 40.3620, 28.9300),
    new Stop("O09", "BUDO Iskelesi", 40.3790, 28.8820),
    new Stop("O10", "Teleferik", 40.1740, 29.0830),
    new Stop("O11", "Setbasi", 40.1810, 29.0710),
    new Stop("O12", "Heykel", 40.1833, 29.0610),
};

var lines = new[]
{
    new TransitLine("M1", "Balat/Emek - Arabayatağı", new[]
    {
        "B01", "B02", "B03", "B04", "B05", "B06", "B07", "B08", "B09", "B10",
        "B11", "B12", "B13", "B14", "B15", "B16", "B17", "B18", "B19", "B20", "B21"
    }),
    new TransitLine("M2", "Üniversite - Kestel", new[]
    {
        "U01", "U02", "U03", "U04", "U05", "U06", "U07", "U08", "U09", "U10", "U11", "U12",
        "B09", "B10", "B11", "B12", "B13", "B14", "B15", "B16", "B17", "B18", "B19", "B20",
        "B21", "B22", "B23", "B24", "B25", "B26", "B27", "B28"
    }),
    new TransitLine("91", "Terminal - Kestel", new[]
    {
        "O01", "O02", "B21", "B22", "B23", "B24", "B25", "B26", "B27", "B28"
    }),
    new TransitLine("1M", "Mudanya - Emek", new[]
    {
        "O07", "O08", "B02"
    }),
    new TransitLine("F1", "BUDO - Terminal", new[]
    {
        "O09", "O07", "O08", "B02", "O02", "O01"
    }),
    new TransitLine("17C", "Terminal - Demirtas", new[]
    {
        "O01", "O02", "O03"
    }),
    new TransitLine("SH", "Sehir Hastanesi - Acemler", new[]
    {
        "O04", "B03", "B09"
    }),
    new TransitLine("1T", "Hasanaga TOKI - Universite", new[]
    {
        "O06", "O05", "U01"
    }),
    new TransitLine("35U", "Gorukle - Universite", new[]
    {
        "O05", "U01", "U02"
    }),
    new TransitLine("HE", "Teleferik - Heykel - Sehrekustu", new[]
    {
        "O10", "O11", "O12", "B15"
    }),
};

var stopTable = new CustomHashTable<string, Stop>(capacity: 96, StringComparer.OrdinalIgnoreCase);
var lineTable = new CustomHashTable<string, TransitLine>(capacity: 16, StringComparer.OrdinalIgnoreCase);
var spatialIndex = new KdTree<Stop>();
var graph = new TransitGraph();
var stopLookup = stops.ToDictionary(stop => stop.Id, StringComparer.OrdinalIgnoreCase);

foreach (var stop in stops)
{
    stopTable.Add(stop.Id, stop);
    spatialIndex.Insert(stop.Latitude, stop.Longitude, stop);
    graph.AddNode(stop.Id);
}

foreach (var line in lines)
{
    lineTable.Add(line.Id, line);
    AddLineEdges(graph, stopLookup, line);
}

var menu = new ConsoleMenu(new MapRenderer());
menu.ShowMainMenu();
Console.WriteLine();

var userLatitude = 40.1840;
var userLongitude = 29.0620;
var targetLatitude = 40.1980;
var targetLongitude = 29.2100;

var nearestStartStops = spatialIndex.FindNearest(userLatitude, userLongitude, 5);
var nearestTargetStop = spatialIndex.FindNearest(targetLatitude, targetLongitude, 1).First();

Console.WriteLine("Nearest Bursa transit stops to user:");
foreach (var stop in nearestStartStops)
{
    Console.WriteLine($"- {stop.Name} ({stop.Id})");
}

var startStop = nearestStartStops.First();
var route = new Dijkstra().FindShortestPath(graph, startStop.Id, nearestTargetStop.Id);

Console.WriteLine();
Console.WriteLine($"Start stop : {startStop.Name}");
Console.WriteLine($"Target stop: {nearestTargetStop.Name}");

if (!route.HasPath)
{
    Console.WriteLine("No route found.");
    return;
}

var routeStopNames = route.StopIds
    .Select(stopId => stopTable.TryGetValue(stopId, out var stop) ? stop!.Name : stopId)
    .ToList();

Console.WriteLine();
Console.WriteLine("Calculated Bursa transit route:");
Console.WriteLine(string.Join(" -> ", routeStopNames));
Console.WriteLine($"Total cost: {route.TotalCost:0.##}");
Console.WriteLine($"Stop count: {route.StopIds.Count}");

static void AddLineEdges(
    TransitGraph graph,
    IReadOnlyDictionary<string, Stop> stopLookup,
    TransitLine line)
{
    for (var index = 0; index < line.StopIds.Count - 1; index++)
    {
        var fromStopId = line.StopIds[index];
        var toStopId = line.StopIds[index + 1];
        var fromStop = stopLookup[fromStopId];
        var toStop = stopLookup[toStopId];
        var distance = GetApproximateDistanceKm(fromStop, toStop);
        var duration = Math.Max(2, distance * 2.2);
        var cost = Math.Max(1, duration);

        AddTwoWayEdge(graph, fromStopId, toStopId, line.Id, cost, distance, duration);
    }
}

static void AddTwoWayEdge(
    TransitGraph graph,
    string fromStopId,
    string toStopId,
    string lineId,
    double cost,
    double distance,
    double durationMinutes)
{
    graph.AddEdge(fromStopId, toStopId, lineId, cost, distance, durationMinutes);
    graph.AddEdge(toStopId, fromStopId, lineId, cost, distance, durationMinutes);
}

static double GetApproximateDistanceKm(Stop first, Stop second)
{
    var latitudeKm = (first.Latitude - second.Latitude) * 111;
    var longitudeKm = (first.Longitude - second.Longitude) * 85;

    return Math.Sqrt((latitudeKm * latitudeKm) + (longitudeKm * longitudeKm));
}
