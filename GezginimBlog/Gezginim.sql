CREATE DATABASE GezginimBlog_DB
GO
USE GezginimBlog_DB
GO
CREATE TABLE YoneticiTurler
(
 ID int IDENTITY(1,1),
 Isim nvarchar(60) NOT NULL,
 CONSTRAINT pk_yoneticiTur PRIMARY KEY(ID)
)
GO
INSERT INTO YoneticiTurler(Isim) VALUES('admin')
CREATE TABLE Yoneticiler
(
 ID int IDENTITY(1,1),
 YoneticiTurID int,
 Isim nvarchar(60),
 Soyad nvarchar(60),
 Email nvarchar(130),
 Sifre nvarchar(20),
 Durum bit,
 CONSTRAINT pk_yonetici PRIMARY KEY(ID),
 CONSTRAINT fk_yoneticiYoneticiTur FOREIGN KEY(YoneticiTurID) REFERENCES YoneticiTurler(ID)
)
GO
INSERT INTO Yoneticiler(YoneticiTurID, Isim, Soyad, Email, Sifre, Durum)
VALUES(1,'Ramazan', 'Ucak', 'ramo@gmail.com', '88888',1)
CREATE TABLE Uyeler
(
 ID int IDENTITY(1,1),
 Isim nvarchar(60),
 Soyad nvarchar(60),
 Email nvarchar(130),
 Sifre nvarchar(20),
 UyelikTarihi datetime,
 Durum bit,
 CONSTRAINT pk_Uye PRIMARY KEY(ID) 
)
GO

CREATE TABLE Sehirler
(
 ID int IDENTITY(1,1),
 Isim nvarchar(100),
 CONSTRAINT pk_sehir PRIMARY KEY(ID)
)
GO
CREATE TABLE Deneyimler
( 
 ID int IDENTITY(1000,1),
 SehirID int,
 YazarID int,
 Baslik nvarchar(300),
 Onyazi nvarchar(500),
 Icerik nvarchar(MAX),
 GeziResim nvarchar(75),
 GoruntulemeSayisi int,
 EklemeTarihi datetime,
 Durum bit,
 CONSTRAINT pk_deneyim PRIMARY KEY(ID),
 CONSTRAINT fk_makaleSehir FOREIGN KEY(SehirID) REFERENCES Sehirler(ID),
 CONSTRAINT fk_makaleYazar FOREIGN KEY(YazarID) REFERENCES Yoneticiler(ID) 
)
GO
CREATE TABLE Yorumlar
( 
 ID int IDENTITY(1,1),
 UyeID int,
 DeneyimID int,
 Icerik nvarchar(500),
 YorumTarih datetime,
 OnayDurum bit,
 CONSTRAINT pk_yorum PRIMARY KEY(ID),
 CONSTRAINT fk_yorumDeneyim FOREIGN KEY(DeneyimID) REFERENCES Deneyimler(ID),
 CONSTRAINT fk_yorumUye FOREIGN KEY(UyeID) REFERENCES Uyeler(ID)  
)
SELECT*FROM Uyeler
SELECT*FROM Yorumlar