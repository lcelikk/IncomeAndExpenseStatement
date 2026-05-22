# IncomeAndExpenseStatement
# Gelir - Gider Takip Sistemi 💰

Bu proje; kullanıcıların kişisel veya kurumsal finansal süreçlerini düzenli bir şekilde kaydedebildiği, güncelleyebildiği, analiz edebildiği ve verilerini raporlayabildiği gelişmiş bir masaüstü finans takip uygulamasıdır.

## 🚀 Projenin Amacı ve Çözdüğü Problemler

**Amacı:** Kullanıcıların finansal işlemlerini düzenli, kontrollü ve güvenli bir şekilde takip etmesini sağlamak.

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

![Ana Ekran]<img width="1122" height="845" alt="Ekran görüntüsü 2026-05-22 192045" src="https://github.com/user-attachments/assets/9ebe430f-27c3-4e9c-b56b-a63271ec371e" />

)
*Açıklama: Tür, Kategori, Tutar ve Açıklama alanları ile dinamik veri girişi, DataGridView üzerinde listeleme ve alt bölümde anlık Toplam Gelir, Toplam Gider ve Güncel Bakiye hesaplamaları.*

---

## 🛠️ Teknik Özellikler ve Mimari

### Kullanılan Teknolojiler 
* **Programlama Dili:** C# (.NET Framework) 
* **Geliştirme Ortamı:** Visual Studio 
* **Veri Tabanı:** Microsoft SQL Server 
* **Raporlama:** Microsoft Excel Entegrasyonu 

### Sistem Mimarisi 
Proje, kodun sürdürülebilirliği ve okunabilirliği açısından **Katmanlı Mimari (3-Tier Architecture)** kullanılarak geliştirilmiştir:
1.  **Presentation Layer (Sunum Katmanı):** Windows Forms mimarisi ile tasarlanmış kullanıcı arayüzü.
2.  **Business Layer (İş Mantığı Katmanı):** Finansal hesaplamalar ve iş kurallarının işletildiği katman.
3.  **Data Access Layer (Veri Erişim Katmanı):** SQL Server ile iletişim kuran ve CRUD işlemlerini yürüten katman.

### Veri Tabanı Şeması 
* **Kategoriler Tablosu:** `KategoriID` (PK, int), `KategoriAdi` (nvarchar) 
* **İşlemler Tablosu:** `IslemID` (PK, int), `Tur` (Gelir/Gider), `Tutar` (decimal), `KategoriID` (int), `Tarih` (date), `Aciklama` (nvarchar) 

---

## 💻 Fonksiyonel Özellikler (Kullanımı)

]Uygulama temel olarak şu dinamik işlevleri başarıyla yerine getirmektedir:
* **CRUD İşlemleri:** Gelir ve gider verilerini ekleme, silme, güncelleme ve listeleme.
* **Filtreleme ve Arama:** Kategoriye göre filtreleme ve tarihe göre spesifik işlem arama.
* **Anlık Analiz:** Sisteme girilen verilere göre otomatik olarak *Toplam Gelir*, *Toplam Gider* ve *Güncel Bakiye* hesaplaması.
* **Dışa Aktarım:** Listelenen tüm finansal verilerin tek tıkla Excel formatına aktarılması ve raporlanması.

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

