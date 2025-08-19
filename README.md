# 🛒 Market Yönetim Sistemi

Bu proje, **.NET Framework MVC** ile geliştirilmiş bir **Market Yönetim Sistemidir**.  
Projede **MSSQL** veritabanı kullanılmış olup, **DB First** yaklaşımı ile Entity Framework üzerinden veri erişimi sağlanmaktadır.  
Arayüz tarafında **Bootstrap 5 Modal** pencereleri ve **JavaScript alert** kutuları kullanılmıştır.  

---

## 🚀 Kullanılan Teknolojiler
- .NET Framework MVC
- Entity Framework (DB First yaklaşımı)
- Microsoft SQL Server (MSSQL)
- Bootstrap 5 (UI & Modal)
- JavaScript (Alert, doğrulama işlemleri)

---

## 📂 Proje Yapısı
```bash
MarketYonetimSistemi/
│── Controllers/
│   └── KategoriController.cs
│   └── UrunController.cs
│   └── MusteriController.cs
│   └── SatisController.cs
│── Models/
│   └── MarketDB.edmx  # DB First veritabanı modeli
│── Views/
│   └── Shared/
│   └── Kategori/
│   └── Urun/
│   └── Musteri/
│   └── Satis/
│── Scripts/
│   └── custom.js
│── Content/
│   └── bootstrap.min.css
│── Global.asax
│── Web.config

