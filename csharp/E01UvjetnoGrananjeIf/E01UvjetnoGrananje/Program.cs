int i = 0;
bool uvjet = i > 0;
if (uvjet)
{
    Console.WriteLine("01:Veće od 0");
}

if (i > 0)
{
    Console.WriteLine("02:Opet veće od 0");
}

if(!uvjet)
    Console.WriteLine("03:Nije veće od 0");
    Console.WriteLine("04:Ovo isto ne bi trebalo biti veće od 0");

string grad = "Osijek";
if (grad == "Osijek")
{
    Console.WriteLine("05:SUPER");
}
else 
{
    Console.WriteLine("06:OK");
}
int b = 0;
if (grad != "Zagreb")
{
    b = b + 1;
}
else if (grad == "Split")
{
    b += 1;
}
else if (grad == "Osijek")
{
    b += 2;
}
else
{
    b++;
}
Console.WriteLine("07:" + b);

i = 0; b = 2;
if (i > 0)
{
    if (b == 2)
    {
        Console.WriteLine("08:Oba uvjeta su zadovoljena");
    }
}

if (i > 0 && b == 2)
{
    Console.WriteLine("09:Oba uvjeta su zadovoljena");
}
if (i == 4 || b < 0)
{ 

}

int g = 10;
if (g % 2 == 0)
{
    Console.WriteLine("10:Broj je paran");
}
else
{
    Console.WriteLine("11:Broj je neparan");
}

Console.WriteLine("12:Broj je" + (g%2==0? "":"ne")+ "paran");

Console.Write("Unesi cijeli broj:");
int cj1= int.Parse(Console.ReadLine());

if (cj1 < 10)
{
    Console.WriteLine("Osijek");
}
else
{
    Console.WriteLine("Donji Miholjac");
}

Console.Write("Unesi cijeli broj:");
cj1= int.Parse(Console.ReadLine());

Console.WriteLine("13:Broj je " + (cj1 % 2 == 0 ? "" : "ne") + "paran");

Console.Write("Unesi prvi broj:");
cj1= int.Parse(Console.ReadLine());

Console.Write("Unesi prvi broj:");
int cj2=int.Parse(Console.ReadLine());

int zbr = cj1 + cj2;

if (zbr > 10)
{
    Console.WriteLine("Osijek");
}
else
{
    Console.WriteLine("Edunova");
}

int i = 1;
bool uvjet = i > 0;

if(uvjet)
{
    Console.WriteLine("vece od 0");
}

if(i > 0)
{
    Console.WriteLine("vece od 0");
}

if(uvjet)
{
    Console.WriteLine("vece od 0");
}
else
{
    Console.WriteLine(" NIJE vece od 0");

}

if(uvjet)
{
    Console.WriteLine("vece od 0");
}
else if(i==-1)
{
    Console.WriteLine("-1");
}
else
{
    Console.WriteLine(" NIJE vece od 0");
}

if(i>0)
{
    if(x<0)
    {
        Console.WriteLine("Osijek");
    }
}

if(i>0)
{
    Console.WriteLine("vece od 0");
}
else
{
    Console.WriteLine("NIJE vece od 0");
}

console.WriteLine(i > 0 ? "vece od 0" : "NIJE vece od 0");

int x = 1, y = 0;
if(x!= 1 & y>0)
{
    console.WriteLine("Osijek");
}

if(x != 1 && y>0)
{
    console.WriteLine("Osijek");
}

if(x==1|y==0)
{
    console.WriteLine("Osijek");
}

if(x==1||y==0)
{
    console.WriteLine("Osijek");
}