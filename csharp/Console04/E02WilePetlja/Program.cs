
while (true)
{
    break;
}

for (int i = 0; i < 0; i++)
{
    Console.WriteLine("01 Nisam ušao");
}



while (false)
{
    Console.WriteLine("02 Nisam ušao");
}


int b = 0;

while (b < 10)
{
    Console.WriteLine(++b);

}

int t = 2;
b = 0;
while (t == 2 && b < 10)
{
    Console.WriteLine(++b);
}
Console.WriteLine("*************");
b = 0;
while (true)
{
    if (b == 2)
    {
        b++;
        continue;
    }
    if (b == 5)
    {
        break;
    }
    Console.WriteLine(b++);
}





// Napišite program koji pomoću while petlje ispisuje 
// Svaki 3. broj između 2 i 97

// 1. rješenje
b = 2;
while (b <= 97)
{
    Console.WriteLine(b);
    b += 3;
}

// 2. rješenje

b = 2;
while (true)
{
    Console.WriteLine(b);
    b += 3;
    if (b > 97)
    {
        break;
    }
}



int zbroj = 0;
b = 0;
while (b++ < 100)
{
    zbroj += b;
}
Console.WriteLine(zbroj);

// drugi način
zbroj = 0; b = 1;
while (b <= 100)
{
    zbroj += b;
    b++;
}
Console.WriteLine(zbroj);





