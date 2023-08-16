using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LjetniRad;

namespace ConsoleAppEdunova
{
    internal class Izbornik
    {
        public ObradaSmjer obradaSmjer { get; }
        public ObradaPolaznik ObradaPolaznik { get; }
        private ObradaGrupa obradaGrupa;

        public Izbornik()
        {
            obradaSmjer = new ObradaSmjer();
            ObradaPolaznik = new ObradaPolaznik();
            obradaGrupa = new ObradaGrupa();
            pozdravnaPoruka();
            prikaziIzbornik();
        }

        private void prikaziIzbornik()
        {
           Pomocno.obrisiEkran();
           Console.WriteLine("Glavni izbornik");
           Console.WriteLine("---------------");
           Console.WriteLine("1. Smjerovi");
           Console.WriteLine("2. Polaznici");
           Console.WriteLine("3. Grupe");
           Console.WriteLine("4. Izlaz iz programa");
           Pomocno.dodajPrazanRed();

           switch (Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika:","Odabir mora biti od 1-4",1,4))
           {
               case 1:
                   Pomocno.obrisiEkran();
                   obradaSmjer.prikaziIzbornik();
                   prikaziIzbornik();
                   break;
               case 2:
                   Pomocno.obrisiEkran();
                   ObradaPolaznik.prikaziIzbornik();
                   prikaziIzbornik();
                   break;
               case 3:
                   Pomocno.obrisiEkran();
                   obradaGrupa.PrikaziIzbornik();
                   prikaziIzbornik();
                   break;
               case 4:
                   Pomocno.obrisiEkran();
                   Console.WriteLine("Hvala na korištenju :),doviđenja");
                   break;
           }
           Pomocno.obrisiEkran();
           
        }

        private void pozdravnaPoruka()
        {
            Console.WriteLine("*************************************");
            Console.WriteLine("***** Edunova Console APP v 1.0 *****");
            Console.WriteLine("*************************************");
        }
    }
}
