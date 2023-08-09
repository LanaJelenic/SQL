using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LjetniRad
{
    internal class obradaEvidencije
    {
       public List<EvidencijaPosudbe> Evidencije { get; }
        private PocetnaStranica pocetnaStranica;

        public obradaEvidencije(PocetnaStranica pocetnaStranica):this() 
        {
        this.pocetnaStranica = pocetnaStranica;
          
        }

        public obradaEvidencije() 
        {
            Evidencije = new List<EvidencijaPosudbe>();
        }
        public void PrikaziIzbornik()
        {
            Console.WriteLine("Izbornik za rad s evidencijama posudbe");
            Console.WriteLine(" 1. Pregled postojecih evidencija");
            Console.WriteLine(" 2. Unos nove evidencije:");
            Console.WriteLine(" 3. Promjena postojece evidencije");
            Console.WriteLine(" 4. Brisaje evidencije");
            Console.WriteLine(" 5. Povratak na pocetnu stranicu");

            switch(Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika evidencije posudbe:",
                "Odabir treba biti od 1-5",1,5))
            {

                case 1:
                    PregledEvidencije();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosEvidencije();
                    PrikaziIzbornik();
                        break;
                case 3:
                    PromjenaEvidencije();
                    PrikaziIzbornik();
                    break;
                case 4:
                    BrisanjeEvidencije();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.WriteLine("Zavrsen rad s evidencijama posudbe");
                    break;
            }

        }

        private void PregledEvidencije()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("-----Evidencija posudbe-----");
            Console.WriteLine("----------------------------");
            int b = 1;

            foreach (EvidencijaPosudbe evidencija in Evidencije)
            {
                Console.WriteLine("{0}. {1} {2}, datum posudbe:{3},datum vracanja:{4}",b++, evidencija.Id,evidencija.Clanovi,
                    evidencija.DatumPosudbe,evidencija.DatumVracanja);
            }
            Console.WriteLine("----------------------------");
        }

        private void UnosEvidencije()
        {
            var e = new EvidencijaPosudbe();
            e.Id = Pomocno.UcitajBroj("Unesite ID evidencije:", "Unos bi trebao biti pozitivni cijeli broj");
            e.DatumPosudbe = Pomocno.ucitajDatum("Unesite datum posudbe:", "Datum posudbe obavezan!!");
            e.DatumVracanja = Pomocno.ucitajDatum("Unesite datum vracanja:", "Datum vracanja obavezan!!");
        }

        private void PromjenaEvidencije()
        {
            PregledEvidencije();
            int br = Pomocno.ucitajBrojRaspon("Odaberi broj evidencije:", "Error!", 1, Evidencije.Count());
            var e = Evidencije[br-1];
            e.Id=Pomocno.UcitajBroj("Unesite ID evidencije(" + e.Id +"):", "Unos bi trebao biti pozitivni cijeli broj");
            e.DatumPosudbe = Pomocno.ucitajDatum("Unesite datum posudbe(" + e.DatumPosudbe + "):", "Datum posudbe obavezan!!");
            e.DatumVracanja = Pomocno.ucitajDatum("Unesite datum vracanja(" + e.DatumVracanja + ");", "Datum vracanja obavezan!!");

        }

        private void BrisanjeEvidencije()
        {
            PregledEvidencije();
            int br=Pomocno.ucitajBrojRaspon("Odaberite ID evidencije:","Erro!!",1,Evidencije.Count());
            Evidencije.RemoveAt(br-1);
        }
    }
}

