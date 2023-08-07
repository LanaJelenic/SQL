''using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LjetniRad
{
    internal class Izbornik

    {
        public ObradaSmjer obradaSmjer { get; }
        public ObradaPolaznik obradaPolaznik { get; }

        private ObradaGrupa obradaGrupa;

        public Izbornik() 
        {
         obradaSmjer= new ObradaSmjer();
         obradaPolaznik= new ObradaPolaznik();
         obradaGrupa= new ObradaGrupa();
            pozdravnaPoruka();
            prikaziIzbornik();
        }

        private void prikaziIzbornik()
        {
            Console.WriteLine("Glavni izbornik");
            Console.WriteLine("1. Smjerovi");
            Console.WriteLine("2. Polaznici");
            Console.WriteLine("3. Grupe");
            Console.WriteLine("4. Izlaz iz programa");

            switch(Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika","Odabir mora biti od 1-4",1,4))
            {
                case 1:
                    obradaSmjer.PrikaziIzbornik();
                    prikaziIzbornik();
                    break;
                case 2:
                    obradaPolaznik.PrikaziIzbornik();
                    prikaziIzbornik();
                    break;

                case 3:
                    obradaGrupa.PrikaziIzbornik();
                    prikaziIzbornik();
                    break;
                case 4:
                    Console.WriteLine("Hvala na koristenju,dovidenja");
                    break;
            }
        }

        private void pozdravnaPoruka()
        {
            Console.WriteLine("*************************************");
            Console.WriteLine("***** Edunova Console APP v 1.0 *****");
            Console.WriteLine("*************************************");
        }
    }
}
