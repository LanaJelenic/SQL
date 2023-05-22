create database opg;
use opg

create table proizvod(
ID_proizvoda int not null primary key identity(1,1),
Naziv varchar(50),
cijena decimal(18,2)
);

create table sirovina(
ID_sirovine int not null primary key identity(1,1),
naziv varchar(50)
);

create table sirovina_proizvod(
ID_sirproz int not null primary key identity(1,1),
ID_sirovine int foreign key references sirovina(ID_sirovine),
ID_proizvoda int foreign key references proizvod(ID_proizvoda)
);

create table djelatnik(
ID_djelatnika int not null primary key identity(1,1),
ID_proizvoda int foreign key references proizvod(ID_proizvoda),
ime varchar(50),
prezime varchar(50)
);

insert into proizvod(Naziv,cijena)
values
('Krema od lavande',3.00),
('Ulje od ruže',4.77),
('ulje od koprive',3.56);

select*from proizvod;

insert into sirovina(naziv)
values
('lavanda'),
('ruža'),
('kopriva');

select*from sirovina;

insert into sirovina_proizvod(ID_sirovine,ID_proizvoda)
values
(1,1),
(2,2),
(3,3),
(3,2);

select*from sirovina_proizvod;

insert into djelatnik(ID_proizvoda,ime,prezime)
values
(1,'0','0'),
(2,'Luka','Horvat'),
(3,'Maja','Horvat');

select*from djelatnik;