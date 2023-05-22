using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace klinika.models
{
    public class Odeljenje
    {
        public int OdeljenjeID { get; set; }
        public string Naziv { get; set; } = string.Empty;
    }
}