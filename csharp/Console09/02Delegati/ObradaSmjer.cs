using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Delegati
{
    internal class ObradaSmjer
    {
        public delegate void IspisPozivSmjer(Smjer s);
        private readonly List<Smjer> Smjerovi;

        public ObradaSmjer()
            {
            Smjerovi = new()
            {
                new(){sifra=1,naziv="Prvi"},
                new(){sifra=2,naziv="Drugi"}
            };
        }
        public void IspisSmjer(IspisPozivSmjer poziv)
        {
            Smjerovi.ForEach(s => poziv(s));
        }

        public void IspisSmjerAction(Action<Smjer> poziv) 
        {
          Smjerovi.ForEach(s => poziv(s));  
        }
    }
}
