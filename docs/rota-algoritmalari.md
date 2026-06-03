# Rota Algoritmalari

Proje, toplu tasima agini agirlikli ve yonlu graf olarak modeller. Duraklar dugum, metro/otobus baglantilari kenar olarak tutulur.

## TransitGraph

`TransitGraph`, adjacency list kullanan graf yapisidir.

- Dugumler: duraklar
- Kenarlar: duraklar arasi metro veya otobus baglantilari
- Kenar agirligi: sure/mesafe tabanli rota maliyeti
- Hat bilgisi: `LineId`

Ayni iki durak arasinda birden fazla hat olabilecegi icin multigraph mantigi desteklenir. Ornegin ayni iki istasyon hem M1 hem M2 ortak hattinda bulunabilir.

## Dijkstra

`src/Algorithms/Dijkstra.cs`, baslangic duragindan hedef duraga en dusuk maliyetli yolu bulur.

Temel adimlar:

1. Baslangic duraginin maliyeti `0` yapilir.
2. Diger duraklar sonsuz maliyetle baslatilir.
3. `MinHeap` ile en dusuk maliyetli durak secilir.
4. Komsu kenarlar gezilir.
5. Daha dusuk maliyet bulunursa onceki durak ve maliyet bilgisi guncellenir.
6. Hedefe ulasilinca rota geriye dogru kurulur.

Harita demosunda ayni Dijkstra mantigi hat durumuyla birlikte calisir. Secilecek dugumler `MinHeap` ile alinir. Boylece hat degisimi oldugunda aktarma cezasi da maliyete eklenir.

## KNN

Kullanici haritadan bir koordinat sectiginde en yakin duraklar spatial arama mantigiyle bulunur.

- C# tarafinda: `KdTree.FindNearest(...)`
- Harita demosunda: `findNearestStops(...)`, `KdTree.findNearest(...)` uzerinden calisir.

## Maliyet Modeli

Toplam rota maliyeti su parcalardan olusur:

- Baslangic konumundan ilk duraga yurume maliyeti
- Duraklar arasi ulasim maliyeti
- Hat degisimi varsa aktarma cezasi
- Son duraktan hedef konuma yurume maliyeti

Harita arayuzu bu maliyetleri ayri ayri ve toplam olarak gosterir.

## Zaman ve Uzay Karmasikligi

| Algoritma / Veri yapisi | Zaman karmasikligi | Uzay karmasikligi |
|---|---|---|
| KdTree kurulum | Ortalama `O(N log N)` | `O(N)` |
| KdTree en yakin K arama | Ortalama `O(log N + K)`, en kotu `O(N)` | `O(K + H)` |
| Dijkstra + MinHeap | `O((V + E) log V)` | `O(V + E)` |
| MinHeap ekleme/cikarma | `O(log N)` | `O(N)` |
| HashTable erisim | Ortalama `O(1)`, en kotu `O(N)` | `O(N)` |

Burada `V` durak sayisini, `E` duraklar arasi baglanti sayisini, `K` istenen en yakin durak sayisini, `H` ise KdTree yuksekligini temsil eder.
