using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace klinika.models
{
    public class Pacijent
    {
        public int PacijentID { get; set; }
        public string Ime { get; set; } = string.Empty;
        public string Prezime { get; set; } = string.Empty;
        public string Istorija { get; set; } = string.Empty;
    }
}