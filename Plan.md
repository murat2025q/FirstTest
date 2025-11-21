# Minimarкет Stok Takip Programı - Plan

Versiyon: 1.0  
Teknolojiler: C# (WPF, MVVM), .NET 6/7 (karar verilecek), Entity Framework Core veya Dapper, SQL Server  
Yazar: murat2025q  
Tarih: 2025-11-21

## 1. Proje Özeti
Küçük/orta ölçekli bir minimarket için masaüstü tabanlı stok yönetimi uygulaması. Amaç; ürün giriş/çıkışlarını, satışları, stok seviyelerini ve raporlamayı güvenli, hızlı ve kullanıcı dostu bir arayüzle sağlamaktır.

## 2. Hedefler
- Güncel stok seviyelerini gerçek zamanlı izleme
- Ürünlerin üretici/tedarikçi ve kategori bazlı yönetimi
- Satış işlemleri ve fatura/fiş kaydı
- Stok hareketleri (giriş, çıkış, düzeltme) kaydı ve raporlaması
- Rol tabanlı kullanıcı yönetimi (kasiyer, yönetici)
- Veri yedekleme / geri yükleme
- Basit, responsive WPF arayüzü (masaüstü uygulaması için)

## 3. Kapsam (MVP)
- Kullanıcı girişi ve yetkilendirme
- Ürün ve kategori CRUD
- Stok giriş/çıkış ve stok düzeltme
- Satış modülü (basit faturalandırma - fiş)
- Günlük / aylık satış ve stok raporları
- Veritabanı yedekleme/geri yükleme
- Temel güvenlik (şifre hash, SQL injection koruması via ORM/parametreli sorgular)

## 4. Kullanıcı Rolleri ve İzinler
- Yönetici: Tüm işlemler (ürün, stok, rapor, kullanıcı)
- Kasiyer: Satış yapma, satış geçmişi görüntüleme, stok çıkışı (sadece satış kaynaklı)
- Depo Görevlisi: Stok giriş/çıkış, ürün güncelleme (fiyat hariç) — opsiyonel

## 5. Temel Fonksiyonel Gereksinimler
- Kullanıcı Yönetimi (giriş, şifre değişikliği)
- Ürün Yönetimi: Barkod, isim, marka, kategori, birim, maliyet, satış fiyatı, KDV, kritik stok seviyesi
- Kategori Yönetimi
- Tedarikçi Yönetimi (opsiyonel)
- Stok Hareketleri: Tür (Giriş, Çıkış, Düzeltme), miktar, neden, tarih, referans (fatura numarası)
- Satış: Satış oluşturma (barkod ile ürün ekleme), ödeme türü, toplam, stoktan düşme, satış kaydı
- Raporlama: Satış raporu (tarih aralığı), stok raporu (kritik seviyeler), en çok satan ürünler
- Yedekleme/Geri Yükleme: Manuel SQL yedekleme, düzenli yedekleme planlama (opsiyonel)
- Loglama: Hata logları ve işlem logları (kullanıcı bazlı)

## 6. Non-Fonksiyonel Gereksinimler
- Performans: 100.000 ürün / 1 milyon satış kaydına ölçeklenebilirlik (DB optimizasyonu)
- Güvenlik: Parola hashing (PBKDF2/BCrypt/Argon2), parametreli sorgular/ORM
- Kullanılabilirlik: Basit ve temiz arayüz, hızlı barkod girişi destekli
- Yedeklenebilirlik: Veritabanı yedekleri .bak veya SQL export
- Bakım: Katmanlı mimari (UI, Business, Data)

## 7. Yüksek Seviyeli Mimari
- Sunucu: SQL Server (Local/Network)
- İstemci: WPF uygulaması (MVVM pattern)
- Data Erişim: Entity Framework Core (DbContext, Repository Pattern) veya Dapper (performans gerekiyorsa)
- Servis Katmanı: Business logic + Validation
- Logger: Serilog veya NLog (dosya + opsiyonel DB)
- Dependency Injection: Microsoft.Extensions.DependencyInjection

Basit akış:
WPF View -> ViewModel -> Service/Repository -> EF Core -> SQL Server

## 8. Veri Modeli (Temel Tablolar)
- Users (Id, Username, PasswordHash, FullName, Role, CreatedAt, LastLogin)
- Categories (Id, Name, Description)
- Suppliers (Id, Name, ContactInfo) — opsiyonel
- Products (Id, Barcode, Name, CategoryId, SupplierId, Unit, CostPrice, SalePrice, VAT, CriticalStock, CreatedAt)
- StockMovements (Id, ProductId, MovementType, Quantity, Date, Reference, UserId, Note)
- Sales (Id, SaleNumber, Date, TotalAmount, UserId, PaymentType)
- SaleItems (Id, SaleId, ProductId, Quantity, UnitPrice, Discount)
- Settings (Id, Key, Value)

Örnek CREATE TABLE (kısa):
```sql
CREATE TABLE Products (
  Id INT IDENTITY PRIMARY KEY,
  Barcode NVARCHAR(50) NULL,
  Name NVARCHAR(200) NOT NULL,
  CategoryId INT NULL,
  SupplierId INT NULL,
  Unit NVARCHAR(20),
  CostPrice DECIMAL(18,2),
  SalePrice DECIMAL(18,2),
  VAT DECIMAL(5,2),
  CriticalStock INT DEFAULT 0,
  CreatedAt DATETIME DEFAULT GETDATE()
);
```

