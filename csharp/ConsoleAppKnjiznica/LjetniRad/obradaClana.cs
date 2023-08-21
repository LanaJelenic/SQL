namespace LjetniRad
{
    internal class obradaClana
    {
        public static List<Clan> Clanovi { get; set; }
        public obradaClana() 
        {
          Clanovi = new List<Clan>();
           
                TestniPodaci();
        }

        public void PrikaziIzbornik()
        {
            Console.WriteLine("Izbornik za rad sa clanovima");
            Console.WriteLine(" 1. Pregled postojecih clanova");
            Console.WriteLine(" 2. Unos novog clana:");
            Console.WriteLine(" 3. Promjena postojeceg clana");
            Console.WriteLine(" 4. Brisanje clana");
            Console.WriteLine(" 5. Povratak na pocetnu stranicu");

            switch(Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika polaznika:",
                "Odabir treba biti od 1-5",1,5))
            {
                case 1:
                    Pomocno.obrisiEkran();
                    PregledClanova();
                    PrikaziIzbornik();
                    break;
                case 2:
                    Pomocno.obrisiEkran();
                    UnosClana();
                    Pomocno.obrisiEkran();
                    PrikaziIzbornik();
                    break;
                case 3:
                    Pomocno.obrisiEkran();
                    PromjenaClana();
                    Pomocno.obrisiEkran();
                    PrikaziIzbornik();
                    break;
                case 4:
                    Pomocno.obrisiEkran();
                    BrisanjeClana();
                    Pomocno.obrisiEkran();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Pomocno.obrisiEkran();
                    PocetnaStranica.PrikaziPocetnu();
                    Console.WriteLine("Zavrsen rad sa članovima");
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

        public static Clan pronadiClana(int idClana)
        {
            return Clanovi.Find(clan => clan.Id == idClana);
        }

        private void UnosClana()
        {
            Pomocno.obrisiEkran();
            var c = new Clan();
            int ID = Pomocno.UcitajBroj("Unesite ID clana:", "Unos bi trebao biti pozitivni cijeli broj");
             while (ProvjeriId(ID))
                        {
                            Console.WriteLine("ID: {0} već postoji u evidenciji!!",ID);
                            ID = Pomocno.UcitajBroj("Unesite id clana:", "Unos bi trebao biti pozitivni cijeli broj!");
                            c.Id = ID;
                        }
            c.Ime = Pomocno.UcitajString("Unesite ime clana:", "Ime je obavezno!!");
            c.Prezime = Pomocno.UcitajString("Unesite prezime clana:", "Prezime je obavezno!!");

            int noviBrojiskaznice = Pomocno.UcitajBroj("Unesite broj iskaznice clana:", "Unos bi trebao biti pozitivni cijeli broj");
            while (ProvjeriBrojIskaznice(noviBrojiskaznice))
            {
                Console.WriteLine("Broj iskaznice: {0} već postoji u evidenciji!!",noviBrojiskaznice);
                noviBrojiskaznice = Pomocno.UcitajBroj("Unesite broj iskaznice clana:", "Unos bi trebao biti pozitivni cijeli broj!");
                c.BrojIskaznice = noviBrojiskaznice;
            }
            
            c.Status = Pomocno.UcitajBroj("Unesite status clana:", "Status clana treba biti 0 ili 1!");
            //Clanovi.Add(c);
            if (Pomocno.spremiPromjene())
            {
                Clanovi.Add(c);
            }

           
            
            
        }

        private bool ProvjeriId(int id)
        {
            foreach (var clan in Clanovi)
            {
                if (clan.Id==id)
                {
                    return true;
                }
            }

            return false;
        }
        private bool ProvjeriBrojIskaznice(int noviBrojIskaznice)
        {
            foreach (var clan in Clanovi)
            {
                if (clan.BrojIskaznice==noviBrojIskaznice)
                {
                    return true;
                }
            }

            return false;
        }

        private void PromjenaClana()
        {
            PregledClanova();
            int index = Pomocno.ucitajBrojRaspon("Odaberite redni broj clana:", "Odabir bi trebao biti u rasponu od 1-" + Clanovi.Count, 1, Clanovi.Count);

            var izmjennjeniPodaci = new Clan();
            
            var stariPodaci = Clanovi[index - 1];
            
            izmjennjeniPodaci.Ime = Pomocno.UcitajString("Unesite ime clana(" + stariPodaci.Ime + "):", "Ime je obavezno!!");
            izmjennjeniPodaci.Prezime = Pomocno.UcitajString("Unesite prezime clana(" + stariPodaci.Prezime + "):", "Prezime je obavezno!!");
            izmjennjeniPodaci.BrojIskaznice=IskaznicaTrue(unosBrojaIsk(),stariPodaci.BrojIskaznice);
            izmjennjeniPodaci.Status=Pomocno.UcitajBroj("Unesite status clana(" + stariPodaci.Status + "):", "Status clana treba biti 0 ili 1!");
            if (Pomocno.spremiPromjene())
            {
                Clanovi[index - 1] = izmjennjeniPodaci;
            }
        }

        private int IskaznicaTrue(int unosIskaznice, int brojIskaznice)
        {
            if (unosIskaznice==brojIskaznice)
            {
                return unosIskaznice;
            }

            Console.WriteLine("Unešeni broj ne odgovara odabiru iz evidencije!");
            return IskaznicaTrue(unosBrojaIsk(), brojIskaznice);
        }

        private int unosBrojaIsk()
        {
            return Pomocno.UcitajBroj("Unesite broj iskaznice člana:", "Unos mora biti pozitivni cijeli broj");
        }

        private void BrisanjeClana()
        {
            PregledClanova();
            int br = Pomocno.ucitajBrojRaspon("Odaberite ID clana:", "Error", 1, Clanovi.Count());
           
            if (Pomocno.spremiPromjene())
            {
                Clanovi.RemoveAt(br-1);
            }
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
