using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Lambda
{
    internal class Smjer
    {
        public int sifra { get; set; }
        public String? Naziv { get; set; }

        public override string ToString()
        {
            return Naziv ?? "";
        }
    }
}
