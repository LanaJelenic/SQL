using LjetniRad;

namespace LjetniRad
{
    internal class ObradaEvidencije
    {
        public static List<Posudba> EvidencijaPosudbe { get; set; }
        private PocetnaStranica pocetnaStranica;

        public ObradaEvidencije(PocetnaStranica pocetnaStranica):this() 
        {
        this.pocetnaStranica = pocetnaStranica;
          
        }

        public ObradaEvidencije() 
        {
            EvidencijaPosudbe = new List<Posudba>();
            if(Pomocno.dev)
            {
                TestniPodaci();
            }
        }

        public void PrikaziIzbornik()
        {
           
            Pomocno.dodajPrazanRed();
            Console.WriteLine(" 1. Pregled postojecih posudbi");
            Console.WriteLine(" 2. Promjena postojece posudbe");
            Console.WriteLine(" 3. Unos posudbe knjige:");
            Console.WriteLine(" 4. Brisanje evidencije posudbe");
            Console.WriteLine(" 5. Povratak na pocetnu stranicu");
            Pomocno.dodajPrazanRed();
            switch(Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika evidencije posudbe: ",
                "Odabir treba biti od 1-5",1,5))
            {

                case 1:
                    Pomocno.obrisiEkran();
                    PregledEvidencije();
                    PrikaziIzbornik();
                    break;
                case 2:
                    Pomocno.obrisiEkran();
                    PromjenaEvidencije();
                    Pomocno.obrisiEkran();
                    PrikaziIzbornik();
                    break;
                case 3:
                    Pomocno.obrisiEkran();
                    UnosPosudbe();
                    Pomocno.obrisiEkran();
                    PrikaziIzbornik();
                        break;
                case 4:
                    Pomocno.obrisiEkran();
                    BrisanjeEvidencije();
                    Pomocno.obrisiEkran();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Pomocno.obrisiEkran();
                    PocetnaStranica.PrikaziPocetnu();
                    Console.WriteLine("Zavrsen rad s evidencijama posudbe");
                    break;
            }

        }

        private void PregledEvidencije()
        {
            //Pomocno.ObrisiEkran();
            Console.WriteLine("----------------------------");
            Console.WriteLine("-----Evidencija posudbe-----");
            Console.WriteLine("----------------------------");
            int b = 1;
            if (EvidencijaPosudbe.Count == 0)
            {
                Console.WriteLine(" Ne postoji niti jedna posudba unutar knjižnice! ");
            }
            else
            {
                foreach ( Posudba posudba in EvidencijaPosudbe)
                {
                    Console.WriteLine("{0}. Broj iskaznice: {1} - {2} {3} * Naslov knjige:  {4} , * Datum posudbe: {5},  * Datum vracanja:{6}", 
                        b++, 
                        posudba.BrojIskazniceClana,
                        DohvatiPodatkeClana(posudba.BrojIskazniceClana).Ime,
                        DohvatiPodatkeClana(posudba.BrojIskazniceClana).Prezime,
                        DohvatiPodatkeKnjige(posudba.idKnjige).Naslov, 
                        posudba.DatumPosudbe.ToString("dd/MM/yyyy"),
                        posudba.DatumVracanja.ToString("dd/MM/yyyy"));
                } 
            }
            
            Console.WriteLine("----------------------------");
        }

        private Clan DohvatiPodatkeClana(int posudbaBrojIskazniceClana)
        {
           return obradaClana.Clanovi.Find(clan => clan.BrojIskaznice == posudbaBrojIskazniceClana);
        }

        private void UnosPosudbe()
        {
            Pomocno.obrisiEkran();
            // kreranje nove posudbe
            var pos = new Posudba();
            // popunjavanje posudbe podacima
            obradaClana.PregledClanova();
            pos.BrojIskazniceClana = provjerenBrojIskaznice(unosBrojaIskaznice());
            obradaKnjige.PregledKnjiga();
            pos.idKnjige = Pomocno.ucitajBrojRaspon(
                "Unesite redni broj knjige:", 
                "Unos bi trebao biti pozitivni cijeli broj u rasponu od 1 - " + obradaKnjige.SveKnjige().Count, 
                1,obradaKnjige.SveKnjige().Count);
            pos.DatumPosudbe = Pomocno.ucitajDatum("Unesite datum posudbe:", "Datum posudbe obavezan!!");
            pos.DatumVracanja= Pomocno.ucitajDatum("Unesite datum vracanja:", "Datum vracanja obavezan!!");
            // dodavanje posudbe u listu posudbi
            EvidencijaPosudbe.Add(pos);
            if (Pomocno.spremiPromjene())
            {
               EvidencijaPosudbe.Add(pos);
            }
        }

        private int provjerenBrojIskaznice(int brojIskaznice)
        {
            // prođi kroz sve clanove
            foreach (var clan in obradaClana.Clanovi)
            {
                // ako nađeš clana sa datim brojem iskaznice
                if (clan.BrojIskaznice == brojIskaznice)
                {
                    // vrati broj tog clana
                    return clan.BrojIskaznice;
                }
            }
            // u suprotnom izbaci poruku i ponovi unos
            Console.WriteLine("Unešeni broj iskaznice ne odgoavara niti jednom članu!");
            
            // metoda ponovo poziva samu sebe (rekurzija)
            return provjerenBrojIskaznice(unosBrojaIskaznice());
        }
        
