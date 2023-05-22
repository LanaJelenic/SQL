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


create table odgajateljica(
odgajateljicaID int not null primary key identity(1,1),
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

insert into odgajateljica(dijeteID,ome,prezime)
values
(1,'Ana','Aniæ'),
(2,'Mila','Barišiæ'),
(3,'Antonela','Iviæ'),
(4,'Iva','Milkoviæ');

select*from odgajateljica;
