using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LjetniRad
{
    internal class Clan:ID
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int BrojIskaznice { get; set; }
        public int Status { get; set; }
        
    }
}
