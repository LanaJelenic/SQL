use hijerarhija

create table zaposlenik(
zaposlenikID int not null primary key,
ime varchar(50),
prezime varchar(50),
nadredeni int
);

alter table zaposlenik add foreign key(nadredeni) references zaposlenik(zaposlenikID);