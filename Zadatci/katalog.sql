create database katalog;
use katalog

create table autor(
autorID int not null primary key identity(1,1),
ime varchar(50),
prezime varchar(50),
datum_rodenja datetime
);

create table izdavac(
izdavacID int not null primary key identity(1,1),
naziv varchar(50),
aktivan bit
);

create table mjesto(
mjestoID int not null primary key identity(1,1),
naziv varchar(50),
drzava varchar(50)
);

create table katalog(
katalogID int not null primary key identity(1,1),
autorID int foreign key references autor(autorID),
izdavacID int foreign key references izdavac(izdavacID),
mjestoID int foreign key references mjesto(mjestoID)
);

insert into izdavac(naziv)
values('znanje');
 insert into izdavac(naziv)
 values('skolska_knjiga');

  insert into mjesto(naziv,drzava)
 values('Sl_brod','Hrvatska');

 insert into mjesto(naziv,drzava)
 values('Zagreb','Hrvatska');

 insert into autor
 values('Ivana','Brlic_Mazuranic','1874-04-18');

 insert into autor
 values('August','Senoa','1838-11-14');
