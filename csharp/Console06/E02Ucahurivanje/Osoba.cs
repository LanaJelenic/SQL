using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E02Ucahurivanje
{
    internal class Osoba
    {
        private string ime;

        public void setIme(string ime)
        {
            this.ime = ime;
        }
        public string getIme() 
        {
          return this.ime;
        }
        public string Prezime { get; set; }
        public Osoba() { }
    }
}
