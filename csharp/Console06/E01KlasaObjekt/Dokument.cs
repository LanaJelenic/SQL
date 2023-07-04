using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01KlasaObjekt
{
    internal class Dokument
    {
        public Dokument() 
        {
            Console.WriteLine("Dokument");
        }

        public Dokument(string name) 
        {
            Console.WriteLine(name);
        }
    }
}
