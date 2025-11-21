# Minimarket Stok Takip Projesi - Gelişim Takip Dosyası

## Son Güncelleme: 2025-11-21

---

## Şimdiye Kadar Yapılanlar

### 1. Proje Planı ve Yol Haritası
- Projenin ana planı ve gereksinimleri belirlendi (Plan.md hazırlanıp repoya eklendi).
- Teknoloji seçimi (C#, WPF, SQL Server, EF Core) ve temel mimari netleştirildi.

### 2. Repo ve Branch Ayarları
- `main` dalında temel şablon dosyaları oluşturuldu.
- Geliştirme için `feature/minimarket-initial-setup` isimli branch açıldı.

### 3. Proje İskeleti ve Temel Dosyalar
- WPF uygulaması için temel dosyalar eklendi (App.xaml, MainWindow.xaml).
- EF Core ile Product modeli ve DbContext tanımlandı.
- .gitignore, README.md, appsettings.json eklendi.

### 4. İlk Test ve Seed
- Basit ürün seed işlemi ve DB initializer eklendi.

### 5. Product CRUD ve MVVM Temelli UI
- `ProductsView` ve `ProductsViewModel` ile ürünleri listeleme, ekleme, silme, güncelleme fonksiyonları eklendi.
- Komutlar (RelayCommand) ve MVVM yapısı aktif edildi.
- Ana pencere ile ürün modülü entegre edildi.

### 6. Gelişmiş Validasyon ve Hata Yönetimi (TAMAMLANDI)
- Ürün ekle/sil/güncelle işlemleri sırasında zorunlu alan ve veri tipi kontrolleri eklendi.
- Kullanıcıya hata uyarı mesajları arayüzde gösteriliyor.

---

## Sıradaki Yapılacaklar

### 1. Kategori CRUD
- Category modelinin eklenmesi ve veritabanına migration yapılması.
- CategoryViewModel ve CategoryView ile kategori ekleme/listeleme/düzenleme/silme için arayüz.
- Ürünlerle kategori ilişkisi kurulması (Product > CategoryId).

### 2. Kullanıcı Yönetimi
- Kullanıcı/rol ekleme ve login arayüzü

### 3. Stok Hareketleri ve Raporlama Modülleri
- Stok giriş/çıkış ve işlem geçmişi
- Temel satış (sale) modülü ve rapor ekranlara giriş

### 4. Veritabanı Bağlantısı ve Migration Yönetimi
- EF Core migration adımları ve script ile database güncelleme

### 5. UI Geliştirmeleri
- Görsel iyileştirmeler: ikonlar, responsive layout, tema
- Klavye ile kullanım kolaylığı

### 6. Yedekleme ve Ayar Modülü
- Manuel ve otomatik veritabanı yedekleme/güncelleme
- Ayarların GUI üzerinden yönetimi

### 7. Test ve Dağıtım
- Birim ve entegrasyon testleri
- Installer veya MSIX paket üretimi

---

## Kapsam Dışı / Gelecek Sürümler (Opsiyonel)
- Mobil uygulama entegrasyonu (Android/iOS)
- Fatura/POS cihazı entegrasyonu
- Çoklu şube desteği ve senkronizasyon
- Envanter sayım modülü

---

## Notlar & Takip
- Her özellik ekleme/tamamlama sonrası bu dosya güncellenecek.
- Dallar birleştirilip (merge) production (main) sürüme PR ile alınacak.
- Genel kod ve proje durumunu buradan takip edebilirsiniz.
