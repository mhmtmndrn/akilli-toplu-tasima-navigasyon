# Veri Yapilari Baslangic Iskeleti

Bu dokuman, Akilli Toplu Tasima ve Navigasyon Sistemi projesinde veri yapilari gorev branch'i icin eklenen baslangic yapilarini aciklar. Kodlar final proje seviyesinde degildir; amac ara rapor asamasinda anlamli, temiz ve genisletilebilir bir temel olusturmaktir.

## Modeller

### Stop

`Stop`, sistemdeki bir toplu tasima duragini temsil eder.

Tutulan temel bilgiler:

- `Id`: Duragin benzersiz kimligi.
- `Name`: Duragin adi.
- `Latitude`: Duragin enlem degeri.
- `Longitude`: Duragin boylam degeri.

Bu model, ileride KdTree icine yerlestirilerek kullanici konumuna en yakin duraklarin bulunmasinda kullanilabilir.

### TransitLine

`TransitLine`, bir toplu tasima hattini temsil eder.

Tutulan temel bilgiler:

- `Id`: Hattin benzersiz kimligi.
- `Name`: Hattin okunabilir adi.
- `StopIds`: Hattin ugradigi durak kimlikleri.

Bu model, ileride hat bazli rota gosterimi ve aktarma analizleri icin genisletilebilir.

### RouteEdge

`RouteEdge`, iki durak arasindaki ulasim baglantisini temsil eder.

Tutulan temel bilgiler:

- `FromStopId`: Baslangic duragi.
- `ToStopId`: Hedef duragi.
- `LineId`: Baglantinin ait oldugu hat.
- `Distance`: Duraklar arasi mesafe.
- `DurationMinutes`: Tahmini yolculuk suresi.

Bu model, graph veya multigraph yapisinin kenari olarak kullanilabilir.

## CustomHashTable

`CustomHashTable<TKey, TValue>`, durak ve hat bilgilerine hizli erisim saglamak icin eklenen baslangic hash table sinifidir.

Mevcut temel ozellikler:

- Anahtar-deger ekleme.
- Anahtara gore deger arama.
- Anahtar var mi kontrolu.
- Basit load factor kontrolu ile kapasite artirma.

Ornek kullanim senaryolari:

- `StopId -> Stop`
- `LineId -> TransitLine`
- `StopName -> StopId`

## KdTree

`KdTree<TValue>`, iki boyutlu koordinat verilerini saklamak ve en yakin K kaydi bulmak icin eklenen baslangic sinifidir.

Mevcut temel ozellikler:

- `x` ve `y` koordinatiyla veri ekleme.
- Girilen koordinata en yakin K degeri bulma.
- X ve Y eksenlerini sirayla kullanarak agac uzerinde ilerleme.

Bu yapi, projede durak koordinatlari uzerinden KNN aramasi yapmak icin kullanilacaktir.

## Sonraki Adimlar

- Graph veya multigraph sinifinin eklenmesi.
- MinHeap veya PriorityQueue sinifinin eklenmesi.
- KdTree icin birim testlerin yazilmasi.
- CustomHashTable icin ekleme, guncelleme ve arama testlerinin yazilmasi.
- Dijkstra algoritmasinin RouteEdge modeli ile baglanmasi.
