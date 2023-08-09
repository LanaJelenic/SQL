using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LjetniRad
{
    internal class Pomocno
    {
        public static bool dev;
        internal static int ucitajBrojRaspon(string poruka, string greska, int poc, int kraj)
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

        internal static int ucitajCijeliBroj(string poruka, string greska)
        {
            int b;
            while(true) 
            {
                Console.WriteLine(poruka);
                try
                {
                    b=int.Parse(Console.ReadLine());
                    if(b>0)
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

        internal static decimal ucitajDecimalniBroj(string poruka, string greska)
        {
            decimal b;
            while(true)
            {
                Console.Write(poruka);
                try
                {
                    b=decimal.Parse(Console.ReadLine());
                    if(b>0)
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
        internal static bool ucitajBool(string poruka)
        {
            Console.Write(poruka);
            return Console.ReadLine().Trim().ToLower().Equals("da")?true:false;
        }

        internal static string UcitajString(string poruka, string greska)
        {
        
          string s="";
            while(true) 
            {
                Console.Write(poruka);
                s=Console.ReadLine();
                if(s!=null&& s.Trim().Length>0)
                {
                    return s;
                }
                Console.WriteLine(greska);


            }
        }
        internal static Smjer UcitajSmjerove()
        {
            Console.WriteLine("MOGUĆI SMJEROVI:");
            Console.WriteLine("---------------");
            // Učitavamo prikaz svih smjerova
            int b = 1;
            foreach (Smjer smjer in ObradaSmjer.Smjerovi)
            {
                Console.WriteLine("{0}. {1}", b++, smjer.Naziv);
            }

            while (true)
            {
                var smjer = ucitajCijeliBroj("Odaberite smjer za grupu: ", "Unos mora biti pozitivni cijeli broj");
                if (smjer-1 < ObradaSmjer.Smjerovi.Count)
                {
                    // Vracamo smjer pod rednim brojem kojeg korisnik odabere
                    return ObradaSmjer.Smjerovi[smjer];
                }
            }
        }

        internal static DateTime ucitajDatum(string v1, string v2) 
        {
          while(true) 
            {
              try
                {
                    Console.WriteLine(v1);
                    return DateTime.Parse(Console.ReadLine());
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(v2);
                }
            }
        }
    }
}
