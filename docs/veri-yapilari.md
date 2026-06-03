# Veri Yapilari

Bu projede Bursa toplu tasima agi durak, hat ve baglanti modelleri uzerinden temsil edilir.

## Modeller

### Stop

`Stop`, bir metro veya otobus duragini temsil eder.

- `Id`
- `Name`
- `Latitude`
- `Longitude`

Duraklar hem hash table icinde hizli erisim icin hem de KdTree icinde konumsal arama icin kullanilir.

### TransitLine

`TransitLine`, bir metro veya otobus hattini temsil eder.

- `Id`
- `Name`
- `StopIds`

Hat uzerindeki ardışık duraklar graf kenarlarina donusturulur.

### GraphEdge

`GraphEdge`, iki durak arasindaki ulasim baglantisidir.

- `FromStopId`
- `ToStopId`
- `LineId`
- `Cost`
- `Distance`
- `DurationMinutes`

## KdTree

`src/DataStructures/KdTree.cs`, iki boyutlu koordinat aramasi icin kullanilir.

Kullanim:

- Durak koordinatlarini ekleme
- Kullanici konumuna en yakin K duragi bulma

Bu yapi dogrusal taramaya gore ortalama durumda daha verimli arama sunar.

## TransitGraph

`src/Graph/TransitGraph.cs`, toplu tasima agini adjacency list ile tutar.

- Dugumler: duraklar
- Kenarlar: metro/otobus baglantilari
- Kenar agirligi: rota maliyeti
- Multigraph destegi: ayni iki durak arasinda birden fazla hat bulunabilir

## MinHeap

`src/DataStructures/MinHeap.cs`, Dijkstra algoritmasinda en dusuk maliyetli duragi secmek icin kullanilir.

- Ekleme: `O(log N)`
- Minimum cikarma: `O(log N)`

## CustomHashTable

`src/DataStructures/CustomHashTable.cs`, durak ve hat bilgilerine hizli erisim icin kullanilir.

Ornek kullanimlar:

- `StopId -> Stop`
- `LineId -> TransitLine`

Ortalama erisim maliyeti `O(1)` kabul edilir.
