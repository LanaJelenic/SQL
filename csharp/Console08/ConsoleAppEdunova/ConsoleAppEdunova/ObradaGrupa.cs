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
        throw new NotImplementedException();
    }

    private void promjenaGrupe()
    {
        throw new NotImplementedException();
    }

    private void brisanjeGrupe()
    {
        throw new NotImplementedException();
    }


    private void testniPodatci()
    {
        throw new NotImplementedException();
    }
}