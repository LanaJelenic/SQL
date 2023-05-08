create database Postolar;
use Postolar

create table Obuca(
ID_OBUCE int NOT NULL PRIMARY KEY,
ID_popravka int FOREIGN KEY REFERENCES Popravak(ID_popravka),
Marka varchar(50),
Boja varchar(50),
Broj int
);

create table Korisnik(
ID_korisnika int NOT NULL PRIMARY KEY,
ID_OBUCE int FOREIGN KEY REFERENCES Obuca(ID_OBUCE),
Ime varchar(50),
Prezime varchar(50),
Kontakt int
);

create table Popravak(
ID_popravka int NOT NULL PRIMARY KEY,
Cijena decimal (18,2),
Vrijeme_trajanja datetime
);

create table Segrt(
ID_segrta int NOT NULL PRIMARY KEY,
Ime varchar(50),
Prezime varchar(50),
);

create table Postolar(
ID_postolara int NOT NULL PRIMARY KEY,
Ime varchar(50),
Adresa varchar(100),
Br_mobitela int,
ID_OBUCE int FOREIGN KEY REFERENCES Obuca(ID_OBUCE),
ID_korisnika int FOREIGN KEY REFERENCES Korisnik(ID_korisnika),
ID_popravka int FOREIGN KEY REFERENCES Popravak(ID_popravka),
ID_segrta int FOREIGN KEY REFERENCES Segrt(ID_segrta)
);