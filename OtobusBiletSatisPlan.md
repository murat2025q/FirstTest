# Otobüs Bilet Satış Programı Planı

## 1. Proje Teknolojileri

- **Frontend:** Angular (Typescript), Bootstrap
- **Backend:** C# (.NET), Dapper
- **Veritabanı:** SQL Server
- **Mimari:** Clean Architecture

---

## 2. Genel Özellikler

- Kullanıcılar için bilet satın alma, rezervasyon, bilet görüntüleme ve iptal etme fonksiyonları
- Yönetici paneli ile sefer ve araç yönetimi
- Sefer ekleme/silme/düzenleme
- Koltuk seçimi ve doluluk takibi
- Fiyatlandırma, güzergah ve şehir seçimi
- Raporlama ve dashboardlar (Yönetici için)
- Kullanıcı kayıt/giriş sistemleri (JWT veya benzeri ile token bazlı authentication)

---

## 3. Modüller ve Bileşenler

### 3.1 Frontend (Angular)
- **Ana Sayfa**: Şehir ve tarih seçimi, sefer arama
- **Sefer Listesi**: Uygun seferlerin ve fiyatların listelenmesi
- **Koltuk Seçimi**: Otobüs koltuk planı, dolu/boş seçim
- **Bilet Satın Alma**: Kullanıcı bilgileri, ödeme ve doğrulama
- **Biletlerim**: Kullanıcının aktif ve geçmiş biletleri
- **Yönetici Paneli**: Sefer, araç, güzergah, kullanıcı yönetimi
- **Ortak Bileşenler**: Navbar, footer, modal, form validator
- **Authentication**: Login, register, şifre sıfırlama ekranları

### 3.2 Backend (.NET)
- **Entity Layer**: User, Bus, Route, Journey, Ticket, Seat, Admin gibi temel domain nesneleri
- **Repository Layer**: Dapper kullanarak veri işlemleri, her bir entity için repository
- **Service Layer**: İş mantığı servisleri
- **API Layer**: Restful endpointler
- **Authentication**: JWT ile login/register endpointleri
- **Exception Middleware ve Validatorlar**
- **DTO ve Mapperlar**: Veri aktarımı için DTO nesneleri ve otomatik eşleme sistemleri

### 3.3 Database (SQL Server)
- User, Bus, Seat, Route, Journey, Ticket tablosu
- Yeterli foreign key yapıları, index ve performans için view/tablo tanımları

---

## 4. Clean Architecture Katmanları

- **Presentation Layer (Angular - API Controller)**
- **Application Layer (.NET Service & DTO)**
- **Domain Layer (Entity, Business Logic)**
- **Infrastructure Layer (Repository, Dapper, DB Context)**

---

## 5. İş Akışları

### 5.1 Bilet Satın Alma
1. Kullanıcı şehir ve tarih seçer, seferler listelenir.
2. Sefer seçilir, koltuk planı gösterilir, koltuk seçimi yapılır.
3. Kişisel bilgiler ve ödeme ekranı gelir.
4. Satın alma tamamlanınca bilet kaydolur ve kullanıcıya bildirim verilir.

### 5.2 Yönetici:
1. Sefer ekleme/düzenleme/silme
2. Otobüs/şoför rota yönetimi
3. Raporlama paneli

---

## 6. Geliştirme ve Kurulum Sırası

1. Veritabanı şeması ve migration'ların hazırlanması
2. Backend domain ve servis altyapısının oluşturulması
3. Dapper ile repositorylerin yazılması
4. JWT authentication entegrasyonu, kullanıcı işlemleri
5. Angular ile temel UI ekranlarının oluşturulması
6. Frontend-backend entegrasyonu (API consumption)
7. Test ve validasyonlar, edge-case senaryoları
8. Son kullanıcılar ve yöneticiler için dokümantasyon

---

## 7. Ekstra Notlar

- Unit & integration testlerine önem verilecek
- API dokümantasyonu (Swagger/OpenAPI)
- Geliştirici ve kullanıcı dökümantasyonu
- Responsive arayüzler için Bootstrap kullanımı

---

## 8. Referanslar

- Clean Architecture (Robert C. Martin)
- Angular, Bootstrap ve .NET dökümantasyonları
