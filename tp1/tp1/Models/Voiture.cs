using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tp1.Models
{
    public class Voiture
    {
        public int NoSerie { get; set; }
        public string Sorte { get; set; }
        public int Annee { get; set; }
        public double Prix { get; set; }
    }
}