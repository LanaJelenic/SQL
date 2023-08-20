namespace LjetniRad;

internal class PocetnaStranica
{
    private static ObradaClana ObradaClana { get; set; }
    private static ObradaKnjige ObradaKnjige { get; set; }
    private static ObradaEvidencije ObradaEvidencije { get; set; }

    public PocetnaStranica()
    {
        ObradaClana = new ObradaClana();
        ObradaKnjige = new ObradaKnjige();
        ObradaEvidencije = new ObradaEvidencije();
        IspisNazivaAplikacije();
        PrikaziPocetnu();

    }


    private void IspisNazivaAplikacije()
    {
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("-----Knjiznica Console APP v 1.0-----");
        Console.WriteLine("-------------------------------------");
    }

    public static void PrikaziPocetnu()
    {
        Pomocno.DodajPrazanRed();
        Console.WriteLine("1. Clanovi");
        Console.WriteLine("2. Knjige");
        Console.WriteLine("3. Evidencije posudbe");
        Console.WriteLine("4. Izlaz iz programa");
        Pomocno.DodajPrazanRed();
        switch(Pomocno.ucitajBrojRaspon("Odaberite stavku izbornika:",
                   "Odabir treba biti od 1-4",1,4))
        {
            case 1:
                Pomocno.ObrisiEkran();
                ObradaClana.PrikaziIzbornik();
                PrikaziPocetnu();
                break;

            case 2:
                Pomocno.ObrisiEkran();
                ObradaKnjige.PrikaziIzbornik();
                PrikaziPocetnu();
                break;
            case 3:
                Pomocno.ObrisiEkran();
                Console.WriteLine("Evidencija posudbe");
                ObradaEvidencije.PrikaziIzbornik();
                break;
            case 4:
                Pomocno.ObrisiEkran();
                Console.WriteLine("Hvala na koristenju, dovidenja");
                break;

        }

    }
}