int i = 2;
if (i == 1)
{
    Console.WriteLine("Dobro");
}
else if (i == 2)
{
    Console.WriteLine("OK");
}
else
{
    Console.WriteLine("Ostalo");
}

int ocjena = 3;

switch (ocjena)
{ 
   case 1:
        Console.WriteLine("Nedovoljan");
        break;
   case 2:
        Console.WriteLine("Dovoljan");
        break;
    case 3:
        Console.WriteLine("Dobar");
        break;
    case 4:
        Console.WriteLine("Vrlo dobar");
        break;
    case 5:
        Console.WriteLine("Izvrstan");
        break;
    default:
        Console.WriteLine("Nije ocjena");
        break;
}

string grad=Console.ReadLine();

switch (grad)
{
    case "Osijek":
        Console.WriteLine("Osiječko-baranjska");
        break;
    case "Vukovar":
        Console.WriteLine("Vukovarsko-srijemska");
        break;
    case "Požega":
        Console.WriteLine("Požeško-slavonska");
        break;
    case "Virovitica":
        Console.WriteLine("Virovitičko-podravska");
        break;
    default: 
        Console.WriteLine("Nije grad!!");
        break;
}
