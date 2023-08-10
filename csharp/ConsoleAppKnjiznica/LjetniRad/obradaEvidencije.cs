using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LjetniRad
{
    internal class obradaEvidencije
    {
       public List<EvidencijaPosudbe> Evidencije { get; }
        private PocetnaStranica pocetnaStranica;

        public obradaEvidencije(PocetnaStranica pocetnaStranica):this() 
        {
        this.pocetnaStranica = pocetnaStranica;
          
        }

        public obradaEvidencije() 
        {
            Evidencije = new List<EvidencijaPosudbe>();
            if (Pomocno.dev)
            {
                TestniPodaci();
            }
        }

       

        public void PrikaziIzbornik()
        {
            Console.WriteLine("Izbornik za rad s evidencijama posudbe");
            Console.WriteLine(" 1. Pregled postojecih evidencija");
            Console.WriteLine(" 2. Unos nove evidencije:");
            Console.WriteLine(" 3. Promjena postojece evidencije");
            Console.WriteLine(" 4. Brisaje evidencije");
            Console.WriteLine(" 5. Povratak na pocetnu stranicu");

            switch(Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika evidencije posudbe:",
                "Odabir treba biti od 1-5",1,5))
            {

                case 1:
                    PregledEvidencije();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosEvidencije();
                    PrikaziIzbornik();
                        break;
                case 3:
                    PromjenaEvidencije();
                    PrikaziIzbornik();
                    break;
                case 4:
                    BrisanjeEvidencije();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Zavrsen rad s evidencijama posudbe");
                    break;
            }

        }

        private void PregledEvidencije()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("-----Evidencija posudbe-----");
            Console.WriteLine("----------------------------");
            int b = 1;

            foreach (EvidencijaPosudbe evidencija in Evidencije)
            {
                Console.WriteLine("{0}. {1} , datum posudbe:{2} , datum vracanja:{3},naslov knjige:{4}", b++, evidencija.Id,
                    evidencija.DatumPosudbe,evidencija.DatumVracanja,evidencija.knjiga);
                Console.WriteLine("\t Clanovi evidencije:");
                int clanRedniBroj = 1;
                foreach(Clan clan in  evidencija.Clanovi)
                {
                    Console.WriteLine("\t \t {0}. ,broj iskaznice:{1}-{2},{3}",clanRedniBroj++,clan.BrojIskaznice,clan.Ime,clan.Prezime);
                }
            }
            Console.WriteLine("----------------------------");
        }

        private void UnosEvidencije()
        {
            var e = new EvidencijaPosudbe();
            e.Id = Pomocno.UcitajBroj("Unesite ID evidencije:", "Unos bi trebao biti pozitivni cijeli broj");
            e.DatumPosudbe = Pomocno.ucitajDatum("Unesite datum posudbe u formatu dd.MM.yyyy.:", "Datum posudbe obavezan!!");
            e.DatumVracanja = Pomocno.ucitajDatum("Unesite datum vracanja u formatu dd.MM.yyyy.:", "Datum vracanja obavezan!!");
            e.knjiga = PostaviKnjigu();
            List<Clan>clanovi=new List<Clan>();
            clanovi.Add(Pomocno.DodajClana());
            e.Clanovi= clanovi;
        }

        private void PromjenaEvidencije()
        {
            PregledEvidencije();
            int br = Pomocno.ucitajBrojRaspon("Odaberi broj evidencije:", "Error!", 1, Evidencije.Count());
            var e = Evidencije[br-1];
            e.Id=Pomocno.UcitajBroj("Unesite ID evidencije(" + e.Id +"):", "Unos bi trebao biti pozitivni cijeli broj");
            e.DatumPosudbe = Pomocno.ucitajDatum("Unesite datum posudbe(" + e.DatumPosudbe + "):", "Datum posudbe obavezan!!");
            e.DatumVracanja = Pomocno.ucitajDatum("Unesite datum vracanja(" + e.DatumVracanja + ");", "Datum vracanja obavezan!!");
            Console.WriteLine("Trenutna posuđena knjiga: {0}",e.knjiga.Naslov);
            e.knjiga=PostaviKnjigu();
            e.Clanovi = PostaviClanove(e.Clanovi);

        }

        private Knjiga  PostaviKnjigu()
        {
            obradaKnjige.PregledKnjiga();
            int br= Pomocno.ucitajBrojRaspon("Odaberi ID knjige:","Error",1,obradaKnjige.Knjige.Count());
            return obradaKnjige.Knjige[br-1];

        }

        private List<Clan>PostaviClanove(List<Clan>clan)
        {
            List<Clan> clanovi=clan!=null ? clan :new List<Clan>();
            DodajClanaEvidencije(clanovi);
            ObrisiClanaEvidencije(clanovi);

            return clanovi;
        }

        private Clan PostaviClana()
        {
            obradaClana.PregledClanova();
            int br=Pomocno.ucitajBrojRaspon("Odaberi redni broj clana:","Error",1,obradaClana.Clanovi.Count());
            return obradaClana.Clanovi[br-1];

        }

        private List<Clan> DodajClanaEvidencije(List<Clan>clanovi)
        {
            while(Pomocno.UcitajBool("Želite li dodati clana u evidenciju?(da ili bilo sto drugo za ne): "))
            {
                clanovi.Add(PostaviClana());    

            }
            return clanovi;
        }

        private void SpremiPromjenuGrupe()
        {
            if(Pomocno.UcitajBool("Želite li spremiti promjene?(da ili bilo sto drugo za ne):"))
            {

            }
        }

        private List<Clan>ObrisiClanaEvidencije(List<Clan>clanovi)
        {
            while (Pomocno.UcitajBool("Želite li obrisati clana iz evidencije?(da ili bilo sto drugo za ne):"))
            {
                int redniBrojClanova = Pomocno.ucitajBrojRaspon("Odaberi id clana:", "Error", 1, obradaClana.Clanovi.Count());
                clanovi.RemoveAt(redniBrojClanova - 1);
            }
            return clanovi;
                
        }
       


        private void BrisanjeEvidencije()
        {
            PregledEvidencije();
            int br=Pomocno.ucitajBrojRaspon("Odaberite ID evidencije:","Erro!!",1,Evidencije.Count());
            Evidencije.RemoveAt(br-1);
        }
        
        private void TestniPodaci()
        {

            Evidencije.Add(new EvidencijaPosudbe
            {
                Id= 1,
                DatumPosudbe= new DateTime(),
                DatumVracanja=new DateTime(),
                Clanovi = obradaClana.Clanovi,
                knjiga = obradaKnjige.Knjige[1]



            } );
        }
    }
}

