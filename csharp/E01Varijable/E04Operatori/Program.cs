bool razlicito = 3 != 4;
bool vece = 8 > 6;
Console.WriteLine("{0},{1}",razlicito, vece);

bool rez = razlicito & vece;
string s = "Edunova" + "Osijek";
int x = 6 + 2;
string s1 = "Broj" + 5;

Console.Write("Unesi broj:");
x = Int16.Parse(Console.ReadLine());
Console.WriteLine(x%2==0);

int negativniBroj = -262;
int zbr=negativniBroj*(-1);
Console.WriteLine(zbr);

Console.Write("Unesi prvi broj:");
double cj1=double.Parse(Console.ReadLine());

Console.Write("Unesi drugi broj:");
double cj2=double.Parse(Console.ReadLine());

double dj = cj1 / cj2;
Console.WriteLine(dj);

decimal cj3 = 5.00m;
decimal cj4 = 10.00m;
decimal f = cj3 / cj4;
Console.WriteLine(f);

int dv1 = 21;
int dv2 = 87;
Console.WriteLine(dv1/11);
Console.WriteLine(dv2/11);
