using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppEdunova;

namespace LjetniRad
{
    internal class ObradaGrupa
    {
        public List<Grupa> Grupe { get; }

        private Izbornik Izbornik;

        public ObradaGrupa(Izbornik izbornik) : this()
        {
            this.Izbornik = izbornik;
        }

        public ObradaGrupa()
        {
            Grupe = new List<Grupa>();
            if (Pomocno.dev)
            {
                TestniPodaci();
            }
        }

        public void PrikaziIzbornik()
        {
            Pomocno.dodajPrazanRed();
            Console.WriteLine("Izbornik za rad s grupama");
            Console.WriteLine("--------------------------");
            Console.WriteLine("1. Pregled postojećih grupa");
            Console.WriteLine("2. Unos nove grupe");
            Console.WriteLine("3. Promjena postojeće grupe");
            Console.WriteLine("4. Brisanje grupe");
            Console.WriteLine("5. Povratak na glavni izbornik");
            Pomocno.dodajPrazanRed();
            
            switch (Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika grupa: ",
                "Odabir mora biti 1-5", 1, 5))
            {
                case 1:
                    Pomocno.obrisiEkran();
                    PrikaziGrupe();
                    PrikaziIzbornik();
                    break;
                case 2:
                    Pomocno.obrisiEkran();
                    UnosNoveGrupe();
                    Pomocno.obrisiEkran();
                    PrikaziIzbornik();
                    break;
                case 3:
                    Pomocno.obrisiEkran();
                    PromjenaGrupe();
                    Pomocno.obrisiEkran();
                    PrikaziIzbornik();
                    break;
                case 4:
                    Pomocno.obrisiEkran();
                    BrisanjeGrupe();
                    Pomocno.obrisiEkran();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Pomocno.obrisiEkran();
                    Console.WriteLine("Gotov rad s grupama");
                    break;
            }
        }

        private void PromjenaGrupe()
        {
            PrikaziGrupe();
            int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj grupe: ", "Nije dobar odabir", 1, Grupe.Count());
            var grupa = Grupe[index - 1];
            //Ovdje čuvamo stare podatke u slučaju da korisnik odustane od spremanja izmjena
            var stariPodaci = SacuvajPodatke(grupa);
            // popunjavamo nove podatke
            grupa.ID = Pomocno.ucitajCijeliBroj("Unesite šifru grupe (" + grupa.ID + "): ","Unos mora biti pozitivni cijeli broj");
            grupa.Naziv = Pomocno.ucitaString("Unesite naziv grupe (" + grupa.Naziv + "): ","Unos obavezan");
            Console.WriteLine("Trenutni smjer: {0}", grupa.Smjer.Naziv);
            grupa.Smjer = PostaviSmjer();
            grupa.Polaznici = PostaviPolaznike(grupa.Polaznici);
            
            if (!Pomocno.spremiPromjene()) //Korisnik je odabrao da ne želi spremiti promjene
            {
                // vračamo stare podatke za odabranu grupu
                Grupe[index - 1] = stariPodaci;
            }
        }

        private Grupa SacuvajPodatke(Grupa podaciGrupe)
        {
            // kreiramo novi objekt sa starim podacima grupe
            return new Grupa // i vračamo ih nazad pozivatelju metode
            {
                Naziv = podaciGrupe.Naziv,
                Polaznici = podaciGrupe.Polaznici,
                Smjer = podaciGrupe.Smjer,
                DatumPocetka = podaciGrupe.DatumPocetka,
                ID = podaciGrupe.ID
            };
        }
        

        private Smjer PostaviSmjer()
        {
            ObradaSmjer.prikaziSmjerove();
            int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj smjera: ", "Nije dobar odabir", 1, ObradaSmjer.Smjerovi.Count());
            return ObradaSmjer.Smjerovi[index-1];  
        }

        private void BrisanjeGrupe()
        {
            PrikaziGrupe();
            int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj grupe: ", "Nije dobar odabir", 1, Grupe.Count());
            if (Pomocno.spremiPromjene())
            {
                Grupe.RemoveAt(index - 1);
            }
        }

