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

