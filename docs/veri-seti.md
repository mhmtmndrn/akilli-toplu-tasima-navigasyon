# Bursa Veri Seti Baslangic Iskeleti

Bu dokuman, Bursa Veri Seti ve Hat Modelleme gorev branch'i icin hazirlanan ornek veri dosyalarini ve baslangic repository siniflarini aciklar.

Veriler gercek Bursa verisi olmak zorunda degildir. Ara rapor asamasi icin sentetik, okunabilir ve proje gereksinimlerini gosteren bir veri seti hazirlanmistir.

## Dosyalar

### data/stops_sample.json

Durak bilgilerini tutar.

Alanlar:

- `id`: Duragin benzersiz kimligi.
- `name`: Duragin okunabilir adi.
- `latitude`: Duragin enlem degeri.
- `longitude`: Duragin boylam degeri.

Bu dosya, KdTree veya KNN yapilarinda durak koordinatlarini kullanmak icin temel veri kaynagi olarak dusunulmustur.

### data/lines_sample.json

Toplu tasima hatlarini tutar.

Alanlar:

- `id`: Hattin benzersiz kimligi.
- `name`: Hattin okunabilir adi.
- `type`: Hat tipi. Ornek degerler: `Bus`, `Metro`, `Tram`.
- `stopIds`: Hattin ugradigi durak kimlikleri.

Bu dosya, duraklarin hangi hatlara ait oldugunu gostermek icin kullanilir.

### data/routes_sample.json

Duraklar arasindaki rota veya baglanti verilerini tutar.

Alanlar:

- `id`: Baglantinin benzersiz kimligi.
- `lineId`: Baglantinin ait oldugu hat.
- `fromStopId`: Baslangic duragi.
- `toStopId`: Hedef duragi.
- `distanceKm`: Iki durak arasindaki mesafe.
- `durationMinutes`: Tahmini yolculuk suresi.
- `cost`: Rota algoritmasinda kullanilacak agirlik degeri.

Bu dosya, graf yapisindaki kenarlari olusturmak icin kullanilabilir.

## Repository Siniflari

### StopRepository

`StopRepository`, `stops_sample.json` dosyasindan duraklari okumak icin hazirlanan baslangic sinifidir.

Mevcut temel islemler:

- Tum duraklari okuma.
- Durak kimligine gore durak bulma.
- Dosya bulunamazsa bos liste donme.

### LineRepository

`LineRepository`, `lines_sample.json` ve `routes_sample.json` dosyalarini okumak icin hazirlanan baslangic sinifidir.

Mevcut temel islemler:

- Tum hatlari okuma.
- Tum rota baglantilarini okuma.
- Hat kimligine gore hat bulma.
- Hat kimligine gore rota baglantilarini listeleme.

## Sonraki Adimlar

- Gercek Bursa verisi bulunursa JSON formatina donusturulebilir.
- StopRepository ve LineRepository icin birim testler eklenebilir.
- RouteRecord verileri TransitGraph sinifina aktarilabilir.
- Hata yonetimi ve dosya yolu ayarlari uygulama katmanina tasinabilir.
