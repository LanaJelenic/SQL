create database kolokvij;
use kolokvij

create table svekar(
ID_svekra int not null primary key identity(1,1),
stilifrizura varchar(48),
ogrlica int,
asocijalno bit
);

create table prijatelj(
ID_prijatelja int not null primary key identity(1,1),
ID_svekra int foreign key references svekar(ID_svekra),
modelnaocala varchar(37),
treciputa datetime,
ekstrovertno bit,
prviputa datetime
);

create table zarucnica(
ID_zarucnice int not null primary key identity(1,1),
narukvica int,
bojakose varchar(37),
novcica decimal(15,9),
lipa decimal(15,8),
indifirentno bit
);

create table decko(
ID_decka int not null primary key identity(1,1),
indifirentno bit,
vesta varchar(34),
asocijalno bit
);

create table decko_zarucnica(
ID_dz int not null primary key identity(1,1),
ID_decka int foreign key references decko(ID_decka),
ID_zarucnice int foreign key references zarucnica(ID_zarucnice)
);

create table cura(
ID_cure int not null primary key identity(1,1),
ID_decka int foreign key references decko(ID_decka),
haljina varchar(33),
drugiput datetime,
suknja varchar(38),
narukvica int,
introvertno bit,
majica varchar(40)
);

create table neprijatelj(
ID_neprijatelja int not null primary key identity(1,1),
ID_cure int foreign key references cura(ID_cure),
majca varchar(32),
haljina varchar(43),
lipa decimal(16,8),
modelnaocala varchar(49),
kuna decimal(12,6),
jmbag char(11)
);

create table brat(
ID_brata int not null primary key identity(1,1),
ID_neprijatelja int foreign key references neprijatelj(ID_neprijatelja),
suknja varchar(47),
ogrlica int,
asocijalno bit
);

insert into prijatelj(modelnaocala,treciputa,ekstrovertno,prviputa)
values
('ggdsgsj','2022-11-15',0,'2022-04-05'),
('nmb','2022-01-06',1,'2022-02-11'),
('jfjfsdjksd','2023-10-09',0,'2023-10-10'),
('vchj','2023-10-23',1,'2023-12-25'),
('hfffddh','2023-11-23',0,'2023-12-20'),
('llal','2023-10-01',1,'2023-05-25');

select * from prijatelj;

insert into zarucnica(narukvica,bojakose,novcica,lipa,indifirentno)
values
(2,'crvena',13.90,0.50,1),
(3,'plava',15.90,0.20,0),
(4,'smeda',22.90,0.56,1);

select * from zarucnica;

insert into decko(indifirentno,vesta,asocijalno)
values
(0,'plava',1),
(1,'crvena',0),
(0,'smeđa',1);

select * from decko;

insert into decko_zarucnica(ID_decka,ID_zarucnice)
values
(1,1),
(2,2),
(3,3);

select * from decko_zarucnica;

insert into cura(haljina,drugiput,suknja,narukvica,introvertno,majica,ID_decka)
values
('crvdf','2022-01-14','nhh',1,0,'bcbc',1),
('crvdf','2022-01-14','nhh',2,1,'bcbc',2),
('crvdf','2022-01-14','nhh',3,0,'bcbc',3);

select * from cura;

insert into brat(suknja,ogrlica,asocijalno)
values
('jhbsdsj',14,0),
('jhbsdsj',20,1),
('jhbsdsj',10,0),
('jhbsdsj',11,1),
('jhbsdsj',16,0),
('jhbsdsj',1,1);

select * from brat;

insert into neprijatelj(majca,haljina,lipa,modelnaocala,kuna,jmbag,ID_cure)
values
('bnhb','bhhb',50.50,'ahaha',3000.00,12345698712,1),
('bnhb','bhhb',50.50,'ahaha',3000.00,12345698712,2),
('bnhb','bhhb',50.50,'ahaha',3000.00,12345698712,3);

select * from neprijatelj;
update prijatelj
set treciputa='2020-04-30';

delete from brat
where ogrlica<>14;

select suknja from cura;

SELECT za.novcica,br.ID_neprijatelja,ne.haljina,cu.drugiput
from zarucnica za
inner join decko_zarucnica dz on za.ID_zarucnice=dz.ID_zarucnice
inner join decko de on dz.ID_decka=de.ID_decka
inner join cura cu on de.ID_decka=cu.ID_decka
inner join neprijatelj ne on cu.ID_cure=ne.ID_cure
inner join brat br on ne.ID_neprijatelja=br.ID_neprijatelja
where de.vesta like'%ba%'
order by ne.haljina desc;

SELECT de.vesta,de.asocijalno
FROM decko de
LEFT JOIN decko_zarucnica dz ON de.ID_decka=dz.ID_decka;
