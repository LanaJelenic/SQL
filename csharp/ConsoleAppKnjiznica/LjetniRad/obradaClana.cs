using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Console.WriteLine("Završen rad s članovima");
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
            c.Ime = Pomocno.UcitajString("Unesite ime clana:", "Ime je obavezno!!");
            c.Prezime = Pomocno.UcitajString("Unesite prezime clana:", "Prezime je obavezno!!");
            c.BrojIskaznice = Pomocno.UcitajBroj("Unesite broj iskaznice clana:", "Broj iskaznice treba biti pozitivni cijeli broj!");
            c.Status = Pomocno.UcitajBroj("Unesite status clana:", "Status clana treba biti 0 ili 1!");
            Clanovi.Add(c);
            if (Pomocno.spremiPromjene())
            {
                Clanovi.Add(c);
            }

            while (ProvjeriId(ID))
            {
                Console.WriteLine("ID: {0} već postoji u evidenciji!!",ID);
                ID = Pomocno.UcitajBroj("Unesite id clana:", "Unos bi trebao biti pozitivni cijeli broj!");
                c.Id = ID;
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

        private void PromjenaClana()
        {
            PregledClanova();
            int index = Pomocno.ucitajBrojRaspon("Odaberite broj clana:", "Odabir bi trebao biti u rasponu od 1-" +
                Clanovi.Count, 1, Clanovi.Count);
            var stariPodatci = SacuvajPodatke();
            Clanovi[index-1].Id=IskaznicaTrue(unosBrojaIsk(),Clanovi[index - 1].Id);
            int br= Pomocno.ucitajBrojRaspon("Odaberite ID clana:","Error",1,Clanovi.Count());
            var c = Clanovi[br - 1];
            c.Id = Pomocno.UcitajBroj("Unesite ID clana(" + c.Id + "):", "Unos bi trebao biti pozitivni cijeli broj");
            c.Ime = Pomocno.UcitajString("Unesite ime clana(" + c.Ime + "):", "Ime je obavezno!!");
            c.Prezime = Pomocno.UcitajString("Unesite prezime clana(" + c.Prezime + "):", "Prezime je obavezno!!");
            c.BrojIskaznice=Pomocno.UcitajBroj("Unesite broj iskaznice clana(" + c.BrojIskaznice + "):", "Broj iskaznice treba biti pozitivni cijeli broj!");
            c.Status=Pomocno.UcitajBroj("Unesite status clana(" + c.Status + "):", "Status clana treba biti 0 ili 1!");
            if (!Pomocno.spremiPromjene())
            {
                Clanovi[index - 1] = stariPodatci[0];
            }
        }

        private int IskaznicaTrue(int unosIskaznice, int iD)
        {
            if (unosIskaznice==iD)
            {
                return unosIskaznice;
            }

            Console.WriteLine("Unešeni ID ne odgovara odabiru iz evidencije!");
            return IskaznicaTrue(unosBrojaIsk(), iD);
        }

        private int unosBrojaIsk()
        {
            return Pomocno.UcitajBroj("Unesite broj iskaznice člana:", "Unos mora biti pozitivni cijeli broj");
        }

        private List<Clan> SacuvajPodatke()
        {
            List<Clan> podatci = new List<Clan>();
            foreach (var clan in Clanovi)
            {
                podatci.Add(clan);
            }

            return podatci;
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
