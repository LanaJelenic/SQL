using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LjetniRad
{
    internal class Posudba
    {
        public int BrojIskazniceClana { get; set; }
        public int idKnjige { get; set; }
        public DateTime DatumPosudbe { get; set; }
        public DateTime DatumVracanja { get; set; }
    }
}
