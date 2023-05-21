create database srednja1;
use srednja1

create table ucenik(
ID_ucenika int not null primary key identity(1,1),
Ime varchar(50),
Prezime varchar(50),
);

create table razred(
ID_razreda int not null primary key identity(1,1),
ID_ucenika int foreign key references ucenik(ID_ucenika),
Naziv varchar(50),
Br_sobe int
);

create table profesor(
ID_profesora int not null primary key identity(1,1),
Ime varchar(50),
Prezime varchar(50)
);

create table prof_raz(
ID_profesora int foreign key references profesor(ID_profesora),
ID_razreda int foreign key references razred(ID_razreda)
);

insert into ucenik(Ime,Prezime)
values
('Luka','Horvat'),
('Maja','Prigl'),
('Ante','Bogović'),
('Iva','Dvojak');

select*from ucenik;

insert into razred(ID_ucenika,Naziv,Br_sobe)
values
(1,'1.b',24),
(2,'2.c',26),
(3,'3.k2',33),
(4,'4.a',18);

select*from razred;

insert into profesor(Ime,Prezime)
values
('Ivo','Pospišil'),
('Laura','Bogović'),
('Kruno','Blažević'),
('Petar','Perišić');

select*from profesor;

insert into prof_raz(ID_profesora,ID_razreda)
values
(1,4),
(1,3),
(2,1),
(3,2),
(4,4),
(4,1);

select*from prof_raz;
