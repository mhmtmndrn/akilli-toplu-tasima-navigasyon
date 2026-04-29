# Veri Yapilari Projesi Ara Raporu

## 1. Proje Bilgileri

**Ders:** Veri Yapilari  
**Proje Konusu:** Konu 5 - Akilli Toplu Tasima ve Navigasyon Sistemi  
**Proje Ekibi:** Grup 11  
**Hazirlanma Tarihi:** 29.04.2026  
**Ara Rapor Teslim Hedefi:** 30.04.2026  
**GitHub Repository:** https://github.com/mhmtmndrn/akilli-toplu-tasima-navigasyon

## 2. Ekip Uyeleri

- Mehmet Emin Duran - 032390042
- Kerem Beyaz - 032390054
- Sukru Coskun - 032390063
- Taha Akman - 032390073
- Ali Ihsan Dagasan - 032390077

## 3. Projenin Amaci

Bu projenin amaci, bir sehrin toplu tasima agini veri yapilari ve algoritmalar yardimiyla modelleyen baslangic seviyesinde bir akilli navigasyon sistemi gelistirmektir.

Sistemde duraklar graf dugumleri, duraklar arasindaki baglantilar ise graf kenarlari olarak ele alinacaktir. Kullanici konumuna en yakin duraklarin bulunmasi ve baslangic-hedef duraklari arasinda uygun rotanin hesaplanmasi hedeflenmektedir.

Ara rapor asamasinda tam calisan final proje yerine, GitHub uzerinde anlamli branch yapisi, modullere ayrilmis baslangic kodlari, dokumantasyon dosyalari ve ekip calisma sureci olusturulmustur.

## 4. GitHub ve Branch Sureci

Proje icin GitHub repository olusturulmus ve ekip uyeleri icin ayri feature branchleri hazirlanmistir.

Kullanilan branch yapisi:

- `main`: Ana branch. Dogrudan kod yazilmamasi hedeflenmektedir.
- `feature-emin`: Veri yapilari ve temel modelleme calismalari.
- `feature-ali`:  Graf ve rota algoritmalari.
- `feature-sukru`: Bursa veri seti ve hat modelleme çalışmaları.
- `feature-taha`: Harita arayuzu ve etkilesim çalışmaları.
- `feature-kerem`: Simulasyon ve API entegrasyonu.

Bu asamada her ekip uyesinin kendi branch'i uzerinden calisma yapmasi, daha sonra ana branch'e pull request acarak ekleme-degistirme isteginde bulunmasi planlanmistir. Boylece ana branch dogrudan degistirilmeden, GitHub uzerinde takip edilebilir bir gelistirme sureci olusturulmustur.

## 5. Gorev Dagilimi ve Hazirlanan Moduller

### 5.1 Veri Yapilari ve Temel Modeller

Bu bolumde sistemin temel veri modelleri ve veri yapilari icin baslangic iskeleti hazirlanmistir.

Hazirlanan dosyalar:

- `src/Models/Stop.cs`
- `src/Models/TransitLine.cs`
- `src/Models/RouteEdge.cs`
- `src/DataStructures/CustomHashTable.cs`
- `src/DataStructures/KdTree.cs`
- `docs/veri-yapilari.md`

Eklenen yapilar:

- `Stop`: Durak kimligi, adi ve koordinat bilgilerini tutar.
- `TransitLine`: Hat bilgisi ve hatta ait durak listesini tutar.
- `RouteEdge`: Iki durak arasindaki baglanti bilgisini temsil eder.
- `CustomHashTable`: Durak ve hat bilgilerine hizli erisim icin baslangic hash table yapisi.
- `KdTree`: Koordinat tabanli en yakin durak arama icin baslangic spatial tree yapisi.

### 5.2 Graf ve Rota Algoritmalari

Toplu tasima aginin graf olarak modellenmesi ve rota hesaplama icin baslangic iskeleti hazirlanmistir.

Hazirlanan dosyalar:

- `src/Graph/TransitGraph.cs`
- `src/Graph/GraphNode.cs`
- `src/Graph/GraphEdge.cs`
- `src/Algorithms/Dijkstra.cs`
- `src/DataStructures/MinHeap.cs`
- `docs/rota-algoritmalari.md`

Eklenen yapilar:

- `TransitGraph`: Duraklari ve baglantilari adjacency list yapisinda tutar.
- `GraphNode`: Graf uzerindeki durak dugumunu temsil eder.
- `GraphEdge`: Duraklar arasindaki hat, mesafe, sure ve maliyet bilgisini temsil eder.
- `MinHeap`: Dijkstra algoritmasinda en dusuk maliyetli dugumu secmek icin kullanilir.
- `Dijkstra`: Baslangic ve hedef durak arasinda en dusuk maliyetli yolu bulmak icin baslangic sinifi.

TransitGraph ayni iki durak arasinda birden fazla baglantiyi destekleyecek sekilde tasarlanmistir. Bu sayede proje gereksiniminde belirtilen multigraph mantigi karsilanmistir.

### 5.3 Bursa Veri Seti ve Hat Modelleme

Ara rapor asamasi icin gercek veri yerine sentetik Bursa toplu tasima verisi hazirlanmistir.

Hazirlanan dosyalar:

- `data/stops_sample.json`
- `data/lines_sample.json`
- `data/routes_sample.json`
- `src/Data/StopRepository.cs`
- `src/Data/LineRepository.cs`
- `docs/veri-seti.md`

