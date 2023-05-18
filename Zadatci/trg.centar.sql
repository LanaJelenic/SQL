create database trg_centar;
use trg_centar

create table Trgovina(
ID_trgovine int NOT NULL PRIMARY KEY,
Naziv varchar(50),
ID_osobe int FOREIGN KEY REFERENCES Osoba(ID_osobe),
ID_sefa int FOREIGN KEY REFERENCES Sef(ID_sefa)
);

create table Sef(
ID_sefa int NOT NULL PRIMARY KEY,
ID_osobe int FOREIGN KEY REFERENCES Osoba(ID_osobe),
Ime varchar(50),
Prezime varchar(50),
Email varchar(50)
);

create table Osoba(
ID_osobe int NOT NULL PRIMARY KEY,
Ime varchar(50),
Prezime varchar(50)
);

create table Trgovacki_centar(
ID_centra int NOT NULL PRIMARY KEY,
Naziv varchar(100),
Adresa varchar(100),
ID_trgovine int FOREIGN KEY REFERENCES Trgovina(ID_trgovine)
);

ALTER TABLE Osoba
add ID_trgovine int FOREIGN KEY REFERENCES Trgovina(ID_trgovine);
