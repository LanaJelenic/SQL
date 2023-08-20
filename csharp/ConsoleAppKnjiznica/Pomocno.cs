namespace LjetniRad
{
    internal class Pomocno
    {
        public static bool dev;
        public static int ucitajBrojRaspon(string poruka,string greska,int poc,int kraj)
        {
            int b;
            while(true)
            {
                Console.Write(poruka);
                try
                {
                    b = int.Parse(Console.ReadLine());
                    if(b>=poc && b<=kraj)
                    {
                        return b;
                    }
                    Console.WriteLine(greska);
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(greska);
                }
            }
        }
        internal static int UcitajBroj(string poruka,string greska)
        {
            int b;
            while(true) 
            {
                Console.Write(poruka);
                try
                {
                    b=int.Parse(Console.ReadLine());
                    if(b>0)
                    {
                        return b;
                    }
                    Console.WriteLine(greska);
                }
                catch(Exception ex) 
                {
                    Console.WriteLine(greska);
                }
            }
        }
        
        internal static bool ucitajBool(string poruka)
        {
            Console.Write(poruka);
            return Console.ReadLine().Trim().ToLower().Equals("da")?true:false;
        }

        internal static DateTime ucitajDatum(string v1, string v2)
        {
            while(true) 
            {
              try
              {
                  Console.Write(v1);
                  return DateTime.Parse(Console.ReadLine());
              }
              catch(Exception ex) 
              {
                  Console.Write(v2);
              }
            }
        }

        internal static string UcitajString(string poruka, string greska) 
        {
            //string s= Console.ReadLine();
            while(true) 
            {
                Console.Write(poruka);
                string s= Console.ReadLine();
                if(s!=null && s.Trim().Length>0) 
                {
                    if (s.Any(char.IsDigit)) // Provjeravamo da li je bilo koji od unesenih slova broj
                    {
                        // ako je, vraćamo da unos mora biti tekstualan
                        Console.WriteLine("Unos mora biti samo u tekstualnom obliku, bez brojeva!");
                    }
                    else
                    {
                        return s; 
                    }
                }
                Console.WriteLine(greska);
            }
        }

        internal static bool UcitajBool(string poruka)
        {
            Console.Write(poruka);
            return Console.ReadLine().Trim().ToLower().Equals("da")? true : false;  
        }

        public static void ObrisiEkran()
        {
            Console.Clear();
        }
        
        public static void DodajPrazanRed()
        {
            Console.WriteLine(" ");
        }
        
        public static bool SpremiPromjene()
        {
            return ucitajBool("Želite li spremiti promjene?  (da ili bilo što drugo za ne): ");
        }
    }
}
