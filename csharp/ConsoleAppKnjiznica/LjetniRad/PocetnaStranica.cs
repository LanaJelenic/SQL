using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LjetniRad
{
    internal class PocetnaStranica
    {
        public obradaClana obradaClana { get; }
        public obradaKnjige obradaKnjige { get; }
        public obradaEvidencije obradaEvidencije { get; }

        public PocetnaStranica()
        {
            obradaClana = new obradaClana();
            obradaKnjige = new obradaKnjige();
            obradaEvidencije = new obradaEvidencije();
            IspisNazivaAplikacije();
            PrikaziPocetnu();

}


        private void IspisNazivaAplikacije()
            {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("-----Knjiznica Console APP v 1.0-----");
            Console.WriteLine("-------------------------------------");
        }

            private void PrikaziPocetnu()
            {
            Console.WriteLine("Pocetna");
            Console.WriteLine("-------");
            Console.WriteLine("1.Clanovi");
            Console.WriteLine("2.Knjige");
            Console.WriteLine("3.Evidencije posudbe");
            Console.WriteLine("4.Izlaz iz programa");

            switch(Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika:",
                "Odabir treba biti od 1-4",1,4))
            {
                case 1:
                    obradaClana.PrikaziIzbornik();
                    PrikaziPocetnu();
                    break;

                case 2:
                    obradaKnjige.PrikaziIzbornik();
                    PrikaziPocetnu();
                    break;
                case 3:
                    obradaEvidencije.PrikaziIzbornik();
                    PrikaziPocetnu();
                    break;
                case 4:
                    Console.WriteLine("Hvala na koristenju, dovidenje");
                    break;

            }

        }
        }
    }

