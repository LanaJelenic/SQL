create database knjiznica;
use knjiznica

create table clan(
ID_clana int not null primary key identity(1,1),
ime varchar(50),
prezime varchar(50),
br_iskaznice int,
lozinka varchar(10),
status bit
);

create table evidencija_posudbe(
ID_posudbe int not null primary key identity(1,1),
ID_clana int foreign key references clan(ID_clana),
datum_posudbe datetime,
datum_vracanja datetime
);

create table knjiga(
ID_knjige int not null primary key identity(1,1),
naslov varchar(50),
ime_autora varchar(50),
prezime_autora varchar(50),
sazetak varchar(250),
br_stranica int,
slika varchar(100)
);

create table knjiga_posudba(
ID_knjige int foreign key references knjiga(ID_knjige),
ID_posudbe int foreign key references evidencija_posudbe(ID_posudbe)
);