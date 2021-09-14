# Proje Yapısı ve Açıklaması

Generic Repository ve Unit of Work yapısı ile kurgulanmış ihtiyaç olunan bir cok yapıyı içinde bulunduran ve kendim için referans olan bir projedir. Normalde bir Case olarak başladığım bu projeye zamanım oldukça yeni projeler ve yapılar eklenecektir.

## ****** Shared *******
Microservis mimarisi için repository ve uow yapısı generic olarak yazılmıstır. Temel olarak buraya eklenen her projenin Domain ve Infrastructure katmanları bu yapıdan türeyecektir.
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
Aşağıdaki gibi her bir proje gerekli dizinlere erişilerek çalıştırılabilir.

`dotnet run --project ./PowerPlant/PowerPlant.API/PowerPlant.API.csproj`

## Proje Ağacı
1. ![image](https://user-images.githubusercontent.com/62391718/133316249-6a933cda-6f9e-4931-ae48-987e86651cec.png)

## Çalışan Ekran Görüntüleri
1. ![image](https://user-images.githubusercontent.com/62391718/133315636-cdf09d91-8a59-446f-9765-aeccebccf58a.png)
2. ![image](https://user-images.githubusercontent.com/62391718/133315848-9c572826-0dbd-493b-b95c-b2b0bffa330a.png)
3. ![image](https://user-images.githubusercontent.com/62391718/133315910-c8f78361-5fa4-4630-b2b7-fa47143c8d0a.png)




