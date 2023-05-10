
create database muzej;


use muzej

create table izlozba(
izlozbaID int not null primary key identity(1,1),
djeloID int foreign key references djelo(djeloID),
sponzorID int foreign key references sponzor(sponzorID),
naziv varchar(100)not null,
datum_pocetka datetime not null,
);

create table djelo(
djeloID int not null primary key,
naziv varchar(50),
ime_umjetnika varchar(60),
vrsta_tehnike varchar(50)
);

create table kustos(
kustosID int not null primary key,
izlozbaID int foreign key references izlozba(izlozbaID),
ime varchar(50),
prezime varchar(50),
);

create table sponzor(
ime varchar(50),
adresa varchar(50)
);

alter table sponzor add sponzorID int not null primary key;

