# Pati Veteriner Yönetim Sistemi

## Proje Hakkında

ASP.NET Core tabanlı veteriner klinik yönetim sistemi.

## Teknolojiler

- **VetAPI** — ASP.NET Core Web API + Dapper + Stored Procedure
- **VetMVC** — ASP.NET Core MVC + Entity Framework Core
- **Veritabanı** — SQL Server

## Özellikler

- Admin girişi (Session tabanlı)
- Çalışan, Hasta, İlaç, Tedavi yönetimi (CRUD)
- Arama ve filtreleme (Clustered/Non-Clustered Index)
- Dashboard — istatistikler ve aylara göre tedavi grafiği
- Stored Procedure ile veri işlemleri (API)
- Entity Framework ile veri işlemleri (MVC)

## Ekran Görüntüleri

![Giriş](../VetMvc/screenshots/login-page.png)
![Dashboard](../VetMvc/screenshots/dashboard.png)
![Tedavi Ekleme](../VetMvc/screenshots/create-treatment-in-doctor-page.png)

## Kurulum

1. SQL Server LocalDB kurulu olmalı
2. SSMS'de `VetApiDb` veritabanını oluştur (API için)
3. SSMS'de `VetDb` veritabanını oluştur (MVC için)
4. Tabloları, procedure'leri ve index'leri oluştur
5. Connection string'lerini `appsettings.json` dosyalarında güncelle
6. API ve MVC projelerini aynı anda başlat

## Varsayılan Giriş

- **Email:** admin@pati.com
- **Şifre:** admin123
