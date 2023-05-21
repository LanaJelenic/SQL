create database aplikacija;
use aplikacija

create table osoba(
ID_osobe int not null primary key identity(1,1),
ime varchar(25),
prezime varchar(25),
datum_rodenja datetime,
email varchar(50),
lozinka varchar(60),
broj_tel int,
slika varchar(100),
administrator bit,
stanje bit,
aktivan bit,
uniqueid varchar(225)
);

create table objava(
ID_objave int not null primary key identity(1,1),
naslov varchar(50),
opis varchar(250),
vrijeme_izrade datetime,
IP_adresa varchar(20),
ID_osobe int foreign key references osoba(ID_osobe)
);

create table komentar(
ID_komentara int not null primary key identity(1,1),
vrijeme_komentiranja datetime,
opis varchar(250),
ID_objave int foreign key references objava(ID_objave),
ID_osobe int foreign key references osoba(ID_osobe)
);

create table svida_mi_se_komentar(
ID_svida_mi_se_komentar int not null primary key identity(1,1),
ID_osobe int foreign key references osoba(ID_osobe),
ID_komentara int foreign key references komentar(ID_komentara)
);

create table svida_mi_se(
ID_svida_mi_se int not null primary key identity(1,1),
vrijeme_svidanja datetime,
ID_objave int foreign key references objava(ID_objave),
ID_osobe int foreign key references osoba(ID_osobe)
);
insert into osoba(ime,prezime,datum_rodenja,email,lozinka,broj_tel,slika,administrator,stanje,aktivan)
values
('Maja','Prigl','2000-12-03','mprigl@gmail.com','123wggh',095867455,'image01.jpg',0,1,1),
('Luka','Horvat','1960-05-05','0','lhorvat1212',09312654,'image02.jpg',0,0,0);

select*from osoba;

insert into objava(naslov,opis,vrijeme_izrade,IP_adresa,ID_osobe)
values
('Auto','Moj novi auto','2023-05-20','192.168.1.100',2),
('Cvijet','Napokon je doslo proljece u moj vrt','2023-05-10','193.169.2.200',1);

select*from objava;

insert into komentar(vrijeme_komentiranja,opis,ID_objave,ID_osobe)
values
('2023-05-20 15:00:00','Odlicaan',1,2),
('2023-05-10 16:00:00','Kako lijep vrt!!',2,1);

select*from komentar;

insert into svida_mi_se_komentar(ID_osobe,ID_komentara)
values
(1,1),
(2,2);

select*from svida_mi_se_komentar;

insert into svida_mi_se(vrijeme_svidanja,ID_objave,ID_osobe)
values
('2023-05-10 18:00:00',2,1),
('2023-05-20 16:00:00',1,2);

select*from svida_mi_se;

update osoba set
email='horvat19@gmail.com'
where ID_osobe=2;

delete from svida_mi_se where ID_objave=1;
