create database frizerski;
use frizerski

create table djelatnik(
djelatnikID int not null primary key identity(1,1),
ime varchar(50),
prezime varchar(50),
);

create table korisnik(
korisnikID int not null primary key identity(1,1),
ime varchar(50),
prezime varchar(50),
spol varchar(50),
duzina_kose int
);

create table usluga(
uslugaID int not null primary key identity (1,1),
cijena decimal(18,2),
naziv varchar(50)
);

create table termin(
terminID int not null primary key identity(1,1),
datum datetime,
djelatnikID int foreign key references djelatnik(djelatnikID),
korisnikID int foreign key references korisnik(korisnikID),
uslugaID int foreign key references usluga(uslugaID)
);

insert into djelatnik(ime,prezime)
values
('Ana','Anić'),
('Mila','Barišić'),
('Antonela','Ivić'),
('Iva','Milković');

select*from djelatnik;

insert into korisnik(ime,prezime,spol,duzina_kose)
values
('Anja','Sarić','žensko',13),
('Marko','Josipović','muško',5),
('Ema','Antunović','žensko',10),
('Josip','Ćupić','muško',3);

select*from korisnik;

insert into usluga(cijena,naziv)
values
(9.50,'šišanje'),
(5.00,'šišanje'),
(14.30,'bojanje'),
(10.00,'blajhanje');

select*from usluga;

insert into termin(datum,djelatnikID,korisnikID,uslugaID)
values
('2023-03-16 15:30:00',4,2,2),
('2023-03-17 10:00:00',1,1,1),
('2023-03-18 19:20:00',2,3,3),
('2023-03-19 13:00:00',3,4,4);

select*from termin;