        private void UnosNoveGrupe()
        {
            var grupa = new Grupa();
            int sifra = Pomocno.ucitajCijeliBroj("Unesite šifru grupe: ", "Unos mora biti pozitivni cijeli broj");
            
            while (ProvjeriSifru(sifra)) // pozivom metode provjeriSifru
            {
                Console.WriteLine("Šifra: {0} već postoji za ovau grupu! ",sifra);
                sifra = Pomocno.ucitajCijeliBroj("Unesite šifru grupe: ", "Unos mora biti pozitivni cijeli broj");
                grupa.ID = sifra;
            }

            grupa.Naziv = Pomocno.ucitaString("Unesite naziv grupe: ", "Unos obavezan");
            grupa.Smjer = PostaviSmjer(); //Pomocno.OdaberiSmjerove();
            
            
            // Dodavanje polaznika u listu polaznika
            List<Polaznik> polaznici = new List<Polaznik>();
            // Dodavanje polaznika grupi*/
            DodajPolaznikaGrupe(polaznici);
            grupa.Polaznici = polaznici;
            grupa.DatumPocetka = Pomocno.ucitajDatum("Unesi datum početka u formatu dd.MM.yyyy. : ", "Greška");
            if (Pomocno.spremiPromjene())
            {
                Grupe.Add(grupa);
            }
            
        }
        
        private bool ProvjeriSifru(int sifra)
        {
            foreach (Grupa smjer in Grupe) // prođi kroz sve smjerove i za svaki
            {
                if (smjer.ID == sifra) // provjeri da li je šifra jednaka onoj kou smo poslali
                {
                    return true; // ako je vrati da postoji i prekini loop
                }
            }
            return false; // u suprotnom vrati da ne postoji
        }
        
        private List<Polaznik> PostaviPolaznike(List<Polaznik> grupaPolaznici)
        {
            List<Polaznik> polaznici = grupaPolaznici!= null ? grupaPolaznici : new List<Polaznik>();
            // Ponudimo dodavanje polaznika u grupu
            DodajPolaznikaGrupe(polaznici);
            // Ponudimo brisanje polaznika iz grupe
            ObrisiPolaznikaGrupe(polaznici);
            
            return polaznici;
        }

        private Polaznik PostaviPolaznika()
        {
            ObradaPolaznik.pregledPolaznika();
            int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj polaznika: ", "Nije dobar odabir", 1, ObradaPolaznik.Polaznici.Count());
            return ObradaPolaznik.Polaznici[index - 1];
        }

        private List<Polaznik>  DodajPolaznikaGrupe(List<Polaznik> polaznici)
        {
            while (Pomocno.ucitajBool("Želite li dodati polaznike? (da ili bilo što drugo za ne): "))
            {
                // Dodavanje polaznika u grupu
                polaznici.Add(PostaviPolaznika());
            }
            return polaznici;
        }
        
        
        private List<Polaznik>  ObrisiPolaznikaGrupe(List<Polaznik> polaznici)
        {
            while (Pomocno.ucitajBool("Želite li obrisati polaznika iz grupe? (da ili bilo što drugo za ne): "))
            {
                int redniBrojPolaznika = Pomocno.ucitajBrojRaspon("Odaberi redni broj polaznika: ", "Nije dobar odabir",1, polaznici.Count);
                // Brisanje polaznika iz grupe
                polaznici.RemoveAt(redniBrojPolaznika -1);
            }
            return polaznici;
        }

        public void PrikaziGrupe()
        {
            Console.WriteLine("---- Grupe ----");
            Console.WriteLine("------------------");
            int b = 1;
            
            foreach (Grupa grupa in Grupe)
            {
                Console.WriteLine("{0}. {1} {2} ", b++, grupa.Naziv, grupa.Smjer.Naziv);
                Console.WriteLine("\t Polaznici grupe:");
                int polaznikRedniBroj = 1;
                foreach (Polaznik polaznik in grupa.Polaznici)
                {
                    Console.WriteLine("\t \t {0}. {1} {2}", polaznikRedniBroj++,polaznik.Ime,polaznik.Prezime);
                }
            }
            Console.WriteLine("  ");
        }

        private void TestniPodaci()
        {
            List<Polaznik> ListaPolaznikaGrupeCV1 = new List<Polaznik>
            {
                ObradaPolaznik.Polaznici[0],
                ObradaPolaznik.Polaznici[1]
            };

            List<Polaznik> ListaPolaznikaGrupeCV2 = new List<Polaznik>
            {
                ObradaPolaznik.Polaznici[1]
            };

            Grupe.Add(new Grupa()
            {
               ID = 1,
                Naziv = "WP1",
                DatumPocetka = System.DateTime.Now,
                Smjer = ObradaSmjer.Smjerovi[0],
                Polaznici = ListaPolaznikaGrupeCV1
            });
            
            Grupe.Add(new Grupa()
            {
                ID = 2,
                Naziv = "JP1",
                DatumPocetka = System.DateTime.Now,
                Smjer = ObradaSmjer.Smjerovi[1],
                Polaznici = ListaPolaznikaGrupeCV2
            });

        }

    }
}