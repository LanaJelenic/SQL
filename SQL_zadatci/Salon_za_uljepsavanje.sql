create database salon_za_uljepsavanje;
use salon_za_uljepsavanje

create table djelatnik(
djelatnikID int not null primary key identity(1,1),
ime varchar(50),
prezime varchar(50),
);

create table korisnik(
korisnikID int not null primary key identity(1,1),
ime varchar(50),
prezime varchar(50),
spol varchar(50),
boja_noktiju varchar(50),
oblik_noktiju varchar(50)
);

create table usluga(
uslugaID int not null primary key identity (1,1),
cijena decimal(18,2),
naziv varchar(50)
);

create table termin(
terminID int not null primary key identity(1,1),
datum datetime,
djelatnikID int foreign key references djelatnik(djelatnikID),
korisnikID int foreign key references korisnik(korisnikID),
uslugaID int foreign key references usluga(uslugaID)
);
