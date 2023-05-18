create database aplikacija;
use aplikacija

create table osoba(
ID_osobe int not null primary key identity(1,1),
ime varchar(25),
prezime varchar(25),
datum_rodenja datetime,
email varchar(50),
lozinka varchar(60),
broj_tel int,
slika varchar(100),
administrator bit,
stanje bit,
aktivan bit,
uniqueid varchar(225)
);

create table objava(
ID_objave int not null primary key identity(1,1),
naslov varchar(50),
opis varchar(250),
vrijeme_izrade datetime,
IP_adresa varchar(20),
ID_osobe int foreign key references osoba(ID_osobe)
);

create table komentar(
ID_komentara int not null primary key identity(1,1),
vrijeme_komentiranja datetime,
opis varchar(250),
ID_objave int foreign key references objava(ID_objave),
ID_osobe int foreign key references osoba(ID_osobe)
);

create table svida_mi_se_komentar(
ID_svida_mi_se_komentar int not null primary key identity(1,1),
ID_osobe int foreign key references osoba(ID_osobe),
ID_komentara int foreign key references komentar(ID_komentara)
);

create table svida_mi_se(
ID_svida_mi_se int not null primary key identity(1,1),
vrijeme_svidanja datetime,
ID_objave int foreign key references objava(ID_objave),
ID_osobe int foreign key references osoba(ID_osobe)
);