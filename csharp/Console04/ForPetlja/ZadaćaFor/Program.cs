Console.WriteLine("------------------------------------");
Console.WriteLine(": : : TABLICA MNOZENJA : : :");
Console.WriteLine("------------------------------------");



string t;
int br = 1;

for (int i = 1; i <10; i++)
{
    Console.Write(br +"|");
    for (int j= 1; j < 10; j++)
    {
        t = "    " + i * j;
        Console.Write(t[^4..]);
    }
    br++;
    Console.WriteLine();
}

Console.WriteLine("------------------------------------");
Console.WriteLine("  :   :   :   :   :   :   :  by Lana");




