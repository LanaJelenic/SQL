Console.Write("Unesi prvi broj:");
int br1 = int.Parse(Console.ReadLine());

Console.Write("Unesi drugi broj:");
int br2 = int.Parse(Console.ReadLine());
string p = "";
int zbr = 0;
for (int i = br1; i <= br2; i++)
{
    if (i % 2 == 0)
    {
        p += " " + i;
        zbr += i;
    }
}
Console.WriteLine("");
Console.WriteLine("Parni brojevi="  + p);
Console.WriteLine("Zbroj parnih brojeva od " + br1 + "-" + br2 + "=" + zbr);