## 9. UI Ekranları / Modüller
- Giriş (Login)
- Ana Panel (Dashboard): Günlük satış özetleri, kritik stok uyarıları
- Ürünler: Liste, filtre, yeni ürün ekle, düzenle, sil
- Kategoriler: CRUD
- Stok Hareketleri: Giriş/Çıkış formu, geçmiş arama
- Satış Ekranı: Barkod ile hızlı satış, satışı tamamlama, fiş yazdırma/ekran
- Raporlar: Tarih aralıklı satış raporu, stok raporu, en çok satanlar
- Ayarlar: Veritabanı bağlantısı, yedekleme, kullanıcı yönetimi
- Yardım / Hakkında

Not: Satış ekranı klavye odaklı ve barkod okuyucu uyumlu olmalı.

## 10. İş Akış Örnekleri
- Yeni ürün ekleme: Yönetici -> Ürünler -> Yeni -> Barkod, Fiyat, Stok bilgileri -> Kaydet
- Satış: Kasiyer -> Satış ekranı -> Barkod okut -> Miktar kontrol -> Ödeme tipi seç -> Satışı tamamla -> Satış kaydı + stoktan düş
- Stok düzeltme: Depo görevlisi -> Stok Hareketleri -> Düzeltme -> Açıklama zorunlu

## 11. Test Planı
- Unit testler: İş kuralları, stok hesaplama, fiyat doğrulama
- Entegrasyon testleri: DB işlemleri (in-memory veya test DB)
- Kullanıcı kabul testleri: Önemli senaryolar (satış, iade/düzeltme, yedekleme)
- Performans testi: Çoklu satış simülasyonu (opsiyonel)

## 12. Dağıtım / Kurulum
- Hedef platform: Windows 10/11
- Dağıtım seçenekleri:
  - MSIX/Installer (Windows Installer) — tercih
  - ClickOnce (basit güncelleme)
- DB: SQL Server Express veya tam SQL Server. Kurulum talimatı ve connection string konfigürasyonu sağlanacak.
- Yedekleme: Periyodik .bak alma betiği önerisi

## 13. CI / CD (Opsiyonel)
- GitHub Actions ile:
  - Build pipeline: .NET build + test
  - Artifacts: installer üretimi
  - Release: manuel/otomatik

## 14. Güvenlik ve Uyumluluk
- Parolalar hash'lenmiş şekilde saklanacak
- Yetkilendirme: Role-based erişim kontrolleri
- SQL injection önlemi: ORM veya parametreli sorgular
- Veritabanı erişimi için ayrı DB kullanıcıları (yetkiler sınırlı)
- Hassas veriler loglara yazılmayacak

## 15. Riskler & Karşı Önlemler
- Veritabanı bozulması -> Düzenli yedekleme + restore testleri
- Performans düşüşü (büyük veri) -> Index optimizasyonu, arşivleme stratejisi
- Kullanıcı hataları -> İşlem logları, geri alma mekanizması (stok düzeltme kaydı)

## 16. Yol Haritası / Milestones (Örnek 8 haftalık plan)
- Sprint 0 (1 hafta) — Proje kurulumu, gereksinim doğrulama, DB taslağı
- Sprint 1 (2 hafta) — Auth, Users, Categories, Products CRUD, temel DB
- Sprint 2 (2 hafta) — Stok hareketleri, stoka yansıtma, StockMovements
- Sprint 3 (2 hafta) — Satış ekranı, Sale ve SaleItems, stoktan düşme
- Sprint 4 (1 hafta) — Raporlar, yedekleme, dağıtım paketleme, UAT

Tahmini toplam: 6-8 hafta (1 geliştirici, tam zamanlı). Kaynak/ek süre: Test ve düzeltmeler için +1-2 hafta.

## 17. Kabul Kriterleri (Örnek)
- Ürün eklenebiliyor, stok güncelleniyor ve satış sonrası stok azalıyor
- Kullanıcı girişi ve rol kontrolleri çalışıyor
- Raporlar doğru veri döndürüyor (ör. günlük satış toplamı)
- Veritabanı yedeği alınabiliyor ve geri yüklendiğinde temel veriler geri geliyor

## 18. Gelecek İyileştirmeler (Sonraki Sürümler)
- Barkod yazdırma & etiket basma
- Fatura (yazıcı) entegrasyonu ve POS yazıcı desteği
- Mobil uygulama veya web paneli (stok kontrol için)
- Envanter sayım modülü (sayım fişi, karşılaştırma)
- Çoklu kasa/şube desteği, senkronizasyon

## 19. Sonraki Adımlar
1. Teknoloji kararının kesinleştirilmesi (.NET sürümü, EF Core vs Dapper).  
2. Minimal veri modeli & ER diyagram onayı.  
3. Sprint 0: Repo oluşturma, temel solution/çözüm iskeleti, CI pipeline başlangıcı.  
4. İlk sprint için görevlerin detaylandırılması ve atama.

---

İsterseniz şu adımlarda yardımcı olabilirim:
- Teknoloji seçimi (EF Core vs Dapper) için karşılaştırma ve öneri,
- ER diyagramı ve tam SQL şeması hazırlama,
- Sprint 1 için detaylı görev listesi (GitHub issues formatında).
