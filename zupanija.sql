create database zupanija;
use zupanija

create table zupanija(
zupanijaID int not null primary key identity(1,1),
naziv varchar(100),
zupanID int foreign key references zupan(zupanID)
);

create table zupan(
zupanID int not null primary key identity(1,1),
ime varchar(50),
prezime varchar(50)

);

create table opcina(
opcinaID int not null primary key identity(1,1),
zupanijaID int foreign key references zupanija(zupanijaID),
naziv varchar(50)
);

create table mjesto(
mjestoID int not null primary key identity(1,1),
opcinaID int foreign key references opcina(opcinaID),
naziv varchar(50)
);