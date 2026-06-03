# Harita Arayuzu

Projenin gorsel arayuzu `docs/demo-map.html` dosyasinda hazirlanan Leaflet tabanli harita demosudur. Arayuz Bursa haritasi uzerinde metro ve otobus hatlarini gosterir.

## Temel Akis

1. Kullanici `Baslangic Sec` modunu acar ve haritaya tiklar.
2. Kullanici `Hedef Sec` modunu acar ve haritaya tiklar.
3. Sistem baslangic konumuna en yakin K duragi KdTree uzerinden bulur.
4. Sistem hedef konumuna en yakin duragi bulur.
5. Dijkstra algoritmasi MinHeap kullanarak toplu tasima grafi uzerinde rotayi hesaplar.
6. Arayuz yurume baglantilarini, toplu tasima rotasini, aktarma duraklarini ve maliyetleri gosterir.

## Harita Uzerinde Gosterilenler

- Bursa harita katmani
- BursaRay M1 ve M2 hatlari
- Belli basli otobus koridorlari
- Tum durak markerlari
- Secilen baslangic ve hedef konumlari
- En yakin K durak
- Dijkstra ile hesaplanan rota
- Aktarma duraklari

## Rota Maliyet Bilgileri

Sol panelde rota maliyeti parcalara ayrilarak gosterilir:

- Yurume maliyeti
- Ulasim maliyeti
- Aktarma cezasi
- Toplam maliyet

Bu yapi, proje tanimindaki harita tabanli konum secimi, en yakin durak bulma, rota cizimi ve aktarma gosterimi maddelerini karsilar.
