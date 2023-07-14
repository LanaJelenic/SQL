using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LjetniRad
{
    internal class obradaClana
    {
        public List<Clan> Clanovi { get; }
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
                    PregledClanova();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosClana();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjenaClana();
                    PrikaziIzbornik();
                    break;
                case 4:
                    BrisanjeClana();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Zavrsen rad sa clanovima");
                    break;

            }
        }

        private void PregledClanova()
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
            int br= Pomocno.ucitajBrojRaspon("Odaberite ID clana:","Error",1,Clanovi.Count());
            var c = Clanovi[br - 1];
            c.Id = Pomocno.UcitajBroj("Unesite ID clana(" + c.Id + "):", "Unos bi trebao biti pozitivni cijeli broj");
            c.Ime = Pomocno.UcitajString("Unesite ime clana(" + c.Ime + "):", "Ime je obavezno!!");
            c.Prezime = Pomocno.UcitajString("Unesite prezime clana(" + c.Prezime + "):", "Prezime je obavezno!!");
            c.BrojIskaznice=Pomocno.UcitajBroj("Unesite broj iskaznice clana(" + c.BrojIskaznice + "):", "Broj iskaznice treba biti pozitivni cijeli broj!");
            c.Status=Pomocno.UcitajBroj("Unesite status clana(" + c.Status + "):", "Status clana treba biti 0 ili 1!");
            
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
