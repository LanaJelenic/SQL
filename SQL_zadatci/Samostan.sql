
create database samostan;
use samostan

create table svecenik(
ID_svecenika int not null primary key identity(1,1),
ime varchar(50),
sv_ime varchar(60)
);

create table posao(
ID_posla int not null primary key identity(1,1),
naziv varchar(50)
);

create table svecenik_posao(
ID_svecenika int foreign key references svecenik(ID_svecenika),
ID_posla int foreign key references posao(ID_posla)
);	

create table nadredeni(
ID_svecenika int foreign key references svecenik(ID_svecenika),
ime varchar(50),
svime varchar(60)
);

insert into svecenik(ime,sv_ime)
values
('Nick','Franjo'),
('Emil','Ivan'),
('Ante','Luka');

select*from svecenik;

insert into posao(naziv)
values
('održavanje mise'),
('priprema hostije'),
('obuka ministranata'),
('krizmanje'),
('pogreb');

select*from posao;

insert into svecenik_posao(ID_svecenika,ID_posla)
values
(1,1),
(1,3),
(2,1),
(3,2),
(3,5),
(2,4);

select* from svecenik_posao;

alter table nadredeni add ID_nadredenog int not null primary key identity(1,1);

insert into nadredeni(ID_svecenika,ime,svime)
values
(1,'Pavao','Matej'),
(2,'Pavao','Matej'),
(3,'Pavao','Matej');

select*from nadredeni;
