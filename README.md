# IncomeAndExpenseStatement
# Gelir - Gider Takip Sistemi 💰

Bu proje; kullanıcıların kişisel veya kurumsal finansal süreçlerini düzenli bir şekilde kaydedebildiği, güncelleyebildiği, analiz edebildiği ve verilerini raporlayabildiği gelişmiş bir masaüstü finans takip uygulamasıdır.

## 🚀 Projenin Amacı ve Çözdüğü Problemler

**Amacı:** Kullanıcıların finansal işlemlerini düzenli, kontrollü ve güvenli bir şekilde takip etmesini sağlamak[cite: 4, 10].

]**Çözdüğü Problemler:** 
* Harcamaların kontrolsüz yapılması. 
* Gelir-gider dengesinin bilinmemesi. 
* Finansal verilerin dağınık tutulması.
* Aylık analiz yapılamaması.
* Gereksiz harcamaların fark edilememesi 

---

## 📸 Ekran Görüntüleri (Screenshots)


### Ana Ekran ve İşlem Yönetimi
[cite_start]Uygulamanın ana arayüzü üzerinden tüm gelir/gider verileri listelenebilir, anlık bakiye takibi yapılabilir ve yeni işlemler eklenebilir[cite: 5, 8].

![Ana Ekran](<img width="1122" height="845" alt="Ekran görüntüsü 2026-05-22 192045" src="https://github.com/user-attachments/assets/867cebdb-c1ee-4fe2-a8a7-1f910e2e17ed" />
)
*Açıklama: Tür, Kategori, Tutar ve Açıklama alanları ile dinamik veri girişi, DataGridView üzerinde listeleme ve alt bölümde anlık Toplam Gelir, Toplam Gider ve Güncel Bakiye hesaplamaları.*

---

## 🛠️ Teknik Özellikler ve Mimari

### [cite_start]Kullanılan Teknolojiler [cite: 5]
* [cite_start]**Programlama Dili:** C# (.NET Framework) [cite: 5]
* [cite_start]**Geliştirme Ortamı:** Visual Studio [cite: 5]
* [cite_start]**Veri Tabanı:** Microsoft SQL Server [cite: 2, 5]
* [cite_start]**Raporlama:** Microsoft Excel Entegrasyonu [cite: 2, 5]

### [cite_start]Sistem Mimarisi [cite: 7]
[cite_start]Proje, kodun sürdürülebilirliği ve okunabilirliği açısından **Katmanlı Mimari (3-Tier Architecture)** kullanılarak geliştirilmiştir[cite: 7, 10]:
1.  [cite_start]**Presentation Layer (Sunum Katmanı):** Windows Forms mimarisi ile tasarlanmış kullanıcı arayüzü[cite: 7].
2.  [cite_start]**Business Layer (İş Mantığı Katmanı):** Finansal hesaplamalar ve iş kurallarının işletildiği katman[cite: 7].
3.  [cite_start]**Data Access Layer (Veri Erişim Katmanı):** SQL Server ile iletişim kuran ve CRUD işlemlerini yürüten katman[cite: 7, 10].

### [cite_start]Veri Tabanı Şeması [cite: 6]
* [cite_start]**Kategoriler Tablosu:** `KategoriID` (PK, int), `KategoriAdi` (nvarchar) [cite: 6]
* [cite_start]**İşlemler Tablosu:** `IslemID` (PK, int), `Tur` (Gelir/Gider), `Tutar` (decimal), `KategoriID` (int), `Tarih` (date), `Aciklama` (nvarchar) [cite: 6]

---

## 💻 Fonksiyonel Özellikler (Kullanımı)

[cite_start]Uygulama temel olarak şu dinamik işlevleri başarıyla yerine getirmektedir[cite: 10]:
* [cite_start]**CRUD İşlemleri:** Gelir ve gider verilerini ekleme, silme, güncelleme ve listeleme[cite: 5, 10].
* [cite_start]**Filtreleme ve Arama:** Kategoriye göre filtreleme ve tarihe göre spesifik işlem arama[cite: 5].
* [cite_start]**Anlık Analiz:** Sisteme girilen verilere göre otomatik olarak *Toplam Gelir*, *Toplam Gider* ve *Güncel Bakiye* hesaplaması[cite: 5].
* [cite_start]**Dışa Aktarım:** Listelenen tüm finansal verilerin tek tıkla Excel formatına aktarılması ve raporlanması[cite: 3, 5, 10].

---

## 🛠️ Kurulum ve Çalıştırma Talimatları

1.  **Projeyi Klonlayın:**
    ```bash
    git clone [https://github.com/kullanici-adiniz/gelir-gider-takip-sistemi.git](https://github.com/kullanici-adiniz/gelir-gider-takip-sistemi.git)
    ```
2.  **Veri Tabanı Yapılandırması:**
    * SQL Server üzerinde `Kategoriler` ve `Islemler` tablolarını dokümandaki şemaya uygun olarak oluşturun.
    * Projenin Veri Erişim Katmanındaki (Data Access Layer) bağlantı adresini (Connection String) kendi yeral SQL Server adresinizle güncelleyin.
3.  **Çalıştırma:**
    * Projeyi Visual Studio ile açın.
    * Gerekli bağımlılıkların yüklenmesi için projeyi derleyin (Build) ve `Start` butonuna basarak uygulamayı çalıştırın.

---

## 🤝 Katkıda Bulunanlar
* **Lütfullah Çelik** - [2023212011]

