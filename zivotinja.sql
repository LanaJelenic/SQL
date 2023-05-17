 create database zivotinje;
 use zivotinje

 create table djelatnik(
 ID_djelatnika int not null primary key identity(1,1),
 ime varchar(50),
 prezime varchar(50),
 iban varchar(50)
 );

 create table prostorija(
 ID_prostorije int not null primary key identity(1,1),
 dimenzije varchar(50),
 maks_broj int,
 mjesto varchar(50)
 );

 create table datum(
 ID_datuma int not null primary key identity(1,1),
 d_rodenja datetime,
 d_dolaska datetime,
 d_smrti datetime
 );

 create table zivotinja(
 ID_zivotinje int not null primary key identity(1,1),
 vrsta varchar(50),
 ime varchar(50),
 ID_djelatnika int foreign key references djelatnik(ID_djelatnika),
 ID_prostorije int foreign key references prostorija(ID_prostorije),
 ID_datuma int foreign key references datum(ID_datuma)
 );

 insert into djelatnik(ime,prezime,iban)
 values('Marko','Marić','HR12132453'),
 ('Ivan','Šarić','HR2314676454'),
 ('Maja','Majić','HR36985');

 select*from djelatnik;

 insert into prostorija(dimenzije,maks_broj,mjesto)
 values('3x3',2,'Osijek'),
 ('180x200',3,'Zagreb'),
 ('200x200',5,'Bilje');

 select*from prostorija;

 insert into datum(d_dolaska,d_rodenja,d_smrti)
 values('2022-05-11','2011-11.23','2015-06-23'),
 ('2004-12-10','2003-01-11','2010-10-09'),
 ('2023-01-12','2021-02-14','2023-04-15');

 select*from datum;

 insert into zivotinja(vrsta,ime,ID_djelatnika,ID_prostorije,ID_datuma)
 values('ptica','Twiti',1,2,3),
 ('tigar','Leo',2,1,2),
 ('ljenjivac','Pero',3,3,1);

 select*from zivotinja;

 update zivotinja set
 vrsta='majmun'
 where ID_zivotinje=2;

 update djelatnik set
 prezime='Perić',
 iban='HR6666'
 where ID_djelatnika=1;

 delete from zivotinja where ID_zivotinje=3;