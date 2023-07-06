using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01Naslijedivanje
{
    internal class Osoba
    {

       
        
            int brojac;
            protected bool uvjet;
            private string naziv;
            internal DateTime datum;

            public int Sifra { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }

            public Osoba() { }
            public override string ToString()
            {
                return Ime + " " + Prezime;
            }
            public override bool Equals(object? obj)
            {
               var o=obj as Osoba;
                return Sifra.Equals(o.Sifra);
            }
        }
    }

