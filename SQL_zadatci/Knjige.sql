create database knjige;
use knjige

create table clan(
clanID int not null primary key identity(1,1),
cl_broj int
);

create table knjige(
knjigeID int not null primary key identity(1,1),
clanID int foreign key references clan(clanID),
vlasnikID int foreign key references vlasnik(vlasnikID),
naslov varchar(50),
pisac varchar(100),
datumpos datetime,
datumvrac datetime
);

create table vlasnik(
vlasnikID int not null primary key identity(1,1)
);

create table osoba(
osobaID int not null primary key identity(1,1),
ime varchar(50),
prezime varchar(50),
adresa varchar(100),
email varchar(50)
);

alter table vlasnik
add knjigeID int foreign key references knjige(knjigeID);

insert into clan(cl_broj)
values(00056),
(00057),
(00058),
(00059);

select*from clan;

insert into osoba(ime,prezime,adresa,email)
values('Luka','Horvat','Zrmanjska 28 Osijek','lhorvat@gmail.com'),
('Maja','Prigl','Unska 4 Osijek','pmaja@gmail.com'),
('Ante','Bogović','Krbavska 11 Osijek','abogovic@gmail.com'),
('Iva','Dvojak','Murska 50 Osijek','dvojak.iva@gmail.com');

select*from osoba;

insert into knjige(clanID,datumpos,datumvrac,naslov,pisac)
values(2,'2023-05-02','2023-05-12','Institut','Stephen King'),
(1,'2023-04-16','2023-04-26','Sova','Samuel Bjorn'),
(4,'2023-05-13','2023-05-23','Mrtva priroda','Joy Fielding'),
(3,'2023-02-04','2023-02-14','Šaptač','Donato Carrisi');

select*from knjige;


