using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LjetniRad
{
    internal class EvidencijaPosudbe:ID
    {
        public DateTime DatumPosudbe { get; set; }
        public DateTime DatumVracanja { get; set; }
        public  List<Clan> Clanovi { get; set; }
        public Knjiga knjiga{ get; set; }
    }
}
