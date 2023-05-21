create database restoran1;
use restoran1

create table jelo(
ID_jela int not null primary key identity(1,1),
ime varchar(50),
cijena decimal(18,2)
);

create table kategorija(
ID_kategorije int not null primary key identity(1,1),
ID_jela int foreign key references jelo(ID_jela),
naziv varchar(50)
);

create table pice(
ID_pica int not null primary key identity(1,1),
ime varchar(50),
cijena decimal(18,2)
);

create table jelo_pice(
ID_jela int foreign key references jelo(ID_jela),
ID_pica int foreign key references pice(ID_pica)
);

insert into jelo(ime,cijena)
values
('Lignje',9.89),
('Ćevapi',6.00),
('Ražnjići',9.50);

select*from jelo;

insert into kategorija(ID_jela,naziv)
values
(1,'Morska jela'),
(2,'Grill'),
(3,'Piletina');

select*from kategorija;

insert into pice(ime,cijena)
values
('Coca cola',1.99),
('Juice',1.00),
('Jamnica',2.00),
('Sok od jabuke',1.50);

select*from pice;

insert into jelo_pice(ID_jela,ID_pica)
values
(1,1),
(1,2),
(2,2),
(2,3),
(3,3),
(3,4);

select*from jelo_pice;
