using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ConsoleAppEdunova
{
    internal class ObradaSmjer
    {
        public static List<Smjer>Smjerovi { get; set; }

        public ObradaSmjer()
        {
            Smjerovi = new List<Smjer>();
            if (Pomocno.dev)
            {
                testniPodaci();
            }
        }

       

        public void prikaziIzbornik()
        {
            Pomocno.dodajPrazanRed();
            Console.WriteLine("--- Izbornik za rad sa smjerovima ---");
            Pomocno.dodajPrazanRed();
            Console.WriteLine("1. Pregled postojećih smjerova");
            Console.WriteLine("2. Unos novog smjera");
            Console.WriteLine("3. Promjena postojećeg smjera");
            Console.WriteLine("4. Brisanje smjera");
            Console.WriteLine("5. Povratak na glavni izbornik");
            Pomocno.dodajPrazanRed();
            switch (Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika smjera:","Odabir mora biti 1-5",1,5))
            {
                case 1:
                    Pomocno.obrisiEkran();
                    prikaziSmjerove();
                    prikaziIzbornik();
                    break;
                case 2:
                    Pomocno.obrisiEkran();
                    unosNovogSmjera();
                    prikaziIzbornik();
                    break;
                case 3:
                    Pomocno.obrisiEkran();
                    promjenaSmjera();
                    prikaziIzbornik();
                    break;
                case 4:
                    Pomocno.obrisiEkran();
                    if (Smjerovi.Count==0)
                    {
                        Console.WriteLine("Ne postoje smjerovi za brisanje!!");
                    }
                    else
                    {
                        brisanjeSmjera();
                    }
                    prikaziIzbornik();
                    break;
                case 5:
                    Pomocno.obrisiEkran();
                    Console.WriteLine("Gotov rad sa smjerovima");
                    break;
            }
            Pomocno.dodajPrazanRed();
        }

        private void brisanjeSmjera()
        {
            prikaziSmjerove();
            int index = Pomocno.ucitajBrojRaspon("Odaberite redni broj smjera:", "Nije dobar odabir", 1,
                Smjerovi.Count());
            Smjerovi.RemoveAt(index-1);
        }

        private void promjenaSmjera()
        {
            prikaziSmjerove();
            int index = Pomocno.ucitajBrojRaspon("Odaberite redni broj smjera:", "Nije dobar odabir!!", 1,
                Smjerovi.Count());
            var s = Smjerovi[index - 1];
            //Ovdje čuvamo stare podatke u slučaju da korisnik odustane od spremanja izmjena
            var stariPodaci = SacuvajPodatke(s);
            // popunjavamo nove podatke
            s.ID = Pomocno.ucitajCijeliBroj("Unesite šifra smjera (" + s.ID + "): ",
                "Unos mora biti pozitivni cijeli broj");
            s.Naziv = Pomocno.ucitaString("Unesite naziv smjera (" + s.Naziv + "): ",
                "Unos obavezan");
            s.Trajanje = Pomocno.ucitajCijeliBroj("Unesite trajanje smjera u satima (" + s.Trajanje + "): ",
                "Unos mora biti cijeli pozitivni broj");
            s.Cijena = Pomocno.ucitajDecimalniBroj("Unesite cijenu (. za decimalni dio) (" + s.Cijena + "): ", "Unos mora biti pozitivan broj");
            s.Upisnina = Pomocno.ucitajDecimalniBroj("Unesi upisninu (. za decimalni dio) (" + s.Upisnina + "): ", "Unos mora biti pozitivan broj");
            s.Verificiran = Pomocno.ucitajBool("Smjer verificiran? Da ili bilo što drugo za ne (" + (s.Verificiran ? "da" : "ne") + "): ");
            if (!Pomocno.spremiPromjene())
            {
                Smjerovi[index - 1] = stariPodaci;
            }
        }

        private Smjer SacuvajPodatke(Smjer smjer)
        {
            return new Smjer
            {
                ID = smjer.ID,
                Naziv = smjer.Naziv,
                Trajanje = smjer.Trajanje,
                Cijena = smjer.Cijena,
                Upisnina = smjer.Upisnina,
                Verificiran = smjer.Verificiran
            };
        }

        private void unosNovogSmjera()
        {
            var smjer = new Smjer();
            smjer.ID = Pomocno.ucitajCijeliBroj("Unesite šifru smjera: ", "Unos mora biti pozitivni cijeli broj");
            // provjeri da li šifra već postoji
            while (provjeriId(smjer.ID)) // pozivom metode provjeriSifru
            {
                Console.WriteLine("Šifra: {0} već postoji za ovaj smjer! ",smjer.ID);
                smjer.ID = Pomocno.ucitajCijeliBroj("Unesite šifru smjera: ", "Unos mora biti pozitivni cijeli broj");
            }
            smjer.Naziv = Pomocno.ucitaString("Unesite naziv smjera: ","Unos obavezan");
            smjer.Trajanje = Pomocno.ucitajCijeliBroj("Unesite trajanje smjera u satima: ","Unos mora biti cijeli pozitivni broj");
            smjer.Cijena = Pomocno.ucitajDecimalniBroj("Unesite cijenu (. za decimalni dio): ", "Unos mora biti pozitivan broj");
            smjer.Upisnina = Pomocno.ucitajDecimalniBroj("Unesi upisninu (. za decimalni dio): ", "Unos mora biti pozitivan broj");
            smjer.Verificiran = Pomocno.ucitajBool("Smjer verificiran? Da ili bilo što drugo za ne: ");
            Smjerovi.Add(smjer);
        }

        private bool provjeriId(int smjerId)
        {
            foreach (Smjer smjer in Smjerovi )
            {
                if (smjer.ID==smjerId)
                {
                    return true;
                }
                
            }

            return false;
        }

        private void prikaziSmjerove()
        {
            Pomocno.dodajPrazanRed();
            Console.WriteLine("---- Smjerovi ----");
            Pomocno.dodajPrazanRed();
                int b = 1;
                foreach (Smjer smjer in Smjerovi)
                {
                    Console.WriteLine("{0}. {1}", b++, smjer.Naziv);
                }

                Console.WriteLine(" ");
                
        }

        private void testniPodaci()
        {
            Smjerovi.Add(new Smjer
            {
                ID = 1,
                Naziv = "Web programiranje",
                Trajanje = 250,
                Cijena = 1000,
                Upisnina = 50,
                Verificiran = true
            });

            Smjerovi.Add(new Smjer
            {
                ID = 2,
                Naziv = "Java programiranje",
                Trajanje = 130,
                Cijena = 1000,
                Upisnina = 50,
                Verificiran = true
            });
        }
    }
}