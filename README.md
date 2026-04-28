# Akıllı Toplu Taşıma ve Navigasyon Sistemi

## 1. Proje Bilgileri

**Ders:** Veri Yapıları  
**Proje Konusu:** Konu 5  
**Proje Adı:** Akıllı Toplu Taşıma ve Navigasyon Sistemi  
**Proje Ekibi:**  
- MEHMET EMİN DURAN - 032390042
- KEREM BEYAZ - 032390054
- ŞÜKRÜ ÇOŞKUN - 032390063
- TAHA AKMAN - 032390073
- ALİ İHSAN DAĞAŞAN - 032390077

---

## 2. Projenin Amacı

Bu projenin amacı, bir şehrin toplu taşıma ağını veri yapıları ve algoritmalar kullanarak modelleyen sadeleştirilmiş bir navigasyon sistemi geliştirmektir.

Sistemde duraklar graf yapısındaki düğümler olarak, duraklar arasındaki ulaşım bağlantıları ise mesafe, süre ve hat bilgisi taşıyan kenarlar olarak temsil edilmektedir. Kullanıcının bulunduğu konuma en yakın durakların bulunması ve başlangıç-hedef noktaları arasında en uygun rotanın hesaplanması hedeflenmektedir.

Proje kapsamında temel olarak şu işlemler gerçekleştirilecektir:

- Toplu taşıma duraklarının koordinat bilgileriyle saklanması
- Kullanıcının konumuna en yakın durakların bulunması
- Duraklar arası ulaşım ağının graf yapısıyla modellenmesi
- Başlangıç ve hedef durak arasında en uygun rotanın hesaplanması
- Rota sonucunun sade bir arayüz veya görselleştirme ile gösterilmesi
- Kullanılan veri yapılarının zaman ve uzay karmaşıklıklarının analiz edilmesi

---

## 3. Problem Tanımı

Günlük hayatta toplu taşıma kullanan kişiler, bulundukları konuma en yakın durağı ve hedeflerine ulaşmak için en uygun rotayı hızlı bir şekilde öğrenmek ister. Bu problem, veri yapıları açısından iki ana alt probleme ayrılabilir:

1. **En yakın durak bulma problemi:**  
   Kullanıcının konumu verildiğinde, bu konuma en yakın K adet durağın bulunması gerekir.

2. **En uygun rota bulma problemi:**  
   Başlangıç durağı ile hedef durağı arasında mesafe, süre veya aktarma sayısı gibi maliyetlere göre en uygun yolun hesaplanması gerekir.

Bu projede bu iki problem, spatial tree yapıları, graf yapısı, öncelik kuyruğu ve hash table gibi veri yapıları kullanılarak çözülmeye çalışılacaktır.

---

## 4. Kullanılacak Veri Yapıları

### 4.1 KD-Tree / Quad-Tree

Durakların 2 boyutlu koordinatlarını tutmak için kullanılacaktır. Kullanıcının konumu sisteme girildiğinde, bu konuma en yakın K durağı bulmak amacıyla spatial tree yapısından yararlanılacaktır.

Bu yapı sayesinde tüm durakları tek tek dolaşmak yerine, daha verimli bir arama yapılması hedeflenmektedir.

**Kullanım amacı:**

- Durak koordinatlarını saklamak
- Kullanıcının konumuna en yakın durakları bulmak
- KNN algoritmasının daha verimli çalışmasını sağlamak

---

### 4.2 Graph / Multigraph

Toplu taşıma ağı graf yapısı ile temsil edilecektir.

- Düğümler: Duraklar
- Kenarlar: Duraklar arası ulaşım bağlantıları
- Kenar özellikleri:
  - Mesafe
  - Süre
  - Hat bilgisi
  - Aktarma bilgisi

Aynı iki durak arasında birden fazla toplu taşıma hattı bulunabileceği için sistemde multigraph mantığı da desteklenebilir.

**Kullanım amacı:**

- Duraklar arası bağlantıları saklamak
- Rota hesaplama algoritmalarını çalıştırmak
- Hatlar arası geçişleri temsil etmek

---

### 4.3 Min-Heap / Priority Queue

Dijkstra algoritmasında en düşük maliyetli düğümü seçmek için kullanılacaktır. Böylece rota hesaplama işlemi daha verimli hale getirilecektir.

**Kullanım amacı:**

- Dijkstra algoritmasında sıradaki en düşük maliyetli durağı seçmek
- Rota maliyetlerini karşılaştırmak
- Öncelikli düğüm işlemlerini hızlı gerçekleştirmek

---

### 4.4 Hash Table

Durak ve hat bilgilerine hızlı erişim sağlamak için kullanılacaktır.

Örnek kullanım:

- Durak ID → Durak bilgisi
- Hat ID → Hat üzerindeki duraklar
- Durak adı → Durak ID

**Kullanım amacı:**

- Durak bilgilerine hızlı erişmek
- Hat bilgilerini hızlı sorgulamak
- Rota hesaplama sırasında düğüm bilgilerini verimli şekilde almak

---

## 5. Kullanılacak Algoritmalar

### 5.1 K-Nearest Neighbors

Kullanıcının konumuna en yakın K adet durağı bulmak için kullanılacaktır. Kullanıcıdan alınan konum bilgisi KD-Tree veya Quad-Tree üzerinde sorgulanarak en yakın duraklar listelenecektir.

**Örnek:**

Kullanıcı konumu: `(x, y)`  
Sorgu sonucu: En yakın 3 durak

---

### 5.2 Dijkstra Algoritması

Başlangıç durağı ile hedef durağı arasında en düşük maliyetli rotayı bulmak için kullanılacaktır.

Rota maliyeti şu bileşenlere göre hesaplanabilir:

- Kullanıcıdan başlangıç durağına yürüme mesafesi
- Duraklar arası ulaşım süresi veya mesafesi
- Aktarma yapılması durumunda ek aktarma maliyeti

Bu sayede sistem yalnızca en kısa yolu değil, aynı zamanda en hızlı veya en az aktarmalı rotayı da değerlendirebilecek şekilde genişletilebilir.

---

### 5.3 A* Algoritması

A* algoritması opsiyonel olarak değerlendirilecektir. Eğer proje ilerleyen aşamalarda daha gelişmiş hale getirilirse, Dijkstra algoritmasına ek olarak A* algoritması kullanılabilir.

A* algoritması, hedefe olan tahmini uzaklığı da hesaba kattığı için bazı durumlarda Dijkstra algoritmasına göre daha hızlı sonuç verebilir.

---

## 6. Sistem Mimarisi

Proje aşağıdaki temel bileşenlerden oluşacaktır:

```text
Kullanıcı Konumu
       |
       v
KD-Tree / Quad-Tree
       |
       v
En Yakın Durakların Bulunması
       |
       v
Graph / Multigraph
       |
       v
Dijkstra Algoritması
       |
       v
Rota Sonucu ve Görselleştirme
