using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEdunova;

internal class ObradaPolaznik
{
    public static List<Polaznik> Polaznici { get; set; }

    public ObradaPolaznik()
    {
        Polaznici = new List<Polaznik>();
        if (Pomocno.dev)
        {
            testniPodaci();
        }
    }

    public void prikaziIzbornik()
    {
        Pomocno.dodajPrazanRed();
        Console.WriteLine("--- Izbornik za rad s polaznicima ---");
        Pomocno.dodajPrazanRed();
        Console.WriteLine("1. Pregled postojećih polaznika");
        Console.WriteLine("2. Unos novog polaznika");
        Console.WriteLine("3. Promjena postojećeg polaznika");
        Console.WriteLine("4. Brisanje polaznika");
        Console.WriteLine("5. Povratak na glavni izbornik");
        Pomocno.dodajPrazanRed();
        switch (Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika polaznika:","Odabir mora biti 1-5",1,5))
        {
            case 1:
                Pomocno.obrisiEkran();
                pregledPolaznika();
                prikaziIzbornik();
                break;
            case 2:
                Pomocno.obrisiEkran();
                unosPolaznika();
                prikaziIzbornik();
                break;
            case 3:
                Pomocno.obrisiEkran();
                promjenaPolaznika();
                prikaziIzbornik();
                break;
            case 4:
                Pomocno.obrisiEkran();
                if (Polaznici.Count==0)
                {
                    Console.WriteLine("Ne postoji niti jedan polaznik!");
                }
                else
                {
                    brisanjePolaznika();
                }
                prikaziIzbornik();
                break;
            case 5:
                Pomocno.obrisiEkran();
                Console.WriteLine("Gotov rad s polaznicima");
                break;
                
        }
        
    }

   public static void pregledPolaznika()
    {
        Console.WriteLine("------------------");
        Console.WriteLine("---- Polaznici ----");
        Console.WriteLine("------------------");
        int b = 1;
        foreach (Polaznik polaznik in Polaznici)
        {
            Console.WriteLine("{0}. {1} {2}", b++,polaznik.Ime,polaznik.Prezime);
        }

        Console.WriteLine("------------------");
    }

    private void unosPolaznika()
    {
        var p = new Polaznik();
        p.ID = Pomocno.ucitajCijeliBroj("Unesite šifra polaznika: ",
            "Unos mora biti pozitivni cijeli broj");
        p.Ime = Pomocno.ucitaString("Unesi ime polaznika: ", "Ime obavezno");
        p.Prezime = Pomocno.ucitaString("Unesi Prezime polaznika: ", "Prezime obavezno");
        p.Email = Pomocno.ucitaString("Unesi Email polaznika: ", "Email obavezno");
        p.Oib = Pomocno.ucitaString("Unesi OIB polaznika: ", "OIB obavezno");
        Polaznici.Add(p);
    }

    private void promjenaPolaznika()
    {
        int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj polaznika: ", "Nije dobar odabir", 1,
            Polaznici.Count());
        var p = Polaznici[index - 1];
        var stariPodatci = sacuvajPodatke(p);
        p.ID = Pomocno.ucitajCijeliBroj("Unesite šifra polaznika (" + p.ID + "): ",
            "Unos mora biti pozitivni cijeli broj");
        p.Ime = Pomocno.ucitaString("Unesi ime polaznika (" + p.Ime + "): ", "Ime obavezno");
        p.Prezime = Pomocno.ucitaString("Unesi Prezime polaznika (" + p.Prezime + "): ", "Prezime obavezno");
        p.Email = Pomocno.ucitaString("Unesi Email polaznika (" + p.Email + "): ", "Email obavezno");
        p.Oib = Pomocno.ucitaString("Unesi OIB polaznika (" + p.Oib + "): ", "OIB obavezno");
        if (!Pomocno.spremiPromjene())
        {
            Polaznici[index - 1] = stariPodatci;
        }
    }

    private Polaznik sacuvajPodatke(Polaznik polaznik)
    {
        return new Polaznik
        {
            ID = polaznik.ID,
            Ime = polaznik.Ime,
            Prezime = polaznik.Prezime,
            Email = polaznik.Email,
            Oib = polaznik.Oib

        };
    }

    private void brisanjePolaznika()
    {
       pregledPolaznika();
       int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj polaznika: ", "Nije dobar odabir", 1, Polaznici.Count());
       Polaznici.RemoveAt(index-1);
    }


    private void testniPodaci()
    {
        
        Polaznici.Add(new Polaznik
        {
            ID = 1,
            Ime = "Ana",
            Prezime = "Gal",
            Email = "agal@gmail.com",
            Oib = "33736472822"
        });

        Polaznici.Add(new Polaznik
        {
            ID = 2,
            Ime = "Marija",
            Prezime = "Zimska",
            Email = "mzimska@gmail.com",
            Oib = "33736472821"
        });
            
        Polaznici.Add(new Polaznik
        {
            ID = 3,
            Ime = "Lota",
            Prezime = "Plehinger",
            Email = "lota@gmail.com",
            Oib = "53736472821"
        });
    }
}