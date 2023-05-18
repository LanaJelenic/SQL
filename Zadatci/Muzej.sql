
create database muzej1;
use muzej1


create table djela(
ID_djela int not null primary key identity(1,1),
naziv varchar(50),
ime_umjetnika varchar(50),
prezime_umjetnika varchar(50),
vrsta_tehnike varchar(50)
);


create table izložba(
ID_izložbe int not null primary key identity(1,1),
naziv varchar(50),
datum_početka datetime,
ID_djela int foreign key references djela(ID_djela)
);

create table kustos(
ID_kustosa int not null primary key identity(1,1),
ime varchar(50),
prezime varchar(50),
ID_izložbe int foreign key references izložba(ID_izložbe)
);

create table sponzor(
ID_sponzora int not null primary key identity(1,1),
ime varchar(50),
prezime varchar(50),
adresa varchar(100),
ID_izložbe int foreign key references izložba(ID_izložbe)
);

insert into djela(naziv,ime_umjetnika,prezime_umjetnika,vrsta_tehnike)
values('Zvjezdana noć','Vincent','Gogh','ulje na platnu'),
('Posljednja večera','Leonardo','de Vinci','slikanje temperama'),
('Žena koja plače','Pablo','Picasso','uljene boje'),
('Vrata pakla','Auguste','Rodin','kiparstvo');

select*from djela;

insert into izložba(naziv,datum_početka,ID_djela)
values('Taoizam','2022-11.24 20:00:00',1),
('Kršćanstvo','2021-05-15 22:00:00',2),
('Patnja','2023-04-11',3),
('Svijet viječne patnje','2023-05-10',4);

select*from izložba;

insert into kustos(ime,prezime,ID_izložbe)
values('Petar','Perišić',12),
('Ivan','Klajić',10),
('Karlo','Jakšić',11),
('Jakov','Šimunović',13);

select*from kustos;

insert into sponzor(ime,prezime,ID_izložbe)
values('Tim','Kabel',10),
('Boris','Cvjetanović',11),
('Ivan','Ladislav',12),
('Marc','Chagall',13);

select*from sponzor;
