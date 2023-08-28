using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Delegati
{
    internal class PrimjerKoristenja1
    {
        public PrimjerKoristenja1()
        {
            ObradaSmjer os=new ObradaSmjer();
            os.IspisSmjer(MojIspisUOvojKlasi);


        }

        private void MojIspisUOvojKlasi(Smjer s)
        {
            Console.WriteLine(s.naziv);
        }
    }
}
