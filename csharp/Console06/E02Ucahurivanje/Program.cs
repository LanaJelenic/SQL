using E02Ucahurivanje;

internal class Program
{
    private static void Main(string[] args)
    {
        Osoba osoba = new Osoba();
        osoba.setIme("Mara");
        osoba.Prezime = "Maric";
        Console.WriteLine("{0} {1}", osoba.Prezime, osoba.getIme());
        Console.WriteLine("--------------------------------------");


        Smjer smjer = new Smjer();
        smjer.Sifra = 1;
        smjer.Naziv = "Web programiranje";
        smjer.Trajanje = 250;

        smjer = new Smjer
        {
            Sifra = 1,
            Naziv = "Java programiranje"
        };
        Console.WriteLine("--------------");

        Zupanija zupanija = new Zupanija
        {
            Naziv="Osiječko-baranjska",
            Zupan="Anušić"
        };

        Grad grad = new Grad
        {
           Naziv="Osijek",
           zupanija=zupanija
        };
        Console.WriteLine("Grad je {0}, županija je {1}",grad.Naziv,grad.zupanija.Naziv);
    }

}