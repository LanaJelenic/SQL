using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01KlasaObjekt
{
    internal class Osoba
    {
        public Osoba()
        {
            Console.WriteLine("Konstruktor klase osoba");
        }

        public Osoba(string name) 
        {
            Console.WriteLine(name);
        }

    }
}
