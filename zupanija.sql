create database zupanija;
use zupanija

create table zupanija(
zupanijaID int not null primary key identity(1,1),
naziv varchar(100),
zupanID int foreign key references zupan(zupanID)
);

create table zupan(
zupanID int not null primary key identity(1,1),
ime varchar(50),
prezime varchar(50)

);

create table opcina(
opcinaID int not null primary key identity(1,1),
zupanijaID int foreign key references zupanija(zupanijaID),
naziv varchar(50)
);

create table mjesto(
mjestoID int not null primary key identity(1,1),
opcinaID int foreign key references opcina(opcinaID),
naziv varchar(50)
);

insert into zupan(ime,prezime)
values('Ivan','Anušić'),
('Damir','Dekanić'),
('Ivan','Celjak');

select*from zupan;

insert into zupanija(naziv,zupanID)
values('Osiječko-baranjska',1),
('Vukovarsko-srijemska',2),
('Sisačko-moslavačka',3);

select*from zupanija;

insert into opcina(naziv,zupanijaID)
values('Bilje',1),
('Čeminac',1),
('Ivankovo',2),
('Borovo',2),
('Dvor',3),
('Topusko',3);

select*from opcina;
