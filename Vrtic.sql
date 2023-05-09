CREATE database vrtic;
USE vrtic
create table dijete(
dijeteID int NOT NULL PRIMARY KEY,
IME varchar(100),
PREZIME VARCHAR(50),
DOB int
);

create table odgojna_skupina(
odgojna_skupinaID int NOT NULL PRIMARY KEY,
dijeteID int FOREIGN KEY REFERENCES dijete(dijeteID),
SOBA varchar(100)
);


create table srucna_sprema(
strucna_spremaID int NOT NULL PRIMARY KEY,
NAZIV varchar(100)
);


create table odgajateljica(
odgajateljicaID int NOT NULL PRIMARY KEY,
strucna_spremaID int FOREIGN KEY REFERENCES srucna_sprema(strucna_spremaID),
IME varchar(50),
PREZIME varchar(50)

);

alter table odgojna_skupina 
add odgajateljicaID int foreign key references odgajateljica(odgajateljicaID);
