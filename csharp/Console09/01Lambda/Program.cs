
using _01Lambda;
using System.Threading.Channels;

int KlasicnaMetoda(int Klasicna)
{
    return Klasicna * Klasicna;
   }
Console.WriteLine(KlasicnaMetoda(5));

var kvadrat = (int b) => b * b;

Console.WriteLine(kvadrat(5));

var algoritam = (int x, int y) =>
{
    var t = x++ + y--;
    return x + y - t;
};
Console.WriteLine(algoritam(1,2));

int[] brojevi = { 2, 3, 4, 3, 2, 3, 4, 3 };
int ukupno=0;

foreach (int k in brojevi)
{
    if(k==3)
    {
        ukupno++;
    }
}
Console.WriteLine(ukupno);
Console.WriteLine(brojevi.Count(b=>b>3));

for(int i=0;i<brojevi.Length;i++)
{
    Console.WriteLine(brojevi[i]);
}
Console.WriteLine("------------");
foreach(int k in brojevi)
{
    Console.WriteLine(k);
}
Console.WriteLine("------------");

Array.ForEach(brojevi, Console.WriteLine);
Console.WriteLine("------------");

Array.ForEach(brojevi, b =>
{
    Console.WriteLine(b+1);
});

Console.WriteLine("------------");

var lista = new List<int>() { 2, 3, 4, 5, 4 };

lista.ForEach(Console.WriteLine);

var smjerovi = new List<Smjer>()
{
    new(){Naziv="prvi",sifra=1},
    new(){Naziv="drgi",sifra=2}
};

smjerovi.ForEach(Console.WriteLine);

smjerovi.ForEach(xio =>
{
    int b = xio.sifra + new Random().Next();
    Console.WriteLine(xio.Naziv + " " + b);
});

string s = "Edunova";
Console.WriteLine(s?.Replace("a","b"));

 