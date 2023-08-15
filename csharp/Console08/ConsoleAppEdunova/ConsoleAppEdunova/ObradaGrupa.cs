using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ConsoleAppEdunova;

internal class ObradaGrupa
{
    public List<Grupa>Grupe { get; }
    private Izbornik izbornik;

    public ObradaGrupa(Izbornik izbornik) : this()
    {
        this.izbornik = izbornik;
    }

    public ObradaGrupa()
    {
        Grupe = new List<Grupa>();
        if (Pomocno.dev)
        {
            testniPodatci();
        }
    }

    

    public void prikaziIzbornik()
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
               prikaziGrupe();
               prikaziIzbornik();
               break;
           
           case 2:
               Pomocno.obrisiEkran();
               unosNoveGrupe();
               prikaziIzbornik();
               break;
           case 3 :
               Pomocno.obrisiEkran();
               promjenaGrupe();
               prikaziIzbornik();
               break;
           case 4 :
               Pomocno.obrisiEkran();
               if (Grupe.Count==0)
               {
                   Console.WriteLine("Nema grupa za brisanje!!");
               }
               else
               {
                   brisanjeGrupe();
               }
               prikaziIzbornik();
               break;
           case 5:
               Pomocno.obrisiEkran();
               Console.WriteLine("Gotov rad s grupama");
               break;
               
           
       }
    }

    public void prikaziGrupe()
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

    private void unosNoveGrupe()
    {
        var grupa = new Grupa();
        int id = Pomocno.ucitajCijeliBroj("Unesite id grupe: ", "Unos mora biti pozitivni cijeli broj");
        while (provjeriID(id))
        {
            Console.WriteLine("ID: {0} već postoji za ovu grupu!",id);
            id = Pomocno.ucitajCijeliBroj("Unesite ID grupe: ", "Unos mora biti pozitivni cijeli broj");
            grupa.ID = id;
        }

        grupa.Naziv = Pomocno.ucitaString("Unesite naziv grupe: ", "Unos obavezan");
        grupa.Smjer = postaviSmjer();

        List<Polaznik> polaznici = new List<Polaznik>();
        dodajPolaznikaGrupe(polaznici);
        grupa.Polaznici = polaznici;
        grupa.DatumPocetka = Pomocno.ucitajDatum("Unesi datum početka u formatu dd.MM.yyyy. : ", "Greška");
        if (Pomocno.spremiPromjene())
        {
            Grupe.Add(grupa);
        }
    }

    private List<Polaznik> dodajPolaznikaGrupe(List<Polaznik> polaznici)
    {
        while (Pomocno.ucitajBool("Želite li dodati polaznike? (da ili bilo što drugo za ne): "))
        {
            polaznici.Add(postaviPolaznika());
        }

        return polaznici;
    }

    private Polaznik postaviPolaznika()
    {
       ObradaPolaznik.pregledPolaznika();
       int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj polaznika: ", "Nije dobar odabir", 1,
           ObradaPolaznik.Polaznici.Count());
       return ObradaPolaznik.Polaznici[index - 1];

    }

    private Smjer postaviSmjer()
    {
        ObradaSmjer.prikaziSmjerove();
        int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj smjera: ", "Nije dobar odabir", 1,
            ObradaSmjer.Smjerovi.Count());
        return ObradaSmjer.Smjerovi[index - 1];

    }

    private bool provjeriID(int id)
    {
        foreach (Grupa smjer  in Grupe)
        {
            if (smjer.ID==id)
            {
                return true;
            }
        }

        return false;
    }

    private void promjenaGrupe()
    {
        prikaziGrupe();
        int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj grupe: ", "Nije dobar odabir", 1, Grupe.Count());
        var grupa = Grupe[index - 1];
        var stariPodatci = sacuvajPodatke(grupa);
        grupa.ID = Pomocno.ucitajCijeliBroj("Unesite ID grupe (" + grupa.ID + "): ",
            "Unos mora biti pozitivni cijeli broj");
        grupa.Naziv = Pomocno.ucitaString("Unesite naziv grupe (" + grupa.Naziv + "): ","Unos obavezan");
        Console.WriteLine("Trenutni smjer: {0}", grupa.Smjer.Naziv);
        grupa.Smjer = postaviSmjer();
        grupa.Polaznici = postaviPolaznike(grupa.Polaznici);
    }

    private List<Polaznik> postaviPolaznike(List<Polaznik> grupaPolaznici)
    {
        List<Polaznik> polaznici = grupaPolaznici != null ? grupaPolaznici : new List<Polaznik>();
        dodajPolaznikaGrupe(polaznici);
        obrisiPolaznikaGrupe(polaznici);
        return polaznici;
    }

    private List<Polaznik> obrisiPolaznikaGrupe(List<Polaznik>polaznici)
    {
        while (Pomocno.ucitajBool("Želite li obrisati polaznika iz grupe? (da ili bilo što drugo za ne): "))
        {
            int redniBrojPolaznika = Pomocno.ucitajBrojRaspon("Odaberi redni broj polaznika: ", "Nije dobar odabir", 1,
                polaznici.Count);
            polaznici.RemoveAt(redniBrojPolaznika-1);
        }

        return polaznici;
    }

    private Grupa sacuvajPodatke(Grupa grupa)
    {
        return new Grupa
        {
            Naziv = grupa.Naziv,
            Polaznici = grupa.Polaznici,
            Smjer = grupa.Smjer,
            DatumPocetka = grupa.DatumPocetka,
            ID = grupa.ID
        };
    }

    private void brisanjeGrupe()
    {
       prikaziGrupe();
       int index = Pomocno.ucitajBrojRaspon("Odaberi redni broj grupe: ", "Nije dobar odabir", 1, Grupe.Count());
       if (Pomocno.spremiPromjene())
       {
           Grupe.RemoveAt(index-1);
       }
    }


    private void testniPodatci()
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