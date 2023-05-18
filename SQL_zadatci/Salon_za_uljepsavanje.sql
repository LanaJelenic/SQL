create database salon_za_uljepsavanje;
use salon_za_uljepsavanje

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
boja_noktiju varchar(50),
oblik_noktiju varchar(50)
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

insert into korisnik(ime,prezime,spol,boja_noktiju,oblik_noktiju)
values
('Marija','Jelenić','žensko','crvena','ovalni'),
('Marina','Žuljević','žensko','žuta','badem'),
('Stefani','Rukavina','žensko','crna','balerina'),
('Paula','Orešković','žensko','plava','ovalni');

select*from korisnik;

insert into usluga(cijena,naziv)
values
(9.50,'rezanje'),
(5.00,'turpijanje'),
(14.30,'geliranje'),
(10.00,'bojanje');

select*from usluga;

insert into termin(datum,djelatnikID,korisnikID,uslugaID)
values
('2023-04-20 15:30:00',4,4,4),
('2023-04-21 10:00:00',1,1,1),
('2023-04-22 19:20:00',3,3,3),
('2023-04-23 13:00:00',2,2,2);

select*from termin;


