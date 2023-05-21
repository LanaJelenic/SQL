create database trg_centar1;
use trg_centar1

create table trgovina(
ID_trgovine int not null primary key identity(1,1),
Naziv varchar(50)
);

create table osoba(
ID_osobe int not null primary key identity(1,1),
Ime varchar(50),
Prezime varchar(50),
sef int
);
alter table osoba add foreign key(sef)references osoba(ID_osobe);

create table trg_osoba(
ID_trgovine int foreign key references trgovina(ID_trgovine),
ID_osobe int foreign key references osoba(ID_osobe)
);

insert into trgovina(Naziv)
values
('Zara'),
('New Yorker'),
('Konzum'),
('Telemach');

select*from trgovina;

insert into osoba(Ime,Prezime)
values
('Iva','Dvojak'),
('Ante','Bogović'),
('Luka','Horvat'),
('Kruno','Blažević');

select*from osoba;

insert into trg_osoba(ID_trgovine,ID_osobe)
values
(1,1),
(2,2),
(3,3),
(4,4),
(4,2);

select*from trg_osoba;

