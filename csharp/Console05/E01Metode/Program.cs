
using zajednickeMetode

void Tip1()
{
    Console.WriteLine("Dobrodošli u program");
}


void Tip2(string poruka)
{
    Console.WriteLine(poruka);
}

Tip2("Ovo je vrijednst koju proslijeđujem");

string s = "Vrijednost varijable s";

Tip2(s);


int Tip3()
{
    return new Random().Next();
}

Tip3();

Console.WriteLine(Tip3());

int sb = Tip3();

Console.WriteLine(sb);



int Tip4(int min, int max)
{
    int manji = min < max ? min : max;
    int veci = max > min ? max : min;
    sb = 3; // vidimo varijablu izvan metode (razina klase)
            // poruka = ""; ne vidimo varijablu iz neke druge metode
    return new Random().Next(manji, veci);
}


Console.WriteLine(Tip4(20, 30));
Console.WriteLine(Tip4(-20, -30));



void ispis()
{
    Console.WriteLine("Hello world");
}


Metode m = new Metode();

m.ispis();
m.ispis("12");
m.ispis(12);

Console.WriteLine(Metode.izracunaj(2, 8));

int[,] t = new int[5, 5];

Metode.ispisiMatricu(t);

t[2, 4] = 7;

Metode.ispisiMatricu(t);

Console.WriteLine(Metode.faktorijel(5));

