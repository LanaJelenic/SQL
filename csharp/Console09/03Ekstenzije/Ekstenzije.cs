using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Ekstenzije
{
    public static class Ekstenzije
    {
        public static int BrojPonavljanja(this string s,char z)
        {
            return s.Count(x => x == z);
        }
        public static void OdradiPosao(this ISucelje sucelje)
        {
            sucelje.Posao();
        }
    }
}
