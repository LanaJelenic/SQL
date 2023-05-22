create database Klub_citatelja;
use Klub_citatelja

create table clan(
ID_clana int not null primary key identity(1,1),
ime varchar(50),
prezime varchar(50),
cl_broj int,
vlasnik int
);

create table knjiga(
ID_knjige int not null primary key identity(1,1),
naslov varchar(50),
pisac varchar(100),
datum_pos datetime,
datum_vrac datetime
);

alter table clan add foreign key(vlasnik)references clan(ID_clana);

create table posudba(
ID_posudbe int not null primary key identity(1,1),
ID_clana int foreign key references clan(ID_clana),
ID_knjige int foreign key references knjiga(ID_knjige)
);

insert into clan(ime,prezime,cl_broj)
values
('Ivo','Pospišil',254),
('Mara','Božiæ',255),
('Kruno','Blaževiæ',256),
('Laura','Bogoviæ',257);

select*from clan;

insert into knjiga(naslov,pisac,datum_pos,datum_vrac)
values
('Institut','Stephen King','2023-04-01','2023-04-11'),
('Crnooke suzane','Julia Heaberlin','2023-04-02','2023-04-12'),
('Planina straha','Agustín Martínez','2023-04-03','2023-04-13'),
('Išèezli utorak','Nicci French','2023-04-04','2023-04-14');

select*from knjiga;

insert into posudba(ID_clana,ID_knjige)
values
(1,2),
(2,1),
(3,4),
(4,3);

select*from posudba;