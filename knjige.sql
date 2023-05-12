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


