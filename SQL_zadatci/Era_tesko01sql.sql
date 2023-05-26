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

alter table objava add ID_uloge int foreign key references uloga(ID_uloge);

insert into objava(naslov,sadrzaj,slika)
values
('objava01','sadrzaj01','slika01'),
('objava02','sadrzaj02','slika02'),
('objava03','sadrzaj03','slika03'),
('objava04','sadrzaj04','slika04'),
('objava05','sadrzaj05','slika05');

select*from objava;

insert into kategorija(ID_objave,naslov)
values
(3,'dogaðanja'),
(4,'vijesti'),
(5,'galerija');

select*from kategorija;

insert into korisnik(ime,prezime,email)
values
('Luka','Horvat','lhorvat@gmail.com'),
('Maja','Prigl','pmaja@gmail.com'),
('Ante','Bogoviæ','abogovic@gmail.com'),
('Iva','Dvojak','dvojak.iva@gmail.com');

select*from korisnik;

insert into uloga(opis,aktivnost)
values
('administrator',1),
('korisnik',0),
('gost',1);

select*from uloga;

insert into korisnik_usluga(ID_korisnika,ID_uloge)
values
(1,2),
(2,3),
(3,1),
(4,2);

select*from korisnik_usluga;
