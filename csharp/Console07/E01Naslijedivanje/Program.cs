using E01Naslijedivanje;

internal class Program
{
    private static void Main(string[] args)
    {
        var o = new Osoba
        {
            Sifra = 1,
            Ime = "Pero",
            Prezime = "Peric"
        };
        Console.WriteLine(o);

        var drugaOsoba = new Osoba
        {
            Sifra = 1,
            Ime="Marina",
            Prezime="Maric"
        };
        Console.WriteLine(o.Equals(drugaOsoba));

        var p = new Polaznik
        {
            Sifra = 1,
            Ime = "Marko",
            Prezime = "Kat",
            BrojUgovora = "2023/56"
        };
        Console.WriteLine(p);

        var pr = new Predavac
        {
            Sifra = 1,
            Ime = "Rita",
            Prezime = "Man",
            Iban = "HR454545445"
        };
        Console.WriteLine(pr);
    }
}