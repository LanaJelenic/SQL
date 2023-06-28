int[] niz = { 2, 3, 3, 4, 5, 5 };

for (int i = 0; i < niz.Length; i++)
{
    Console.WriteLine(niz[i]);
}
Console.WriteLine("*******************");

for (int i = niz.Length - 1; i >= 0; i--)
{
    Console.WriteLine(niz[i]);
}
Console.WriteLine("*******************");


foreach (int en in niz)
{
    Console.WriteLine(en);
}