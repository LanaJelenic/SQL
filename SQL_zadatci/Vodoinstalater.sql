create database vodoinstalater1;
use vodoinstalater1

create table kvar(
ID_kvara int not null primary key identity(1,1),
naziv varchar(50)
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

create table popravak_kvar(
ID_popravka int foreign key references popravak(ID_popravka),
ID_kvara int foreign key references kvar(ID_kvara)
);

insert into kvar(naziv)
values
('kvar01'),
('kvar02'),
('kvar03');

select*from kvar;


insert into popravak(Cijena,poc_popravka,zavrs_popravak)
values
(1.99,'2023-05-15 13:00:00','2023-05-15 16:00:00'),
(5.00,'2023-05-16','2023-05-20'),
(4.30,'2023-05-17','2023-05-18');

select*from popravak;

insert into segrt(ID_popravka,Ime,Prezime)
values
(3,'0','0'),
(2,'Marko','Markiæ'),
(1,'Ivo','Ivaniæ');

select*from segrt;

insert into popravak_kvar(ID_popravka,ID_kvara)
values
(1,1),
(3,2),
(2,3),
(3,1),
(1,2);

select*from popravak_kvar;