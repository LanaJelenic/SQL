create database crvenkapica;
use crvenkapica

create table roditelj(
ID_roditelja int not null primary key identity(1,1),
ime varchar(50),
prezime varchar(50),
br_mob int
);

create table dijete(
ID_dijeteta int not null primary key identity(1,1),
ime varchar(50),
prezime varchar(50),
datum_rodenja datetime
);

create table odgojna_skupina(
ID_skupine int not null primary key identity(1,1),
naziv varchar(50),
dob varchar(50)
);

create table prijava(
ID_prijave int not null primary key identity(1,1),
ID_dijeteta int foreign key references dijete(ID_dijeteta),
ID_roditelja int foreign key references roditelj(ID_roditelja),
ID_skupine int foreign key references odgojna_skupina(ID_skupine),
status bit,
datum_prijave datetime
);

create table korisnik(
ID_korisnika int not null primary key identity(1,1),
ID_roditelja int foreign key references roditelj(ID_roditelja)
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

create table objava(
ID_objave int not null primary key identity(1,1),
ID_uloge int foreign key references uloga(ID_uloge),
naslov varchar(50),
sadrzaj varchar(50),
slika varchar(100)
);

create table kategorija(
ID_kategorije int not null primary key identity(1,1),
ID_objave int foreign key references objava(ID_objave),
naslov varchar(50)
);