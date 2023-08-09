  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LjetniRad
{
    internal class Knjiga:ID
    {
        public string Naslov { get; set; }
        public string ImeAutora { get; set; }
        public string PrezimeAutora { get; set; }
        public string Sazetak { get; set; }
        public int BrojStranica { get; set; }
    }
}
