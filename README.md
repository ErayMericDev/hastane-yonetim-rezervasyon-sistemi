\# 🏥 Hastane Yönetim ve Randevu Sistemi



Bu proje, \*\*Niğde Ömer Halisdemir Üniversitesi Bilgisayar Mühendisliği\*\* bölümü staj eğitimi kapsamında, \*\*C# Windows Forms\*\* ve \*\*MS SQL Server\*\* kullanılarak geliştirilmiş kapsamlı bir otomasyon sistemidir.



Proje; hastaların randevu almasını, doktorların hastalarını takip etmesini ve sekreterlerin (yönetici) hastane işleyişini organize etmesini sağlayan \*\*rol tabanlı\*\* bir mimariye sahiptir.



\## 🚀 Projenin Amacı

Sağlık kuruluşlarındaki hasta kayıt ve randevu süreçlerini dijitalleştirerek kağıt israfını önlemek, randevu çakışmalarını engellemek ve veri bütünlüğünü sağlamaktır.



\## 🛠️ Kullanılan Teknolojiler ve Araçlar

\* \*\*Dil:\*\* C# (.NET Framework)

\* \*\*Arayüz:\*\* Windows Forms Application (WinForms)

\* \*\*Veritabanı:\*\* Microsoft SQL Server (T-SQL)

\* \*\*Veri Erişimi:\*\* ADO.NET (SqlClient)

\* \*\*IDE:\*\* Visual Studio



\## ⚙️ Modüller ve Özellikler



Sistem 3 temel kullanıcı rolü üzerine kurulmuştur:



\### 1. 😷 Hasta Modülü

\* \*\*Kayıt \& Giriş:\*\* TC Kimlik No ve şifre ile güvenli giriş. (TC No tekrarını engelleyen kontrol mekanizması mevcuttur).

\* \*\*Randevu Alma:\*\* Branş ve doktor seçimi yaparak uygun saatlere randevu oluşturma.

\* \*\*Geçmiş Randevular:\*\* Daha önce alınan randevuların detaylı listesini görüntüleme.

\* \*\*Bilgi Güncelleme:\*\* Kişisel bilgileri düzenleme paneli.



\### 2. 👨‍⚕️ Doktor Modülü

\* \*\*Randevu Takibi:\*\* Doktora atanan randevuların anlık listesi.

\* \*\*Duyuru Sistemi:\*\* Yönetim (Sekreter) tarafından gönderilen duyuruları görüntüleme.

\* \*\*Hasta Detay:\*\* Randevusu olan hastanın şikayet ve detaylarını inceleme.



\### 3. 📝 Sekreter (Yönetici) Modülü

\* \*\*Doktor Yönetimi:\*\* Yeni doktor ekleme, silme ve güncelleme işlemleri (CRUD).

\* \*\*Branş Yönetimi:\*\* Hastaneye yeni poliklinik/branş tanımlama.

\* \*\*Randevu Organizasyonu:\*\* Tüm randevuları listeleme ve yönetme.

\* \*\*Duyuru Paneli:\*\* Tüm doktorlara toplu duyuru yayınlama.



\## 🗄️ Veritabanı Mimarisi



Proje \*\*İlişkisel Veritabanı (RDBMS)\*\* mantığına uygun olarak tasarlanmış ve aşağıdaki tabloları içermektedir:



\* `Tbl\_Hastalar`: Hasta kimlik ve iletişim bilgileri.

\* `Tbl\_Doktorlar`: Doktor branş ve yetki bilgileri.

\* `Tbl\_Randevular`: Hasta ve Doktor arasındaki ilişkiyi kuran ana tablo.

\* `Tbl\_Branslar`: Poliklinik bilgileri.

\* `Tbl\_Duyurular`: Sistem içi mesajlaşma verileri.



\## 📸 Ekran Görüntüleri



!\[Giriş Ekranı](Resimler/giris\_paneli.png)

!\[Hasta Giriş Ekranı](Resimler/hasta\_giris\_paneli.png)

!\[Hasta Detay Ekranı](Resimler/hasta\_detay\_paneli.png)

!\[Hasta Kayıt Ekranı](Resimler/hasta\_kayit\_paneli.png)

!\[Doktor Giriş Ekranı](Resimler/doktor\_giris\_paneli.png)

!\[Doktor Detay Ekranı](Resimler/doktor\_detay\_paneli.png)

!\[Doktor Kayıt Ekranı](Resimler/doktor\_kayit\_paneli.png)

!\[Sekreter Giriş Ekranı](Resimler/sekreter\_giris\_paneli.png)

!\[Sekreter Detay Ekranı](Resimler/sekreter\_detay\_paneli.png)

!\[Branş Ekleme Ekranı](Resimler/brans\_ekleme\_paneli.png)

!\[Duyurular Ekranı](Resimler/duyuru\_paneli.png)

!\[Geçmiş Randevular Ekranı](Resimler/gecmis\_randevular\_paneli.png)

!\[Randevular Ekranı](Resimler/randevu\_paneli.png)





\## 📦 Kurulum



1\.  Projeyi bilgisayarınıza indirin (Clone).

2\.  `SqlBaglantisi.cs` sınıfı içerisindeki \*\*Connection String\*\* (Bağlantı Adresi) satırını kendi SQL Server adresinize göre güncelleyin.

3\.  Veritabanını oluşturmak için proje dosyasındaki `script.sql` dosyasını çalıştırın (veya tabloları manuel oluşturun).

4\.  Projeyi Visual Studio üzerinden başlatın (Start).



---

👤 \*\*Geliştirici:\*\* \[Eray Meriç](https://github.com/ErayMericDev)

🎓 \*\*Kurum:\*\* Niğde Ömer Halisdemir Üniversitesi - Bilgisayar Mühendisliği

