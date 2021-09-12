# Proje Yapısı ve Açıklaması

Generic Repository ve Unit of Work yapısı ile kurgulanmış ihtiyaç olunan bir cok yapıyı içinde bulunduran ve kendim için referans olan bir projedir. Normalde bir Case olarak başladığım bu projeye zamanım oldukça yeni projeler ve yapılar eklenecektir.

## ****** Shared *******
Micro servis mimarisi için repository ve uow yapısı generic olarak yazılmıstır. Temel olarak buraya eklenen her projenin Domain ve Infrastructure katmanları bu yapıdan türeyecektir.
### Shared.Domain
Bu katman ile implement edilecek soyut yapılar tanımlanacaktır

### Shared.Infrastructure
Bu katmanda genel olarak DataAccess kodlarının ve bunların uygulamaları bulunacaktır. Domain'den uygulanan yapılar burada implement edilecektir.

## PowerPlant
Santrallerin ürettikleri verileri saatte bir çekip kaydeden ve bu santrallerin eklenip cıkarılabildiği bir senaryo ile bir arayüz uygulması ve bu uygulamanın testlerini içermektedir.

#### ** DDD mimaris ile kurulmuş yapıda: **
- .net core webapi --> Arayüz katmanlarına veri sağlamak için geliştirilmiştir.
- belirli zamanlarda background servis olarak çalışan bir WorkerService
- CRUD işlemleri için xunit ile yazılmış unit test projesi
- Front-End için Angular projesi
- ve bunların altyapısını sağlayan Domain, Infrastructure ve Service projeleri
bulunmaktadır. 
        

## Çalıştırılması
### Docker ile Çalıştırılması
Docker Desktop uygulası kurularak docker-compose.yml dosyası ile tüm proje çalıştırılabilir. Projelerin docker build dosyaları ayrıca ana dizinde bulunmaktadır. 

### Visual Studio ile Çalıştırılması
Mevcut veritabanı sunucusuna DbContext migrate edilerek ve ConnectionString de gerekli değişiklikler yapılarak Visual Studio üzerinden çoklu proje çalıştırma seçeneği ile proje çalıştırılabilir.

### .Net CLI ile Çalıştırılması
Mevcut veritabanı sunucusuna DbContext migrate edilerek ve ConnectionString de gerekli değişiklikler yapılarak komut satırından proje çalıştırılabilir.