        private int brojIskazniceOdgovaraClanu(int uneseniBrojIskaznice, int brojIzEvidencije)
        {
            if (uneseniBrojIskaznice == brojIzEvidencije)
            {   
                // Vrati broj koji je korisnik unio jer odgovara onome iz evidencije
                return uneseniBrojIskaznice;
            }
            // u suprotnom izbaci poruku i ponovi unos
            Console.WriteLine("Unešeni broj iskaznice ne odgoavara odabiru iz evidencije!");
            // metoda ponovo poziva samu sebe (rekurzija)
            return brojIskazniceOdgovaraClanu(unosBrojaIskaznice() , brojIzEvidencije);
        }

        private int unosBrojaIskaznice()
        {
           return Pomocno.UcitajBroj("Unesite broj iskaznice člana:","Unos bi trebao biti pozitivni cijeli broj");
        }

        private Knjiga DohvatiPodatkeKnjige(int idKnjige)
        {
            // prođi kroz sve knjige
            foreach (var knjiga in obradaKnjige.SveKnjige())
            {
                // ako nađeš knjigu sa datim id-em
                if (knjiga.Id == idKnjige)
                {
                    // vrati tu knjigu
                    return knjiga;
                }
            }
            // u suprotnom vrati null
            return null;
            // LAMBDA NAČIN
            //return ObradaKnjige.SveKnjige().Find(knjiga => knjiga.Id == idKnjige);
        }

        private void PromjenaEvidencije()
        {
            PregledEvidencije();
            int index = Pomocno.ucitajBrojRaspon(
                "Odaberi broj evidencije: ", "Odabir bi trebao biti u rasponu od 1- " + EvidencijaPosudbe.Count, 
                1, 
                EvidencijaPosudbe.Count());
            var posudba = new Posudba();

            var stariPodaci = SacuvajPodatke();

            posudba.BrojIskazniceClana = brojIskazniceOdgovaraClanu(unosBrojaIskaznice(), EvidencijaPosudbe[index -1].BrojIskazniceClana);
            obradaKnjige.PregledKnjiga();
            posudba.idKnjige = Pomocno.ucitajBrojRaspon("Unesite redni broj knjige:", "Unos bi trebao biti pozitivni cijeli broj u rasponu od 1 - " + obradaKnjige.SveKnjige().Count,1,obradaKnjige.SveKnjige().Count);
            posudba.DatumPosudbe = Pomocno.ucitajDatum("Unesite datum posudbe:", "Datum posudbe obavezan!!");
            
          posudba.DatumVracanja = Pomocno.ucitajDatum("Unesite datum vracanja:", "Datum vracanja je obavezan!!");
            // Upit da li želi spremiti izmjene
            if (!Pomocno.spremiPromjene()) //Korisnik je odabrao da ne želi spremiti promjene
            {
                EvidencijaPosudbe[index - 1] = stariPodaci[0];  // vračamo stare podatke za odabranu grupu
            }

        }
        
        private List<Posudba> SacuvajPodatke()
        {
            // kreiramo privremeni objekt u kojem ćemo držati listu
            List<Posudba> listaPosudbi = new List<Posudba>();
            
            foreach ( var posudba in EvidencijaPosudbe)
            {
                // dodajemo svaku pojedinačnu posudbu u listu posudbi
                listaPosudbi.Add(posudba);
            }
            // vracamo popunjenu listu sa posudbama
            return listaPosudbi;
        }

        private void BrisanjeEvidencije()
        {
            // pirkazi listu evidencij
            PregledEvidencije();
            
            int br=Pomocno.ucitajBrojRaspon("Odaberite redni broj evidencije: ","Odabir mora biti unutar raspona 1-" + EvidencijaPosudbe.Count() ,1,EvidencijaPosudbe.Count());
            // Ponudi izbor spremiti da ili ne 
            if (Pomocno.spremiPromjene());
                {
                    // Ako je odabrano da, brišemo
                    EvidencijaPosudbe.RemoveAt(br-1);
                }
        }
        
        
        private void TestniPodaci()
        {

            Posudba posudba1 = new Posudba()
            {
                BrojIskazniceClana = 123,
                idKnjige = 1,
                DatumPosudbe = new DateTime(2023, 8, 15),
                DatumVracanja = new DateTime(2023, 8, 19)
            };
            
            Posudba posudba2 = new Posudba()
            {
                BrojIskazniceClana = 125,
                idKnjige = 2,
                DatumPosudbe = new DateTime(2023, 6, 25),
                DatumVracanja = new DateTime(2023, 6, 29)
            };
            
            Posudba posudba3 = new Posudba()
            {
                BrojIskazniceClana = 124,
                idKnjige = 3,
                DatumPosudbe = new DateTime(2023, 6, 25),
                DatumVracanja = new DateTime(2023, 6, 29)
            };
            
            //clan
            // lista knjiga / knjige datum posudbe i vracanja po knjizi

            EvidencijaPosudbe.Add(posudba1);
            EvidencijaPosudbe.Add(posudba2);
            EvidencijaPosudbe.Add(posudba3);

            //EvidencijaPosudbe
        }
    }
}


       

       
        
       
        
    


