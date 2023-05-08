create database Urar;
use Urar

create table Sat(
ID_sata int NOT NULL PRIMARY KEY,
ID_popravka int FOREIGN KEY REFERENCES Popravak(ID_popravka),
Marka varchar(50),
Boja varchar(50),
Materijal varchar(60)
);

create table Korisnik(
ID_korisnika int NOT NULL PRIMARY KEY,
ID_sata int FOREIGN KEY REFERENCES Sat(ID_sata),
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

create table Urar(
ID_urara int NOT NULL PRIMARY KEY,
Ime varchar(50),
Adresa varchar(100),
Br_mobitela int,
ID_sata int FOREIGN KEY REFERENCES Sat(ID_sata),
ID_korisnika int FOREIGN KEY REFERENCES Korisnik(ID_korisnika),
ID_popravka int FOREIGN KEY REFERENCES Popravak(ID_popravka),
ID_segrta int FOREIGN KEY REFERENCES Segrt(ID_segrta)
);