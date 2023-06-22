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
for(int i = 0;i < 10;i = i + 2)
{
    Console.WriteLine("Csharp");

}

Console.WriteLine("4.-----------");
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}

Console.WriteLine("5.-----------");
for(int i=0;i < 10;i++)
{

    Console.WriteLine(i+1);
}

Console.WriteLine("6.-----------");
int zbroj = 0;
for(int i=1;i<10;i++)
{
    zbroj += i;
}
Console.WriteLine(zbroj);

Console.WriteLine("7.-----------");
for(int i=1;i<=57;i++)
{
    if(i%2==0)
    {
        Console.WriteLine(i);
    }
}

Console.WriteLine("8.-----------");
zbroj = 0;
for(int i=2;i<18;i++)
{
    if(i%2==0) 
    {
        zbroj += i;
    }
}
Console.WriteLine(zbroj);

int[] niz = { 2, 2, 34, 54, 5, 6, 76, 7, 8, 7, 8 };

Console.WriteLine("9.-----------");
for(int i=0;i<niz.Length;i++)
{
    Console.WriteLine(niz[i]);
}
