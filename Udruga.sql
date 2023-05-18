create database udruga1;
use udruga1

create table osoba(
ID_osobe int not null primary key identity(1,1),
ime varchar(50),
prezime varchar(50),
iban varchar(50)
);

create table prostor(
ID_prostora int not null primary key identity (1,1),
dimenzije varchar(50),
maks_broj int
);

create table sticenik_udruge (
sticenikID int not null primary key identity(1,1),
vrsta varchar(50),
podvrsta varchar(100),
tezina decimal(18,2),
zivotni_vijek varchar(50),
ID_osobe int foreign key references osoba(ID_osobe),
ID_prostora int foreign key references prostor(ID_prostora)
);

insert into osoba(ime,prezime,iban)
values
('Petar','Perišić','HR12132453'),
('Marko','Marić','HR2314676454'),
('Karlo','Jakšić','HR3232323'),
('Jakov','Šimunović','HR6565');

select*from osoba;

insert into prostor(dimenzije,maks_broj)
values
('200x200',5),
('180x100',4),
('160x100',3),
('66x45',2);

select*from prostor;

insert into sticenik_udruge(vrsta,podvrsta,tezina,zivotni_vijek,ID_osobe,ID_prostora)
values
('Konj','Lipicanac',700,'10-15 god',4,1),
('Konj','Arapski',750,'15-16 god',3,2),
('Konj','Frizijski',800,'25-30 god',2,3),
('Pas','Border Collie',20,'10-17 god',1,4);

select*from sticenik_udruge;
