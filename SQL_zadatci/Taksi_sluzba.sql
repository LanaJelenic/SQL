
create database taksi;
use taksi

create table vozilo(
ID_vozila int not null primary key identity(1,1),
marka varchar(50),
reg_tablica char(7)
);

create table vozac(
ID_vozaca int not null primary key identity(1,1),
ime varchar(50),
prezime varchar(50),
br_nob varchar(50)
);

create table putnik(
ID_putnika int not null primary key identity(1,1),
ime varchar(50),
prezime varchar(50),
email varchar(50),
br_mob varchar(50)
);

create table voznja(
ID_voznje int not null primary key identity(1,1),
km varchar(20),
cijena decimal(18,2)
);

create table putnik_voznja(
ID_putnika int foreign key references putnik(ID_putnika),
ID_voznje int foreign key references voznja(ID_voznje)
);

alter table vozac add ID_vozila int foreign key references vozilo(ID_vozila);
alter table vozac add ID_voznje int foreign key references voznja(ID_voznje);

insert into vozilo(marka)
values
('Ford focus'),
('Dacia'),
('Dacia');

SELECT*FROM vozilo;

insert into voznja(km,cijena)
values
('16 km',20.00),
('5 km',8.45),
('25 km',30.00);

select*from voznja;

insert into vozac(ime,prezime,br_nob)
values
('Iva','Dvojak','0895456'),
('Ante','Bogović','0645321'),
('Luka','Horvat','097654');

select*from vozac;

insert into putnik(ime,prezime,email,br_mob)
values
('Ivo','Pospišil','0','0976454'),
('Laura','Bogović','lbogovic@gmail.com','1213555'),
('Kruno','Blažević','kblazevic@gmail.com','0984564');

select*from putnik;

insert into putnik_voznja(ID_putnika,ID_voznje)
values
(1,1),
(2,2),
(3,3);

select*from putnik_voznja;
