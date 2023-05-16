create database Fakultet2;
use Fakultet2

create table Student(
ID_studenta int NOT NULL PRIMARY KEY IDENTITY(1,1),
Ime varchar(50),
Prezime varchar(50),
oib char(11),
email varchar(100)
);

create table Rok(
ID_rok int NOT NULL PRIMARY KEY IDENTITY(1,1),
Datum datetime
);

create table Kolegij(
ID_kolegija int not null primary key identity(1,1),
ID_studenta int foreign key references Student(ID_studenta),
ID_rok int foreign key references Rok(ID_rok)
);

insert into Student(Ime,Prezime,oib,email)
values('Luka','Horvat',03011268351,'lhorvat@gmail.com'),
('Maja','Prigl',83011248760,'pmaja@gmail.com'),
('Ante','Bogović',93050337591,'abogovic@gmail.com'),
('Iva','Dvojak',73012842320,'dvojak.iva@gmail.com');

select*from Student;

insert into Rok(Datum)
values('2023-05-01 08:00:00'),
('2023-04-25 10:00:00'),
('2023-05-15 13:00:00'),
('2023-04-18 19:00:00');

select*from Rok;

insert into Kolegij(ID_studenta,ID_rok)
values(1,4),
(2,1),
(3,2),
(4,3);

select*from Kolegij;
