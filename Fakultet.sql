create database Fakultet;
use Fakultet

create table Student(
ID_studenta int NOT NULL PRIMARY KEY,
Ime varchar(50),
Prezime varchar(50)
);

create table Rok(
ID_rok int NOT NULL PRIMARY KEY,
ID_studenta int FOREIGN KEY REFERENCES Student(ID_studenta),
Datum datetime
);

ALTER TABLE Student
add ID_rok int FOREIGN KEY REFERENCES Rok(ID_rok);