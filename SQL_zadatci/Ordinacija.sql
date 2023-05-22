create database Ordinacija1;
use Ordinacija1

create table lijecenje(
ID_lijecenja int not null primary key identity(1,1),
Naziv varchar(50),
Cijena decimal
);

create table pacijent(
ID_pacijenta int not null primary key identity(1,1),
ID_lijecenja int foreign key references lijecenje(ID_lijecenja),
ime varchar(50),
prezime varchar(20),
zdravstvena int
);


insert into lijecenje(Naziv,Cijena)
values
('Upala grla',10.00),
('Slomljena ruka',20.00),
('Upala pluca',16.90);

select*from lijecenje;

insert into pacijent(ID_lijecenja,Ime,Prezime,zdravstvena)
values
(1,'Maja','Kraljik',0954645),
(2,'Karlo','Dvojak',09732334),
(3,'Eva','Lovrić',0957878);

select*from pacijent;




