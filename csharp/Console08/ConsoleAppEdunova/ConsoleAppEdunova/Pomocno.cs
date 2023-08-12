using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEdunova
{
    internal class Pomocno
    {
        public static bool dev;

        internal static int ucitajBrojRaspon(string poruka, string greska, int poc, int kraj)
        {
            int b;
            while (true)
            {
                Console.Write(poruka);
                try
                {
                    b = int.Parse(Console.ReadLine());
                    if (b>=poc && b<=kraj)
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
            decimal d;
            while (true)
            {
                Console.Write(poruka);
                try
                {
                    d = int.Parse(Console.ReadLine());
                    if (d>0)
                    {
                        return d;
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
            return Console.ReadLine().Trim().ToLower().Equals("da") ? true : false;
        }

        internal static string ucitaString(string poruka, string greska)
        {
            string s = "";
            while (true)
            {
                Console.Write(poruka);
                s = Console.ReadLine();
                if (s!=null && s.Trim().Length>0)
                {
                    return s;
                }

                Console.WriteLine(greska);
            }
        }

        internal static DateTime ucitajDatum(string v1, string v2)
        {
            while (true)
            {
                try
                {
                    Console.Write(v1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(v2);
                    
                }
            }
        }

        public static void obrisiEkran()
        {
            Console.Clear();
        }

        public static void dodajPrazanRed()
        {
            Console.WriteLine(" ");
        }

        public static bool spremiPromjene()
        {
            return ucitajBool("Želite li spremiti promjene?(da ili bilo što drugo za ne):");
        }

        internal static int ucitajCijeliBroj(string poruka, string greska)
        {
            int b;
            while (true)
            {
                Console.Write(poruka);
                try
                {
                    b = int.Parse(Console.ReadLine());
                    if (b>0)
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
    }
}