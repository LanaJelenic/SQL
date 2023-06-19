Console.WriteLine("What is the temperature outside: (C)");
double temp =double.Parse(Console.ReadLine());

if (temp >= 10 && temp <= 25)
{
    Console.WriteLine("It's decent outside!!");
}
else if (temp <= -50 || temp >= 50)
{
    Console.WriteLine("Do not go outside!!");
}