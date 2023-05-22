create database odvjetnik;
use odvjetnik

create table klijent(
ID_klijenta int not null primary key identity(1,1),
ime varchar(50),
prezime varchar(50)
);

create table obrana(
ID_obrane int not null primary key identity(1,1),
ID_klijenta int foreign key references klijent(ID_klijenta)
);

create table suradnik(
ID_suradnika int not null primary key identity(1,1),
ime varchar(50),
prezime varchar(50)
);

create table obrana_suradnik(
ID_obrane int foreign key references obrana(ID_obrane),
ID_suradnika int foreign key references suradnik(ID_suradnika)
);

insert into klijent(ime,prezime)
values
('Iva','Dvojak'),
('Ante','Bogoviæ'),
('Luka','Horvat');

select*from klijent;

insert into obrana(ID_klijenta)
values
(1),
(2),
(3);

select*from obrana;

insert into suradnik(ime,prezime)
values
('Ivo','Pospišil'),
('Laura','Bogoviæ'),
('Kruno','Blaževiæ');

select*from suradnik;

insert into obrana_suradnik(ID_obrane,ID_suradnika)
values
(1,2),
(1,3),
(2,1),
(3,3);

select*from obrana_suradnik;