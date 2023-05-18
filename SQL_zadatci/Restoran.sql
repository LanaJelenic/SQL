create database restoran;
use restoran

create table Kategorija(
ID_kategorije int NOT NULL PRIMARY KEY,
ID_jela int FOREIGN KEY REFERENCES Jelo(ID_jela),
Naziv varchar(50),
);

create table Jelovnik(
ID_jelovnika int NOT NULL PRIMARY KEY,
Naziv varchar(50)
);

create table Jelo(
ID_jela int NOT NULL PRIMARY KEY,
Ime varchar(50),
Vrsta_pripreme varchar(100)
);

create table Pice(
ID_pica int NOT NULL PRIMARY KEY,
Naziv varchar(100),
Proizvodat varchar(100)
);

create table Restoran(
ID_restorana int NOT NULL PRIMARY KEY,
Ime varchar(50),
Adresa varchar(50),
ID_jelovnika int FOREIGN KEY REFERENCES Jelovnik(ID_jelovnika)
);

ALTER TABLE Jelovnik
add ID_kategorije int FOREIGN KEY REFERENCES Kategorija(ID_kategorije);

alter table Jelo
add ID_pica int FOREIGN KEY REFERENCES Pice(ID_pica);

alter table Pice
add ID_jela int FOREIGN KEY REFERENCES Jelo(ID_jela);

alter table Restoran
add ID_kategorije int FOREIGN KEY REFERENCES Kategorija(ID_kategorije);
