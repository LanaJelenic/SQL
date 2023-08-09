using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine(" ");
            Console.WriteLine("Izbornik za rad s grupama");
            Console.WriteLine("--------------------------");
            Console.WriteLine("1. Pregled postojećih grupa");
            Console.WriteLine("2. Unos nove grupe");
            Console.WriteLine("3. Promjena postojeće grupe");
            Console.WriteLine("4. Brisanje grupe");
            Console.WriteLine("5. Povratak na glavni izbornik");
            switch (Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika grupa: ",
                "Odabir mora biti 1-5", 1, 5))
            {
                case 1:
                    PrikaziGrupe();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNoveGrupe();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjenaGrupe();
                    PrikaziIzbornik();
                    break;
                case 4:
                    BrisanjeGrupe();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Gotov rad s grupama");
                    break;
            }
        }

        private void PromjenaGrupe()
        {
            PrikaziGrupe();
            int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj grupe: ", "Nije dobar odabir", 1, Grupe.Count());
            var grupa = Grupe[index - 1];
            grupa.Sifra = Pomocno.ucitajCijeliBroj("Unesite šifru grupe (" + grupa.Sifra + "): ",
                "Unos mora biti pozitivni cijeli broj");
            grupa.Naziv = Pomocno.UcitajString("Unesite naziv grupe (" + grupa.Naziv + "): ",
                "Unos obavezan");
            Console.WriteLine("Trenutni smjer: {0}", grupa.Smjer.Naziv);
            grupa.Smjer = Pomocno.UcitajSmjerove();
        }

        private Smjer PostaviSmjer()
        {
            Izbornik.obradaSmjer.PrikaziSmjerove();
            int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj grupe: ", "Nije dobar odabir", 1, ObradaSmjer.Smjerovi.Count());
            return ObradaSmjer.Smjerovi[index-1];  
        }

        private void BrisanjeGrupe()
        {
            PrikaziGrupe();
            int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj grupe: ", "Nije dobar odabir", 1, Grupe.Count());
            Grupe.RemoveAt(index - 1);
        }

        private void UnosNoveGrupe()
        {
            var g = new Grupa();
            g.Sifra = Pomocno.ucitajCijeliBroj("Unesite šifru grupe: ","Unos mora biti pozitivni cijeli broj");
            g.Naziv = Pomocno.UcitajString("Unesite naziv grupe: ", "Unos obavezan");
            g.Smjer = Pomocno.UcitajSmjerove();
            //PostaviSmjer();
            //g.Polaznici = PostaviPolaznike();
            g.DatumPocetka = Pomocno.ucitajDatum("Unesi datum grupe u formatu dd.MM.yyyy.", "Greška");
            Grupe.Add(g);

        }

        private List<Polaznik> PostaviPolaznike()
        {
            List<Polaznik> polaznici = new List<Polaznik>();
            while (Pomocno.ucitajBool("Želite li dodati polaznike? (da ili bilo što drugo za ne): "))
            {
                polaznici.Add(PostaviPolaznika());
            }

            return polaznici;
        }

        private Polaznik PostaviPolaznika()
        {
            Izbornik.obradaPolaznik.PregledPolaznika();
            int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj polaznika: ", "Nije dobar odabir", 1, ObradaPolaznik.Polaznici.Count());
            return ObradaPolaznik.Polaznici[index - 1];
        }

        private void ObrisiPolaznika()
        {
            
        }

        public void PrikaziGrupe()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("---- Grupe ----");
            Console.WriteLine("------------------");
            String.Format("{0,27}", "sdf");
            int b = 1;
            int polaznikRedniBroj = 1;
            foreach (Grupa grupa in Grupe)
            {
                Console.WriteLine("{0}. {1} {2}", b++, grupa.Naziv, grupa.Smjer.Naziv);
                Console.WriteLine("\t Polaznici grupe:");
                foreach (Polaznik polaznik in grupa.Polaznici)
                {
                    Console.WriteLine("\t \t {0}. {1} {2}", polaznikRedniBroj++,polaznik.Ime,polaznik.Prezime);
                }
            }
            Console.WriteLine("------------------");
        }

        private void TestniPodaci()
        {
            List<Polaznik> ListaPolaznikaGrupeCV1 = new List<Polaznik>();
                ListaPolaznikaGrupeCV1.Add(new Polaznik
                {
                    Sifra = 1,
                    Ime = "Manuela",
                    Prezime = "Lacković",
                    Email = "mani@gmail.com",
                    Oib = "5435345345"
                });
                ListaPolaznikaGrupeCV1.Add(new Polaznik
                {
                    Sifra = 1,
                    Ime = "Daria",
                    Prezime = "Zetović",
                    Email = "zeti@gmail.com",
                    Oib = "4848488484"
                });
                
            List<Polaznik> ListaPolaznikaGrupeCV2 = new List<Polaznik>();
                ListaPolaznikaGrupeCV2.Add(new Polaznik
                {
                    Sifra = 1,
                    Ime = "Martina",
                    Prezime = "Perković",
                    Email = "marti@gmail.com",
                    Oib = "5435345345"
                });
                ListaPolaznikaGrupeCV2.Add(new Polaznik
                {
                    Sifra = 1,
                    Ime = "Marina",
                    Prezime = "Vilovic",
                    Email = "marina@gmail.com",
                    Oib = "4848488484"
                });
            
            Grupe.Add(new Grupa()
            {
                Sifra = 1,
                Naziv = "CV1",
                DatumPocetka = System.DateTime.Now,
                Smjer = new Smjer
                {
                    Sifra = 1,
                    Naziv = "Cvječarstvo u primjeni",
                    Trajanje = 250,
                    Cijena = 1000,
                    Upisnina = 50,
                    Verificiran = true
                },
                Polaznici = ListaPolaznikaGrupeCV1
            });
            
            Grupe.Add(new Grupa()
            {
                Sifra = 2,
                Naziv = "CV2",
                DatumPocetka = System.DateTime.Now,
                Smjer = new Smjer
                {
                    Sifra = 1,
                    Naziv = "Primjenjeno cvječarstvo",
                    Trajanje = 250,
                    Cijena = 1000,
                    Upisnina = 50,
                    Verificiran = true
                },
                Polaznici = ListaPolaznikaGrupeCV2
            });

        }

    }
}