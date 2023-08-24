# BookStore
Net Core Framework'ü ile kitap satın alma ve kiralama sitesi
geliştirdim. User işlemleri için Identity mekanizması
kullandım. İçerisinde passwordhash işlemi, JWT , login,
register ve register admin işlemleri için baştan uca ilgili
servisleri yazdım. Mailjet sisteme entegre edilerek Two Factor
Aunthentication işlemi yapıldı. Sistem gereksinimlerine uygun
generic repository design pattern ile temel CRUD işlemlerini
gerçekleştirdim. Generic result yapısıyla birlikte kullanıcıya
istediğimiz hata, doğrulama veya başarılı giriş mesajlarını
gösterme imkanı sundum. Projede PostgreSQL veritabanı
kullandım. SOLID prensipleri gereği özelleştirilmiş interface ve
modeller inşa edildi. DB Entityleri arasında bire bir, bire çok
ilişki kurulup code first yaklaşımıyla veritabanı tabloları
migration ile oluşturuldu. Transaction için UnitOfWork design
pattern kullanıldı. Projede performansı arttırmak için Redis
cache mekanizması entegre edildi ve gerekli CRUD
operasyonlarında kullanıldı. Automapper ile data mapleme
işlemleri yapıldı. Sisteme kitapların ve yazarların fotoğraflarını
yüklemek için IFormFile tipinde generic dosya yükleme
işlemleri yazıld