Eklenen yapilar:

- Ornek durak verileri.
- Ornek hat verileri.
- Duraklar arasi ornek rota/baglanti verileri.
- `StopRepository`: JSON dosyasindan durak okuma ve durak kimligine gore arama.
- `LineRepository`: JSON dosyasindan hat ve rota verilerini okuma.

Bu veri yapisi ileride graf olusturma, KNN aramasi ve Dijkstra algoritmasi icin temel veri kaynagi olarak kullanilabilir.

### 5.4 Harita Arayuzu ve Etkilesim

Finalde gorsel arayuze donusturulebilecek console tabanli baslangic arayuz iskeleti hazirlanmistir.

Hazirlanan dosyalar:

- `src/UI/ConsoleMenu.cs`
- `src/UI/MapRenderer.cs`
- `docs/arayuz.md`

Eklenen yapilar:

- `ConsoleMenu`: Baslangic noktasi secimi, hedef noktasi secimi, en yakin duraklari gosterme ve rota sonucu gosterme icin placeholder metotlar.
- `MapRenderer`: Console uzerinde harita, secilen noktalar, durak listesi ve rota sonucunu temsil eden baslangic sinifi.

Bu bolum, final projede web veya harita tabanli arayuze gecis icin planlama amaci tasimaktadir.

### 5.5 Simulasyon ve API Entegrasyonu

Sistemin ilerleyen asamalarda servis veya API mantigina uygun calisabilmesi icin asenkron metot imzalarina sahip baslangic siniflari hazirlanmistir.

Hazirlanan dosyalar:

- `src/Simulation/VehicleSimulator.cs`
- `src/Simulation/SimulationState.cs`
- `src/Services/RouteService.cs`
- `src/Services/IApiService.cs`
- `src/Services/MockAiService.cs`
- `docs/simulasyon-api.md`

Eklenen yapilar:

- `VehicleSimulator`: Aracin rota uzerindeki ilerleyisini simule eder.
- `SimulationState`: Aracin mevcut durak, rota ve tamamlanma durumunu tutar.
- `RouteService`: Rota hesaplama ve rota ozetleme servis iskeleti.
- `IApiService`: API veya AI servisleri icin ortak interface.
- `MockAiService`: Gercek API olmadan test amacli sahte servis.

Metotlar `Task` ve `CancellationToken` kullanacak sekilde tasarlanarak asenkron calismaya uygun hale getirilmistir.

## 6. Kullanilan Veri Yapilari ve Algoritmalar

Ara rapor asamasinda proje gereksinimlerine uygun olarak asagidaki yapilar icin baslangic iskeleti olusturulmustur:

- Graph / Multigraph
- KdTree
- MinHeap
- CustomHashTable
- KNN icin KdTree tabanli hazirlik
- Dijkstra algoritmasi
- A* algoritmasi final asamasi icin opsiyonel olarak planlanmistir

## 7. Hata, Bulgu ve Cozumler

Ara rapor surecinde tespit edilen baslica durumlar:

- Ana branch uzerinde dogrudan kod yazilmamasi gerektigi icin calismalar feature branch mantigiyla planlanmistir.
- Kod dosyalarinda Turkce karakter iceren sinif, dosya, degisken ve metot adi kullanilmamasina dikkat edilmistir.
- `bin` ve `obj` gibi derleme ciktilarinin GitHub'a eklenmemesi gerektigi belirlenmistir.
- Proje final seviyesinde olmadigi icin gereksiz karmasik mimari yerine sade, genisletilebilir baslangic siniflari tercih edilmistir.
- Gercek Bursa verisi zorunlu olmadigi icin ara rapor asamasinda sentetik ama anlamli ornek veri seti hazirlanmistir.
- Servis/API bolumunde final entegrasyon yerine mock servis kullanilarak asenkron akis gosterilmistir.

## 8. Ana Branch Karsilama Sayfasi Icin Guncel Durum Ozeti

README veya ana branch karsilama sayfasinda belirtilmesi onerilen guncel durum:

- Proje konusu ve amaci belirlenmistir.
- Ekip uyeleri ve feature branch yapisi olusturulmustur.
- Veri yapilari icin `CustomHashTable`, `KdTree`, `MinHeap`, `Graph/Multigraph` baslangic iskeletleri hazirlanmistir.
- Rota hesaplama icin Dijkstra algoritmasi baslangic sinifi hazirlanmistir.
- Bursa icin sentetik durak, hat ve rota veri seti olusturulmustur.
- Console tabanli arayuz ve harita gosterimi icin placeholder siniflar hazirlanmistir.
- Simulasyon ve servis/API entegrasyonu icin asenkron baslangic yapilari hazirlanmistir.
- Her modulu aciklayan dokumantasyon dosyalari eklenmistir.

## 9. Sonraki Adimlar

- Ekip uyeleri kendi branch'lerinden pull request acarak ana branch'e ekleme isteginde bulunacaktir.
- Hazirlanan iskelet kodlar ortak review sonrasinda birlestirilecektir.
- Veri yapilari ve algoritmalar icin birim testler eklenecektir.
- Dijkstra algoritmasi veri seti ve graf yapisi ile entegre edilecektir.
- Console arayuz daha sonra web veya harita tabanli gorsel arayuze donusturulecektir.
- Nihai rapor icin Big-O analizleri, UML diyagramlari ve demo senaryolari tamamlanacaktir.

