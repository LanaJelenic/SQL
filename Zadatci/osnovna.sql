create database osnovna;
use osnovna

create table Djecja_radionica(
ID_radionice int NOT NULL PRIMARY KEY,
ID_dijeteta int FOREIGN KEY REFERENCES Dijete(ID_dijeteta),
Naziv varchar(50),
Br_sobe int

);

create table Dijete(
ID_dijeteta int NOT NULL PRIMARY KEY,
Ime varchar(50),
Prezime varchar(50),
OIB varchar(50)

);

create table Uciteljica(
ID_uciteljice int NOT NULL PRIMARY KEY,
Ime varchar(50),
Prezime varchar(50)
);

create table Osnovna_skola(
ID_osnovne int NOT NULL PRIMARY KEY,
Naziv varchar(100),
Adresa varchar(100),
ID_radionice int FOREIGN KEY REFERENCES Djecja_radionica(ID_radionice),
ID_dijeteta int FOREIGN KEY REFERENCES Dijete(ID_dijeteta),
ID_uciteljice int FOREIGN KEY REFERENCES Uciteljica(ID_uciteljice)
);

ALTER TABLE Dijete
add ID_radionice int FOREIGN KEY REFERENCES Djecja_radionica(ID_radionice);

ALTER TABLE Djecja_radionica
add ID_uciteljice int FOREIGN KEY REFERENCES Uciteljica(ID_uciteljice);
