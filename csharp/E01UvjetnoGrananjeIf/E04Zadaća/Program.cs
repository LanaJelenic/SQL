int i = 3;
int b = 5;

if (i > b)
{
    Console.WriteLine(i);
}
else
{
    Console.WriteLine(b);

}

if (b > i)
{

    Console.WriteLine(b);
}
else
{
    Console.WriteLine(i);
}

if (b >= b)
{
    Console.WriteLine(b);
}
else
{
    Console.WriteLine("Ne postoji");
}


Console.Write("Izaberi broj izmedu 1-999:");
int br = int.Parse(Console.ReadLine());

if (br > 999)
{
    Console.WriteLine("ERROR!!");
}
else
{
    Console.WriteLine(br / 10);
}
