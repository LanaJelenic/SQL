create database postolar1;
use postolar1

create table obuca(
ID_obuce int not null primary key identity(1,1),
marka varchar(50),
boja varchar(20),
broj int
);

create table korisnik(
ID_korisnika int not null primary key identity(1,1),
ID_obuce int foreign key references obuca(ID_obuce),
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



create table popravak_obuca(
ID_popravka int foreign key references popravak(ID_popravka),
ID_obuce int foreign key references obuca(ID_obuce)
);

insert into obuca(marka,boja,broj)
values
('Convers','crvena',39),
('Rebook','crna',45),
('nike','plava',40);

select*from obuca;

insert into korisnik(ID_obuce,Ime,Prezime,Kontakt)
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


insert into popravak_obuca(ID_popravka,ID_obuce)
values
(4,1),
(3,2),
(2,3),
(3,1),
(4,2);

select*from popravak_obuca;
