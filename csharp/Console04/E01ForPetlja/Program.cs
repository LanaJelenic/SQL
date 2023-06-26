Console.WriteLine("1.-----------");
for (int i = 0; i < 10; i = i + 1)
{
    Console.WriteLine("Osijek");
}

Console.WriteLine("2.-----------");
int j = 0;
for (j = 10; j > 0; j--)
{
    Console.WriteLine("Edunova");

}

Console.WriteLine("3.-----------");
for (int i = 0; i < 10; i = i + 2)
{
    Console.WriteLine("Csharp");

}

Console.WriteLine("4.-----------");
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}

Console.WriteLine("5.-----------");
for (int i = 0; i < 10; i++)
{

    Console.WriteLine(i + 1);
}

Console.WriteLine("6.-----------");
int zbroj = 0;
for (int i = 1; i < 10; i++)
{
    zbroj += i;
}
Console.WriteLine(zbroj);

Console.WriteLine("7.-----------");
for (int i = 1; i <= 57; i++)
{
    if (i % 2 == 0)
    {
        Console.WriteLine(i);
    }
}

Console.WriteLine("8.-----------");
zbroj = 0;
for (int i = 2; i < 18; i++)
{
    if (i % 2 == 0)
    {
        zbroj += i;
    }
}
Console.WriteLine(zbroj);

int[] niz = { 2, 2, 34, 54, 5, 6, 76, 7, 8, 7, 8 };

Console.WriteLine("9.-----------");
for (int i = 0; i < niz.Length; i++)
{
    Console.WriteLine(niz[i]);
}

Console.WriteLine("10.--------");
Console.Write("Unesi koliko brojeva provjeravaš:");
int brojevi = int.Parse(Console.ReadLine());
int broj;
int najveci = int.MinValue;
for (int i = 0; i < brojevi; i++)
{
    Console.WriteLine("Unesi {0} .broj:", i + 1);
    broj = int.Parse(Console.ReadLine());
    if (broj > najveci)
    {
        najveci = broj;
    }
}
Console.WriteLine("Najveci broj je {0} ", najveci);

Console.WriteLine("11.--------");
for (; ; )
{

    Console.WriteLine(new Random().NextDouble());
    break;
}
Console.WriteLine("12.--------");
for (int i = 0; i < 10; i++)
{
    if (i == 3)
    {
        Console.WriteLine(i);
    }
}

Console.WriteLine("13.--------");
for (int i = 0; i < 10; i++)
{
    if (i == 2 || i == 5)
    {
        continue;
    }
    Console.WriteLine(i);
}

Console.WriteLine("14.--------");

string s;
for (int i = 1; i < 10; i++)
{
    for (int k = 1; k <= 10; k++)
    {
        s = "  " + i * k;
        Console.Write(s[^4..]);
    }
    Console.WriteLine();
}

Console.WriteLine("15.--------");
for (int i = 0; i < 10; i++)
{
    for (int k = 0; k < 10; k++)
    {

        goto labela;
    }
}

labela:;

for(int i=0; i < 10; i++)
{

    Console.WriteLine("Osijek");
}

int j;
for (j = 0; j < 10; j++)
{
    Console.WriteLine("Osijek");
}

for(j=10;j>0;j--)
{
    Console.WriteLine("Osijek");
}

for(int k=0;k<20;k+=2)
{
    Console.WriteLine("Osijek");
}

for(int x=0;x<10;x++)
{
    console.WriteLine(x + 1);
}
bool uvjet = true;
for(int x=1;uvjet;x++)
{
    console.Write(x);
    uvjet = x < 10;
}

for(int i=0;i<10;i++)
{
    for(int j=0;j<10;j++)
    {
        console.write("{0}",(i+1)*(j+1));
    }
    console.WriteLine();
}

string s;
for(int i=0;i<10;i++)
{
    for(int k=0;k<10;k++)
    {
        var b=(i+1)*(k+1);
        s = " " + b;
        console.Write("{0}", s[^4..]);
    }
    console.WriteLine();
}


