create database urar1;
use urar1

create table sat(
ID_sata int not null primary key identity(1,1),
marka varchar(50),
boja varchar(20)
);

create table korisnik(
ID_korisnika int not null primary key identity(1,1),
ID_sata int foreign key references sat(ID_sata),
Ime varchar(50),
Prezime varchar(50),
Kontakt int
);

create table popravak(
ID_popravka int not null primary key identity(1,1),
Cijena decimal (18,2),
poc_popravka datetime,
zavrs_popravak datetime
);

create table segrt(
ID_segrta int not null primary key identity (1,1),
ID_popravka int foreign key references popravak(ID_popravka),
Ime varchar(50),
Prezime varchar(50),
);

create table popravak_sat(
ID_popravka int foreign key references popravak(ID_popravka),
ID_sata int foreign key references sat(ID_sata)
);

insert into sat(marka,boja)
values
('Boss','srebrna'),
('Lacoste','crna'),
('Guess','zlatna');

select*from sat;

insert into korisnik(ID_sata,Ime,Prezime,Kontakt)
values
(1,'Maja','Kraljik',0954645),
(2,'Karlo','Dvojak',09732334),
(3,'Eva','Lovrić',0957878);

select*from korisnik

insert into popravak(Cijena,poc_popravka,zavrs_popravak)
values
(1.99,'2023-05-15 13:00:00','2023-05-15 16:00:00'),
(5.00,'2023-05-16','2023-05-20'),
(4.30,'2023-05-17','2023-05-18');

select*from popravak;

insert into segrt(ID_popravka,Ime,Prezime)
values
(3,'0','0'),
(2,'Marko','Markić'),
(1,'Ivo','Ivanić');

select*from segrt;

insert into popravak_sat(ID_popravka,ID_sata)
values
(1,1),
(3,2),
(2,3),
(3,1),
(1,2);

select*from popravak_sat;
