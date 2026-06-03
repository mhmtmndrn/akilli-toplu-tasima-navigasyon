# Rota Algoritmalari Baslangic Iskeleti

Bu dokuman, Akilli Toplu Tasima ve Navigasyon Sistemi projesinde graf ve rota algoritmalari gorev branch'i icin hazirlanan baslangic yapilarini aciklar.

## TransitGraph

`TransitGraph`, toplu tasima agini graf yapisi olarak temsil eder.

Temel kullanim:

- Duraklar `GraphNode` olarak tutulur.
- Duraklar arasi baglantilar `GraphEdge` olarak tutulur.
- Her durak icin komsu kenarlar adjacency list yapisinda saklanir.
- Ayni iki durak arasinda birden fazla hat olabilecegi icin multigraph mantigi desteklenir.

Multigraph destegi, ayni `fromStopId` ve `toStopId` degerleri icin birden fazla `GraphEdge` eklenebilmesiyle saglanir. Bu sayede ayni iki durak arasinda farkli hatlar, farkli sureler veya farkli maliyetler tutulabilir.

## GraphNode

`GraphNode`, graf uzerindeki bir duragi temsil eder.

Tutulan temel alan:

- `StopId`: Duragin benzersiz kimligi.

## GraphEdge

`GraphEdge`, iki durak arasindaki ulasim baglantisini temsil eder.

Tutulan temel alanlar:

- `FromStopId`: Baslangic duragi.
- `ToStopId`: Hedef duragi.
- `LineId`: Baglantinin ait oldugu hat.
- `Cost`: Rota algoritmasinda kullanilacak agirlik degeri.
- `Distance`: Duraklar arasi mesafe.
- `DurationMinutes`: Tahmini yolculuk suresi.

## MinHeap

`MinHeap<TValue>`, Dijkstra algoritmasinda en dusuk maliyetli duragi secmek icin kullanilir.

Temel islemler:

- `Insert`: Degeri oncelik degeriyle birlikte heap'e ekler.
- `TryExtractMin`: En dusuk oncelikli degeri heap'ten cikarir.

Bu yapi, hazir `PriorityQueue` yerine veri yapilari dersi kapsaminda basit bir min-heap mantigi gostermek icin eklenmistir.

## Dijkstra

`Dijkstra`, baslangic duragindan hedef duraga en dusuk maliyetli yolu bulmak icin kullanilir.

Baslangic isleyisi:

1. Baslangic duraginin maliyeti `0` olarak atanir.
2. Diger duraklarin maliyeti sonsuz kabul edilir.
3. MinHeap ile en dusuk maliyetli durak secilir.
4. Secilen duragin komsu kenarlari gezilir.
5. Daha dusuk maliyetli bir yol bulunursa mesafe ve onceki durak bilgisi guncellenir.
6. Hedef duraga ulasilinca rota geriye dogru kurulur.

Bu sinif su an temel rota hesaplama iskeletini verir. Final projede aktarma cezasi, yurumeye bagli ek maliyet, sure/mesafe secimi ve hat degisimi gibi detaylarla genisletilebilir.

## Sonraki Adimlar

- TransitGraph icin iki yonlu kenar ekleme yardimci metodu eklenebilir.
- GraphEdge icine aktarma veya arac tipi bilgisi eklenebilir.
- Dijkstra icin birim testler yazilabilir.
- A* algoritmasi opsiyonel olarak eklenebilir.
- Rota sonucu frontend veya API katmanina uygun DTO ile donulebilir.
