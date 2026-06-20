# Simulasyon ve API Entegrasyon Plani

Bu dokuman, Simulasyon ve API Entegrasyonu gorev branch'i icin hazirlanan baslangic iskeletini aciklar.

Bu asamada amac tam calisan bir servis yapmak degildir. Hedef, ara raporda gosterilebilecek temiz bir servis akisi ve asenkron calismaya uygun metot imzalari olusturmaktir.

## VehicleSimulator

`VehicleSimulator`, bir aracin rota uzerindeki ilerleyisini temsil eden baslangic sinifidir.

Mevcut temel islemler:

- Yeni simulasyon baslatma.
- Arac durumunu getirme.
- Araci bir sonraki duraga ilerletme.

Metotlar `Task` ve `CancellationToken` ile tasarlanmistir. Bu sayede ileride zamanlayici, API endpoint veya arka plan servisi ile uyumlu hale getirilebilir.

## SimulationState

`SimulationState`, bir aracin simulasyon anindaki durumunu tutar.

Tutulan temel alanlar:

- `VehicleId`: Aracin benzersiz kimligi.
- `RouteId`: Simulasyonun bagli oldugu rota.
- `StopIds`: Rota uzerindeki durak listesi.
- `CurrentStopIndex`: Aracin bulundugu durak sira numarasi.
- `IsCompleted`: Simulasyonun tamamlanip tamamlanmadigi.
- `UpdatedAt`: Son guncelleme zamani.

## RouteService

`RouteService`, rota hesaplama veya rota ozetleme islemlerini servis katmaninda temsil eder.

Bu sinif su an `IApiService` uzerinden mock yanit alir. Final projede Dijkstra, KNN, veri repository katmani veya gercek API ile baglanabilir.

## IApiService

`IApiService`, dis servis veya AI destekli servis entegrasyonu icin ortak sozlesmedir.

Baslangic metotlari:

- `GetRouteSuggestionAsync`
- `GetSimulationSummaryAsync`

Bu interface sayesinde gercek API servisi, mock servis veya AI servisi ayni servis katmanina baglanabilir.

## MockAiService

`MockAiService`, gercek AI veya HTTP servisi olmadan sistemi test etmek icin kullanilan sahte servis sinifidir.

Bu sinif, ara rapor asamasinda asenkron servis akisini gostermek icin yeterlidir. Finalde gercek API istegi veya AI modeli ile degistirilebilir.

## Sonraki Adimlar

- RouteService, Dijkstra algoritmasi ile baglanabilir.
- VehicleSimulator icin zaman bazli ilerleme eklenebilir.
- API endpointleri icin controller siniflari eklenebilir.
- MockAiService yerine gercek HTTP client kullanan servis yazilabilir.
- Simulasyon durumlari dosya, veritabani veya bellek ici cache ile saklanabilir.
