﻿

do
{
    Console.WriteLine("01 Ušao u petlju");
} while (false);


/
int b = 0;
do
{
    Console.Write("Unesi prvi cijeli broj: ");
    b = int.Parse(Console.ReadLine());
    if (b >= 10 && b <= 20)
    {
        break;
    }
    Console.Write("Nisi unio traženi broj.");
}
while (true);




int db = 0;
do
{
    Console.Write("Unesi drugi cijeli broj: ");
    db = int.Parse(Console.ReadLine());
    if (db >= 10 && db <= 20)
    {
        break;
    }
    Console.Write("Nisi unio traženi broj.");
}
while (true);

//Ucitane su vrijednosti varijable b i db

int manji = b < db ? b : db;

if (b < db)
{
    manji = b;

}
else
{
    manji = db;
}

int veci = db > b ? db : b;


int i = manji;
do
{
    if (i % 2 == 0)
    {
        Console.WriteLine(i);
    }
} while (++i <= veci);


