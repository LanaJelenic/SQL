create database srednja;
use srednja

create table Razred(
ID_razreda int NOT NULL PRIMARY KEY,
ID_ucenika int FOREIGN KEY REFERENCES Ucenik(ID_ucenika),
ID_profesora int FOREIGN KEY REFERENCES Profesor(ID_profesora),
Naziv varchar(50),
Br_sobe int
);

create table Ucenik(
ID_ucenika int NOT NULL PRIMARY KEY,
Ime varchar(50),
Prezime varchar(50),
OIB varchar(50)

);

create table Profesor(
ID_profesora int NOT NULL PRIMARY KEY,
Ime varchar(50),
Prezime varchar(50)
);

create table Srednja_skola(
ID_srednja int NOT NULL PRIMARY KEY,
Naziv varchar(100),
Adresa varchar(100),
ID_razreda int FOREIGN KEY REFERENCES Razred(ID_razreda),
ID_ucenika int FOREIGN KEY REFERENCES Ucenik(ID_ucenika),
ID_profesora int FOREIGN KEY REFERENCES Profesor(ID_profesora)
);

ALTER TABLE Profesor
add ID_razreda int FOREIGN KEY REFERENCES Razred(ID_razreda);
