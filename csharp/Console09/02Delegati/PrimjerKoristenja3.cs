using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Delegati
{
    internal class PrimjerKoristenja3
    {
        public PrimjerKoristenja3()
        {
            var os = new ObradaSmjer();
            Action<Smjer> a = new(MetodaOvdje);
            os.IspisSmjerAction(a);
        }

        void MetodaOvdje (Smjer s)
        {
            Console.WriteLine("\"" + s.naziv + "\"");
        }
    }
}
