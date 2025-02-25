﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEdunova
{
    internal class Grupa : Entitet
    {
        public string Naziv { get; set; }
        public Smjer Smjer { get; set; }
        public DateTime DatumPocetka { get; set; }
        public List<Polaznik> Polaznici { get; set; }

        public string ToString()
        {
            return Naziv + " " + Smjer;
        }
    }
}

