create database vatrogasno_dr;
use vatrogasno_dr

create table objava(
ID_objave int not null primary key identity(1,1),
naslov varchar(50),
sadrzaj varchar(50),
slika varchar(100)
);

create table kategorija(
ID_kategorije int not null primary key identity(1,1),
ID_objave int foreign key references objava(ID_objave),
naslov varchar(50)
);

create table korisnik(
ID_korisnika int not null primary key identity(1,1),
ime varchar(50),
prezime varchar(50),
adresa varchar(50),
email varchar(50)
);

create table uloga(
ID_uloge int not null primary key identity(1,1),
opis varchar(50),
aktivnost bit
);

create table korisnik_usluga(
ID_korisnika int foreign key references korisnik(ID_korisnika),
ID_uloge int foreign key references uloga(ID_uloge)
);