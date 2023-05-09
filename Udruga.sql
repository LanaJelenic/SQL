create database UDRUGA;
use UDRUGA
create table osoba(
osobaID int not null primary key identity(1,1),
ime varchar(50),
prezime varchar(50),
sticenikID int foreign key references sticenik_udruge(sticenikID)
);

create table sticenik_udruge (
sticenikID int not null primary key identity(1,1),
vrsta varchar(50),
tezina decimal(18,2),
boja varchar(50),
prostorID int foreign key references prostor(prostorID)
);

create table prostor(
prostorID int not null primary key identity (1,1),
sirina decimal(18,2),
visina decimal(18,2)
);
