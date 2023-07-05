using System;
public class Program
{
 
    public static int choosenWay = 1;

    public static void Main()
    {
        Console.WriteLine("*****************************");
        
        Console.Write("Unesi svoje ime:");
        String ime1 = Console.ReadLine();
        
        Console.Write("Unesi ime svoje simpatije:");
        String ime2 = Console.ReadLine();
       
        String spojenaImena = (ime1 + ime2).ToUpper(); 

        Console.WriteLine("0 - jednostavniji nacin");
        Console.WriteLine("1 - tezi nacin");

        String nacin = Console.ReadLine();
        Program.choosenWay = Convert.ToInt32(nacin);

        Console.WriteLine("*****************************");
        
        int[] arrayBrojeva = new int[spojenaImena.Length];
        char[] pregledanaSlova = new char[spojenaImena.Length];
        
        for (int i = 0; i < spojenaImena.Length; i++)
        {
    
            arrayBrojeva[i] = pronadjiSlovo(spojenaImena[i], spojenaImena, i, pregledanaSlova);
            pregledanaSlova[i] = spojenaImena[i];
           
            ispisNizaKaraktera(pregledanaSlova);
            
            Console.WriteLine(" ");
            
            ispisNizaBrojeva(arrayBrojeva);
        }

        
        zbrojiKreirajNoviRed(arrayBrojeva);
    }

    public static int pronadjiSlovo(char slovo, string spojenaImena, int startPozicija, char[] pregledanaSlova)
    {
       
        startPozicija = (choosenWay == 0) ? 0 : startPozicija;
        
        int brojPodudaranja = 0;
        
        for (int i = startPozicija; i < spojenaImena.Length; i++)
        {
           
            if (slovo == spojenaImena[i])
            {
               
                brojPodudaranja++;
            }
        }

        
        if (choosenWay == 1) 
        {
            
            if (vecNadjeno(slovo, pregledanaSlova) == true)
            {
               
                return 0;
            }
        }

        return brojPodudaranja;
    }

    public static bool vecNadjeno(char slovo, char[] pregledanaSlova)
    {
        
        bool nadjeno = false;
        
        foreach (char slovoIzPregledanih in pregledanaSlova)
        {
            if (slovoIzPregledanih == slovo)
                nadjeno = true;
        }

        
        return nadjeno;
    }

    public static int[] zbrojiKreirajNoviRed(int[] arrayBrojeva)
    {
       
        int[] newArrayBr = (arrayBrojeva.Length % 2 != 0) ? new int[(arrayBrojeva.Length + 1) / 2] : new int[arrayBrojeva.Length / 2];
        for (int i = 0; i < arrayBrojeva.Length; i++)
        {
            
            int prviBrojNiza = arrayBrojeva[i];
         
            int zadjniBrojNiza = arrayBrojeva[((arrayBrojeva.Length - 1) - i)];
           
            if (i < (arrayBrojeva.Length / 2))
            {
               
                newArrayBr[i] = prviBrojNiza + zadjniBrojNiza;
            }
            else 
            {
                if (i == arrayBrojeva.Length - i - 1)
                {
                    
                    newArrayBr[i] = arrayBrojeva[i];
                }
            }
        }

       
        ispisNizaBrojeva(newArrayBr);
        int duljinaNovogArraya = newArrayBr.Length;
       
        if (duljinaNovogArraya != 2)
        { 
            zbrojiKreirajNoviRed(newArrayBr);
        }
        else
        {
           
            ispišiPostotak(newArrayBr);
        }

       
        return newArrayBr;
    }

    public static void ispisNizaBrojeva(int[] nizBrojeva)
    {
        
        foreach (int broj in nizBrojeva)
        {
            Console.Write(broj + ", ");
        }

        
        Console.WriteLine(" ");
    }

    public static void ispisNizaKaraktera(char[] nizKaraktera)
    {
       
        foreach (char slovo in nizKaraktera)
        {
            Console.Write(slovo + ", ");
        }
    }

    public static void ispišiPostotak(int[] postotak)
    {
        int prviBroj = postotak[0];
        
        int drugiBroj = postotak[1];

       
        if (choosenWay == 0)
        {
            
            prviBroj = (postotak[0] >= 10) ? 1 : postotak[0];
            drugiBroj = (postotak[1] >= 10) ? 1 : postotak[1];
        }
       
        String lovePercentString = "" + prviBroj + drugiBroj; 
                                                              
        int lovePercentInt = Convert.ToInt32(lovePercentString);
        
        String lovePercent = (lovePercentInt >= 100) ? "100" : lovePercentString;
       
        Console.WriteLine("");
        Console.WriteLine("    o o.o o");
        Console.WriteLine("  o        o");
        Console.WriteLine("  o   " + lovePercent + "%  o");
        Console.WriteLine("   o      o");
        Console.WriteLine("    o   o");
        Console.WriteLine("      o ");
    }
}

