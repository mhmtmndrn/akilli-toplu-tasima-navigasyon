# Proje Konu 5 - Akıllı Toplu Taşıma ve Navigasyon Sistemi

## Proje Bilgileri

**Proje Adı:** Akıllı Toplu Taşıma ve Navigasyon Sistemi  
**Ders:** Veri Yapıları  
**Proje Konusu:** Proje Konu 5  
**GitHub Repository:** https://github.com/mhmtmndrn/akilli-toplu-tasima-navigasyon

Bu proje, bir şehrin toplu taşıma ağını veri yapıları ve graf algoritmaları kullanarak modellemeyi amaçlamaktadır. Projede duraklar düğüm, duraklar arasındaki ulaşım bağlantıları ise mesafe, süre ve hat bilgisi taşıyan kenarlar olarak ele alınmaktadır.

Temel amaç; kullanıcının bulunduğu konuma en yakın durakları bulmak, duraklar arası ulaşım ağını graf yapısı ile temsil etmek ve başlangıç-hedef noktaları arasında uygun rotayı hesaplamaktır.

---

## Grup Üyeleri ve Görev Dağılımı

| Ad Soyad | Öğrenci No | Görev Alanı | Branch |
|---|---:|---|---|
| Mehmet Emin Duran | 032390042 | Veri yapıları ve temel modeller | `feature-emin` |
| Kerem Beyaz | 032390054 | Simülasyon ve API entegrasyonu | `feature-kerem` |
| Şükrü Çoşkun | 032390063 | Bursa veri seti ve hat modelleme | `feature-sukru` |
| Taha Akman | 032390073 | Harita arayüzü ve etkileşim | `feature-taha` |
| Ali İhsan Dağaşan | 032390077 | Graf ve rota algoritmaları | `feature-ali` |

---

## Ara Rapor Durumu

Ara rapor aşamasında ekip üyeleri için ayrı branch’ler oluşturulmuş ve her üye kendi görev alanına uygun şekilde geliştirme sürecine dahil edilmiştir.

Bu kapsamda yapılan işlemler:

- GitHub repository oluşturuldu.
- Ekip üyeleri repository’ye collaborator olarak eklendi.
- Her ekip üyesi için ayrı feature branch oluşturuldu.
- Her ekip üyesi kendi branch’i üzerinden çalışma yaptı.
- Her branch’ten main/master branch’e Pull Request açıldı.
- Pull Request süreci kullanılarak ekip içi versiyon kontrol akışı başlatıldı.
- Proje görev dağılımı belirlendi.
- Projenin temel dosya ve klasör yapısı oluşturulmaya başlandı.
- README.md dosyası ara rapor niteliğinde güncellendi.

---

## Pull Request Bilgileri

| Branch | Pull Request | Açıklama |
|---|---|---|
| `feature-ali` | #2 | Graf ve rota algoritmaları için başlangıç çalışmaları |
| `feature-emin` | #3 | Veri yapıları ve temel modeller için başlangıç çalışmaları |
| `feature-taha` | #4 | Harita arayüzü ve kullanıcı etkileşimi için başlangıç çalışmaları |
| `feature-sukru` | #5 | Bursa veri seti ve hat modelleme için başlangıç çalışmaları |
| `feature-kerem` | #7 | Simülasyon ve API entegrasyonu için başlangıç çalışmaları |

---

## Projenin Amacı

Bu proje ile şehir içi toplu taşıma sisteminin sadeleştirilmiş bir modeli oluşturulacaktır. Kullanıcıdan alınan başlangıç ve hedef konum bilgilerine göre en yakın duraklar belirlenecek, bu duraklar üzerinden en uygun rota hesaplanacaktır.

Projenin temel hedefleri:

- Durakları koordinat bilgileriyle birlikte sistemde tutmak
- Kullanıcı konumuna en yakın durakları bulmak
- Toplu taşıma hatlarını graf yapısı ile modellemek
- Duraklar arası en kısa veya en uygun rotayı hesaplamak
- Rota sonucunu kullanıcıya anlaşılır şekilde göstermek
- Aktarma, mesafe ve süre gibi maliyetleri rota hesabına dahil etmek

