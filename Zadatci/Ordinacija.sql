create database Ordinacija;
use Ordinacija

create table Pacijent(
ID_pacijenta int NOT NULL PRIMARY KEY,
ID_lijecenja int FOREIGN KEY REFERENCES Lijecenje(ID_lijecenja),
Ime varchar(50),
Prezime varchar(50),
Broj_zdravstvene int
);

create table Lijecenje(
ID_lijecenja int NOT NULL PRIMARY KEY,
Naziv varchar(50),
Cijena int
);

create table Med_sestra(
ID_med_sestre int NOT NULL PRIMARY KEY,
ID_lijecenja int FOREIGN KEY REFERENCES Lijecenje(ID_lijecenja),
ID_pacijenta int FOREIGN KEY REFERENCES Pacijent(ID_pacijenta),
Ime varchar(50),
Prezime varchar(50),
Kvalifikacija bit
);

create table Doktor(
ID_doktora int NOT NULL PRIMARY KEY,
Ime varchar(50),
Prezime varchar(50),
Kvalifikacija bit,
ID_pacijenta int FOREIGN KEY REFERENCES Pacijent(ID_pacijenta),
ID_lijecenja int FOREIGN KEY REFERENCES Lijecenje(ID_lijecenja),
ID_med_sestre int FOREIGN KEY REFERENCES Med_sestra(ID_med_sestre)
);
