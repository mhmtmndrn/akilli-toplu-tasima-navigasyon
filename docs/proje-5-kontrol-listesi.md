# Proje 5 Kontrol Listesi

Bu dokuman, proje taniminda istenen maddelerin projede hangi parcalarla karsilandigini gosterir.

## Faz 1: Zorunlu Veri Yapilari

| Gereksinim | Projedeki karsiligi |
|---|---|
| Kd-Tree / Spatial Tree | `src/DataStructures/KdTree.cs` durak koordinatlarini tutar ve en yakin K duragi bulur. Harita demosunda da `KdTree` sinifi ile en yakin duraklar bulunur. |
| Graph / Multigraph | `src/Graph/TransitGraph.cs` duraklari dugum, metro/otobus baglantilarini kenar olarak saklar. Ayni iki durak arasinda birden fazla hat eklenebilir. |
| Min-Heap / Priority Queue | `src/DataStructures/MinHeap.cs`, `src/Algorithms/Dijkstra.cs` icinde en dusuk maliyetli dugumu secmek icin kullanilir. Harita demosunda da Dijkstra secimleri `MinHeap` ile yapilir. |
| Hash Table | `src/DataStructures/CustomHashTable.cs`, `Program.cs` icinde `StopId -> Stop` ve `LineId -> TransitLine` erisimi icin kullanilir. |

## Faz 2: Algoritmalar

| Gereksinim | Projedeki karsiligi |
|---|---|
| K-Nearest Neighbors | `KdTree.FindNearest(...)` kullanici konumuna en yakin K duragi bulur. Harita demosunda `findNearestStops(...)`, `KdTree.findNearest(...)` uzerinden calisir. |
| Dijkstra | `src/Algorithms/Dijkstra.cs` graf uzerinde en dusuk maliyetli rotayi hesaplar. Harita demosunda hat degisimi maliyeti de hesaba katilan Dijkstra uygulanir. |
| Rota maliyet modeli | Harita demosu toplam maliyeti yurume maliyeti + ulasim maliyeti + aktarma cezasi olarak gosterir. |
| Karmasiklik analizi | Zaman ve uzay karmasikliklari `docs/rota-algoritmalari.md` icinde analiz edilmistir. |
| A* algoritmasi | Proje taniminda opsiyoneldir; ana zorunlu rota algoritmasi olarak Dijkstra kullanilmistir. |

## Faz 3: Arayuz

| Gereksinim | Projedeki karsiligi |
|---|---|
| Harita veya grid tabanli gosterim | `docs/demo-map.html` Leaflet + OpenStreetMap ile Bursa haritasi uzerinde calisir. |
| Harita uzerinden konum secimi | Kullanici `Baslangic Sec` veya `Hedef Sec` modunu acip haritaya tiklayarak konum belirleyebilir. |
| En yakin K durak vurgusu | Secilen baslangic konumuna en yakin K durak haritada ve sol panelde gosterilir. |
| Rota gorsellestirme | Hesaplanan rota kirmizi cizgi olarak haritada cizilir. |
| Aktarma duraklari | Hat degisimi yapilan duraklar ayrica isaretlenir ve panelde listelenir. |

## Veri Seti

Projede BursaRay ana omurgasi ve belli basli otobus koridorlari kullanilmistir.

- BursaRay M1: Balat/Emek - Arabayatagi
- BursaRay M2: Universite - Kestel
- Otobus koridorlari: Terminal, Mudanya/BUDO, Demirtas, Sehir Hastanesi, Gorukle, Hasanaga, Teleferik/Heykel

Durak koordinatlari demo ve sunum amaciyla yaklasik olarak modellenmistir. Gercek resmi koordinat verisi saglanirsa ayni veri yapilari degismeden veri seti genisletilebilir.
