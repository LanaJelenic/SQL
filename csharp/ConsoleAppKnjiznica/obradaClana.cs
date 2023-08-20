namespace LjetniRad
{
    internal class ObradaClana
    {
        public static List<Clan> Clanovi { get; set; }
        public ObradaClana() 
        {
          Clanovi = new List<Clan>();
          if (Pomocno.dev)
          {
              TestniPodaci();
          }
        }

        public void PrikaziIzbornik()
        {
            Console.WriteLine("Izbornik za rad sa clanovima");
            Pomocno.DodajPrazanRed();
            Console.WriteLine(" 1. Pregled postojecih clanova");
            Console.WriteLine(" 2. Unos novog clana:");
            Console.WriteLine(" 3. Promjena postojeceg clana");
            Console.WriteLine(" 4. Brisanje clana");
            Console.WriteLine(" 5. Povratak na pocetnu stranicu");
            Pomocno.DodajPrazanRed();
            switch(Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika polaznika: ",
                "Odabir treba biti od 1-5",1,5))
            {
                case 1:
                    Pomocno.ObrisiEkran();
                    PregledClanova();
                    PrikaziIzbornik();
                    break;
                case 2:
                    Pomocno.ObrisiEkran();
                    UnosClana();
                    Pomocno.ObrisiEkran();
                    PrikaziIzbornik();
                    break;
                case 3:
                    Pomocno.ObrisiEkran();
                    PromjenaClana();
                    Pomocno.ObrisiEkran();
                    PrikaziIzbornik();
                    break;
                case 4:
                    Pomocno.ObrisiEkran();
                    BrisanjeClana();
                    Pomocno.ObrisiEkran();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Zavrsen rad sa clanovima");
                    Pomocno.ObrisiEkran();
                    break;

            }
        }

        public static void PregledClanova()
        {
            Console.WriteLine("-----------------");
            Console.WriteLine("-----Clanovi-----");
            Console.WriteLine("-----------------");
            int b = 1;

            foreach(Clan clan in Clanovi)
            {
               
                Console.WriteLine("{0}. {1} {2}, broj iskaznice - {3}",b++,clan.Ime, clan.Prezime, clan.BrojIskaznice);
            }
            Console.WriteLine("-----------------");
        }

        public static Clan PronadjiClana(int idClana)
        {
            return Clanovi.Find(clan => clan.Id == idClana);
        }
        
        private void UnosClana()
        {
            var c = new Clan();
            c.Id = Pomocno.UcitajBroj("Unesite ID clana:", "Unos bi trebao biti pozitivni cijeli broj");
            c.Ime = Pomocno.UcitajString("Unesite ime clana:", "Ime je obavezno!!");
            c.Prezime = Pomocno.UcitajString("Unesite prezime clana:", "Prezime je obavezno!!");
            c.BrojIskaznice = Pomocno.UcitajBroj("Unesite broj iskaznice clana:", "Broj iskaznice treba biti pozitivni cijeli broj!");
            c.Status = Pomocno.UcitajBroj("Unesite status clana:", "Status clana treba biti 0 ili 1!");
            Clanovi.Add(c);
        }

        private void PromjenaClana()
        {
            PregledClanova();
            int br= Pomocno.ucitajBrojRaspon("Odaberite redni broj clana:","Nepostojeći clan!",1,Clanovi.Count());
            var c = Clanovi[br - 1];
            c.Id = Pomocno.UcitajBroj("Unesite šifru clana(" + c.Id + "):", "Unos bi trebao biti pozitivni cijeli broj");
            c.Ime = Pomocno.UcitajString("Unesite ime clana(" + c.Ime + "):", "Ime je obavezno!!");
            c.Prezime = Pomocno.UcitajString("Unesite prezime clana(" + c.Prezime + "):", "Prezime je obavezno!!");
            c.BrojIskaznice=Pomocno.UcitajBroj("Unesite broj iskaznice clana(" + c.BrojIskaznice + "):", "Broj iskaznice treba biti pozitivni cijeli broj!");
            c.Status=Pomocno.UcitajBroj("Unesite status clana (1- aktivan 0- neaktivan)(" + c.Status + "):", "Status clana treba biti 0 ili 1!");
            
        }

        private void BrisanjeClana()
        {
            PregledClanova();
            int br = Pomocno.ucitajBrojRaspon("Odaberite ID clana:", "Error", 1, Clanovi.Count());
            Clanovi.RemoveAt(br - 1);
        }

        private void TestniPodaci()
        {
            Clanovi.Add(new Clan
            {
                Id=1,
                Ime="Luka",
                Prezime="Horvat",
                BrojIskaznice=123,
                Status=1
            });

            Clanovi.Add(new Clan
            {
                Id=2,
                Ime="Maja",
                Prezime="Prigl",
                BrojIskaznice=124,
                Status=1

            });

            Clanovi.Add(new Clan
            {
                Id = 3,
                Ime="Ante",
                Prezime="Bogovic",
                BrojIskaznice=125,
                Status=1
            });
        }
    }
}
