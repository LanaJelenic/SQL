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


INSERT INTO roditelj(ime,prezime,br_mob)
VALUES
('Pero','Marić',095686523),
('Ana','Kraljik',097445123),
('Marija','Perić',095444333),
('Boris','Orešković',09755666);

select*from roditelj;

INSERT INTO dijete(ime,prezime,datum_rodenja)
VALUES
('Luka','Horvat','2021-01-15'),
('Maja','Prigl','2020-04-23'),
('Ante','Bogoviæ','2019-05-05'),
('Iva','Dvojak','2018-06-01'),
('Mila','Horvat','2021-03-18');

select*from dijete;

INSERT INTO odgojna_skupina(naziv,dob)
VALUES 
('jaslice','1-2 god'),
('plava skupina','3 god'),
('ljubičasta skupina','4-5 god');

select*from odgojna_skupina;

INSERT INTO prijava(ID_dijeteta,ID_roditelja,ID_skupine,status,datum_prijave)
values
(5,4,3,0,'2023-04-28'),
(1,4,1,1,'2023-02-25'),
(4,1,3,0,'2023-05-10'),
(3,2,3,1,'2023-01-16'),
(2,3,2,0,'2023-05-26');

select*from prijava;

insert into korisnik(ID_roditelja)
values
(4),
(3),
(2),
(1);

insert into uloga(opis,aktivnost)
values
('administrator',1),
('korisnik',1),
('gost',0);

select*from uloga;

insert into korisnik_usluga(ID_korisnika,ID_uloge)
values
(1,3),
(2,1),
(2,2),
(3,2),
(4,1),
(4,2);

select*from korisnik_usluga;

insert into objava(ID_uloge,naslov,sadrzaj,slika)
values
(1,'naslov01','sadržaj01','slika01'),
(3,'naslov02','sadržaj02','slika02');

select*from objava;

insert into kategorija(ID_objave,naslov)
values
(1,'naslov01'),
(2,'naslov02');

select*from kategorija;

update roditelj set prezime='Horvat'
where ID_roditelja=4;

update roditelj set prezime='Prigl'
where ID_roditelja=3;