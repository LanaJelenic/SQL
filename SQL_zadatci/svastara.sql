select*from Artikli where kratkiNaziv like'%lampa%';

select*from Kupci
where prezime like'AB%'
order by prezime,ime;

select*from Kupci
where prezime like'AB%'
order by 2 desc,3;

select top 10*from kupci
where ime like'%nt%'
and prezime not like'F%';

select top 10 percent*from kupci
where ime like'%nt%'
and prezime not like'F%';

select ime,prezime from Kupci
where mjesto=18031;


select 
concat(trim(ime),' ', trim(prezime)) as imeprezime,
'Osijek' as mjesto
from kupci
where mjesto=18031
union
select
concat(trim(ime),'',trim(prezime))as imeprezime,
'Donji Miholjac'as mjesto
from kupci
where mjesto=2763;

select top 1*from artikli;
select*from Artikli where kratkiNaziv like'%perilica%'
and dugiNaziv like'%posu%';

select*from Artikli where
concat(kratkiNaziv,dugiNaziv)like'%perili%posu%';

select count(*)from Kupci;

select count(*)from ArtikliNaPrimci;
select top 10* from ArtikliNaPrimci;
select distinct Artikl from ArtikliNaPrimci
order by 1;

select count(*)from Artikli;
select*from artikli where sifra not in
(select distinct artikl from ArtikliNaPrimci);

delete from artikli where sifra not in
(select distinct artikl from ArtikliNaPrimci);

select top 1 sifra from Kupci order by 1 desc;

insert into Kupci(ime,prezime,jmbg)
values
('Lana','Jeleniæ','1236547897456');

alter table kupci add oib char(11);
select top 10concat('>',oib,'<')from kupci;
update kupci set oib='';
alter table kupci alter column oib char(11)not null;

select top 1*from kupci;
select*from mjesta where naziv like'%osijek%';
select count(*)from kupci where mjesto=45691;

select top 10 primka,kolicina*cijena as iznos
from ArtikliNaPrimci;

select sum(kolicina*cijena)from ArtikliNaPrimci
where primka=14;

select min(cijena)from artikli;
select*from artikli where cijena=0.04;
select max(cijena)from artikli;

select*,cijena/7.5345 as EUR from artiki where cijena=66890;

select primka, sum(cijena*kolicina)as iznos from ArtikliNaPrimci
group by primka
having sum(cijena*kolicina)>10000000
order by 2 desc;

select * from Primke where sifra=15853;
select * from Dobavljaci where sifra=560;
select * from mjesta where sifra=42633;
select * from Opcine where sifra=5312;
select * from Zupanije where sifra=18;

select count(*)from Kupci where ime='Lana';

alter table kupci add spol bit;

update Kupci set spol=1 where trim(ime)like'%a';
update Kupci set spol=0 where trim(ime)like'%a';