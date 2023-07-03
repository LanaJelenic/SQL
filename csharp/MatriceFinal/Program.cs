internal class Program
{
    private static void Main(string[] args)
    {
      
        Console.Write("Unesi broj redova: ");
        int brojRedaka = int.Parse(Console.ReadLine());
      
        Console.Write("Unesi broj stupaca: ");
        int brojStupaca = int.Parse(Console.ReadLine());

       
        Console.Write("Pritisnite 0 za ispis naprijed,1 za ispis nazad \n");
        Console.WriteLine("0 - naprijed ");
        Console.WriteLine("1 - nazad ");
        int smjer = int.Parse(Console.ReadLine());

       
        int[,] matrica = new int[brojRedaka, brojStupaca];


        if(smjer == 1)
        {
            popunjavanjeMatriceLijevo(matrica);
        }
        else
        {
    
            popunjavanjeMatriceDesno(matrica);
        }
    }


    public static void popunjavanjeMatriceDesno(int[,] matrica)
    {
        int pocetniRed = 0, pocetniStupac = 0, broj = 1;
        int zadnjiRed = matrica.GetLength(0) - 1; 
        int zadnjiStupac = matrica.GetLength(1) - 1;

   

        while (pocetniRed <= zadnjiRed && pocetniStupac <= zadnjiStupac)
        {
            // *************************** desno ***********************************
            for (int i = pocetniStupac; i <= zadnjiStupac; i++)
            {
                matrica[pocetniRed, i] = broj++;
            }
          
            pocetniRed++;

            // *************************** dolje ***********************************
            for (int j = pocetniRed; j <= zadnjiRed; j++)
            {
                matrica[j, zadnjiStupac] = broj++;
            }
            zadnjiStupac--;

            // *************************** lijevo ***********************************
            if (pocetniRed <= zadnjiRed)
            {
                for (int j = zadnjiStupac; j >= pocetniStupac; j--)
                {
                    matrica[zadnjiRed, j] = broj++;
                }
            }
            zadnjiRed--;

            // *************************** gore ***********************************
            if (pocetniStupac <= zadnjiStupac)
            {
                for (int i = zadnjiRed; i >= pocetniRed; i--)
                {
                    matrica[i, pocetniStupac] = broj++;
                }
            }

            pocetniStupac++;
        }

        Console.WriteLine(" \n ******** Ispis matrice u naprijed *********** \n");
      
        ispisMatrice(matrica);

    }


    public static void popunjavanjeMatriceLijevo(int[,] matrica)
    {
        int pocetniRed = 0, pocetniStupac = 0, broj = 1;
        int zadnjiRed = matrica.GetLength(0) - 1;
        int zadnjiStupac = matrica.GetLength(1) - 1;

        while (pocetniRed <= zadnjiRed && pocetniStupac <= zadnjiStupac)
        {
            // *************************** lijevo ***********************************
            for (int i = zadnjiStupac; i >= pocetniStupac; i--)
            {
                matrica[zadnjiRed, i] = broj++;
            }
            zadnjiRed--;

            // *************************** gore *************************************
            // popunjava od donjeg lijevo prema gore
            for (int i = zadnjiRed; i >= pocetniRed; i--)
            {
                matrica[i, pocetniRed] = broj++;
            }
            pocetniStupac++;

            // ****************************** desno **********************************
            if (pocetniRed <= zadnjiRed)
            {
                for (int i = pocetniStupac; i <= zadnjiStupac; i++)
                {
                    matrica[pocetniRed, i] = broj++;
                }
            }
            pocetniRed++;

            // **************************** dolje ***********************************
            if (pocetniStupac <= zadnjiStupac)
            {
                for (int i = pocetniRed; i <= zadnjiRed; i++)
                {
                    matrica[i, zadnjiStupac] = broj++;
                }
            }
            zadnjiStupac--;

        }

        Console.WriteLine(" \n ******** Ispis matrice unazad *********** \n");
       
        ispisMatrice(matrica);
    }



    public static void ispisMatrice(int[,] matrica)
    {
        for (int i = 0; i < matrica.GetLength(0); i++)
        {
            for (int j = 0; j < matrica.GetLength(1); j++)
            {
                Console.Write("{0,4}", (matrica[i, j] + "|"));
            }
            Console.WriteLine();
        }
    }
}