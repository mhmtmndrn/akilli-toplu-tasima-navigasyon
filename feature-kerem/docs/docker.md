# Docker ile Calistirma

Bu proje icin Docker destegi eklenmistir. Docker Desktop kurulu olan bir bilgisayarda ayni ortamda calistirilabilir.

## Gereksinim

- Docker Desktop

## Image Olusturma

```powershell
docker build -t smart-transit-navigation .
```

## Container Calistirma

```powershell
docker run --rm smart-transit-navigation
```

## Docker Compose ile Calistirma

```powershell
docker compose up --build
```

## Not

Bu container C# konsol demosunu calistirir. Harita demosu `docs/demo-map.html` dosyasidir ve tarayicida acilir.
