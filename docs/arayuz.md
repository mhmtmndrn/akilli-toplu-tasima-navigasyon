# Arayuz Baslangic Plani

Bu dokuman, Harita Arayuzu ve Etkilesim gorev branch'i icin hazirlanan baslangic arayuz iskeletini aciklar.

Proje bu asamada console tabanli olarak dusunulmustur. Final asamasinda ayni akis web, masaustu veya harita tabanli bir gorsel arayuze tasinabilir.

## ConsoleMenu

`ConsoleMenu`, kullanicinin temel islemleri secmesini temsil eden baslangic sinifidir.

Mevcut placeholder islemler:

- Ana menu seceneklerini gosterme.
- Baslangic noktasini temsil eden koordinat secimi.
- Hedef noktasini temsil eden koordinat secimi.
- En yakin duraklari gosterme.
- Rota sonucunu gosterme.

Bu sinif, ileride kullanici giris dogrulama, menu dongusu ve servis katmani baglantilari ile genisletilebilir.

## MapRenderer

`MapRenderer`, harita veya rota gosterimi icin ayrilan baslangic sinifidir.

Mevcut placeholder islemler:

- Bos harita alanini console uzerinde temsil etme.
- Secilen baslangic ve hedef noktalarini yazdirma.
- En yakin durak listesini yazdirma.
- Rota sonucunu durak sirasi olarak yazdirma.

Final projede bu sinif yerine gercek bir harita bileseni, grid tabanli gosterim veya web arayuzu kullanilabilir.

## Planlanan Etkilesim Akisi

1. Kullanici baslangic koordinatini secer.
2. Kullanici hedef koordinatini secer.
3. Sistem KNN veya KdTree kullanarak en yakin duraklari bulur.
4. Sistem graf ve Dijkstra algoritmasi ile rota hesaplar.
5. Arayuz en yakin duraklari ve rota sonucunu gosterir.

## Sonraki Adimlar

- ConsoleMenu icin gercek menu dongusu eklenebilir.
- Kullanici girdileri icin hata kontrolu guclendirilebilir.
- MapRenderer, frontend veya harita kutuphanesi ile degistirilebilir.
- Rota sonucu icin aktarma, sure ve mesafe bilgileri gosterilebilir.