---

## Kullanılacak Temel Veri Yapıları

### 1. Kd-Tree / Quad-Tree

Durakların iki boyutlu koordinat bilgilerini tutmak ve kullanıcının bulunduğu konuma en yakın durakları daha verimli bulmak için kullanılacaktır.

Bu yapı sayesinde tüm durakları tek tek gezmek yerine, konuma yakın duraklar daha hızlı sorgulanabilecektir.

Kullanım amacı:

- Durak koordinatlarını saklamak
- En yakın K durağı bulmak
- Konum bazlı arama performansını artırmak

---

### 2. Graph / Multigraph

Toplu taşıma ağı graf olarak modellenecektir.

- Düğümler: Duraklar
- Kenarlar: Duraklar arası bağlantılar
- Kenar bilgileri: Mesafe, süre, hat bilgisi

Aynı iki durak arasında birden fazla ulaşım hattı bulunabileceği için multigraph yapısı desteklenebilir.

Kullanım amacı:

- Duraklar arası ulaşım ilişkilerini tutmak
- Rota hesaplamak
- Hat ve aktarma bilgilerini modellemek

---

### 3. Min-Heap / Priority Queue

Dijkstra algoritmasında en düşük maliyetli düğümü seçmek için kullanılacaktır.

Kullanım amacı:

- En kısa yol algoritmasını verimli çalıştırmak
- Dijkstra algoritmasında öncelikli düğüm seçimi yapmak
- Rota maliyetini optimize etmek

---

### 4. Hash Table

Durak ve hat bilgilerine hızlı erişim sağlamak için kullanılacaktır.

Örnek kullanım:

- Durak ID → Durak bilgisi
- Hat ID → Hat üzerindeki duraklar

Kullanım amacı:

- Duraklara hızlı erişmek
- Hat bilgilerini hızlı sorgulamak
- Ortalama O(1) erişim sağlamak

---

## Kullanılacak Algoritmalar

### 1. K-Nearest Neighbors

Kullanıcının bulunduğu konuma en yakın K durağı bulmak için kullanılacaktır.

Bu algoritma spatial tree yapısı üzerinde çalıştırılarak doğrusal aramaya göre daha verimli sonuç alınması hedeflenmektedir.

---

### 2. Dijkstra Algoritması

Başlangıç ve hedef duraklar arasında en düşük maliyetli rotayı bulmak için kullanılacaktır.

Rota maliyeti aşağıdaki kriterlere göre hesaplanabilir:

- Kullanıcının durağa yürüme mesafesi
- Duraklar arası ulaşım mesafesi
- Duraklar arası tahmini süre
- Aktarma sayısı
- Aktarma yapılması durumunda ek maliyet

---

### 3. A* Algoritması

A* algoritması opsiyonel olarak değerlendirilecektir. Heuristic kullanılarak Dijkstra algoritmasına göre daha hızlı rota hesaplama yapılması hedeflenebilir.

---

## Proje Mimarisi

Proje C# dili kullanılarak geliştirilecektir. Temel mimari aşağıdaki modüllerden oluşacaktır:

```text
akilli-toplu-tasima-navigasyon/
│
├── src/
│   ├── Models/
│   │   ├── Stop.cs
│   │   ├── Route.cs
│   │   ├── Line.cs
│   │   └── Edge.cs
│   │
│   ├── DataStructures/
│   │   ├── Graph.cs
│   │   ├── MinHeap.cs
│   │   ├── HashTable.cs
│   │   └── SpatialTree.cs
│   │
│   ├── Algorithms/
│   │   ├── Dijkstra.cs
│   │   ├── KNearestNeighbors.cs
│   │   └── AStar.cs
│   │
│   ├── Services/
│   │   ├── RouteService.cs
│   │   ├── StopService.cs
│   │   └── SimulationService.cs
│   │
│   └── Program.cs
│
├── docs/
│   ├── ara-rapor.md
│   ├── proje-raporu.md
│   └── uml-diyagramlari/
│
├── README.md
└── .gitignore
