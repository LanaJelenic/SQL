using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01Naslijedivanje
{
    internal class Polaznik:Osoba
    {
        public string BrojUgovora { get; set; }
        public override string ToString()
        {
            return base.ToString() + " " + BrojUgovora;
        }
    }
}
