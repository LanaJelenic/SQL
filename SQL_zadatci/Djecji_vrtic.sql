CREATE database vrtic2;
USE vrtic2

create table dijete(
dijeteID int not null primary key identity(1,1),
ime varchar(100),
prezime varchar(50),
dob int
);

create table odgojna_skupina(
odgojna_skupinaID int not null primary key identity(1,1),
dijeteID int foreign key references dijete(dijeteID),
SOBA varchar(100)
);


create table strucna_sprema(
strucna_spremaID int not null primary key identity(1,1),
NAZIV varchar(100)
);


create table odgajateljica(
odgajateljicaID int not null primary key identity(1,1),
strucna_spremaID int foreign key references strucna_sprema(strucna_spremaID),
dijeteID int foreign key references dijete(dijeteID),
ome varchar(50),
prezime varchar(50)

);

insert into dijete(ime,prezime,dob)
values
('Luka','Horvat',5),
('Maja','Prigl',3),
('Ante','Bogoviæ',2),
('Iva','Dvojak',4);

select*from dijete;

insert into odgojna_skupina(dijeteID,SOBA)
values
(4,11),
(3,8),
(2,12),
(1,4);

select*from odgojna_skupina;

insert into strucna_sprema(NAZIV)
values('èuvalica');

select*from strucna_sprema;

insert into odgajateljica(strucna_spremaID,dijeteID,ome,prezime)
values
(1,1,'Ana','Aniæ'),
(1,2,'Mila','Barišiæ'),
(1,3,'Antonela','Iviæ'),
(1,4,'Iva','Milkoviæ');

select*from odgajateljica;