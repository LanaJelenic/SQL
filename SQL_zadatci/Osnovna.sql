create database osnovna1;
use osnovna1

create table radionica(
ID_radionice int not null primary key identity(1,1),
naziv varchar(50),
br_sobe int
);

create table dijete(
ID_dijeteta int not null primary key identity(1,1),
ime varchar(50),
prezime varchar(50)
);

create table radionica_dijete(
ID_radionice int foreign key references radionica(ID_radionice),
ID_dijeteta int foreign key references dijete(ID_dijeteta)
);

create table uciteljica(
ID_uciteljice int not null primary key identity(1,1),
ID_radionice int foreign key references radionica(ID_radionice),
ime varchar(50),
prezime varchar(50)
);

insert into radionica(naziv,br_sobe)
values
('Crtanje',8),
('Kiparenje',10),
('Igra vodenim bojicama',5);

select*from radionica;

insert into dijete(ime,prezime)
values
('Luka','Horvat'),
('Maja','Prigl'),
('Ante','Bogoviæ'),
('Iva','Dvojak'),
('Anja','Sarić'),
('Marko','Josipović'),
('Ema','Antunović'),
('Josip','Ćupić');

select*from dijete;

insert into radionica_dijete(ID_radionice,ID_dijeteta)
values
(3,2),
(3,3),
(1,1),
(1,4),
(1,5),
(2,6),
(2,7),
(2,8),
(2,2);

select*from radionica_dijete;

insert into uciteljica(ime,prezime,ID_radionice)
values
('Ana','Anić',3),
('Mila','Barišić',2),
('Antonela','Ivić',1);

select*from uciteljica;
