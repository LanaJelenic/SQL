using E01KlasaObjekt;
using System;
using System.Runtime.CompilerServices;

class Program
{
    private static void Main(string[] args)
    {
        Osoba osoba = new Osoba();
        osoba = new Osoba("Pero");
        Osoba natjecatelj = new Osoba();
        var prijavitelj= new Osoba("Marija");
        var i = 1;
        Console.WriteLine("----------------");

        Dokument[] dokumenti= new Dokument[3];
        dokumenti[0] = new Dokument();
        dokumenti[1] = new Dokument();
        dokumenti[2] = new Dokument("Račun");
        Console.WriteLine("----------------");
        Smjer smjer = new Smjer("Web programiranje",3.45f);
        Console.WriteLine("--------------------------------");

        Grupa grupa;

        for(int j=1;j<=128;j++)
        {
            grupa= new Grupa();
        }
    }
}
