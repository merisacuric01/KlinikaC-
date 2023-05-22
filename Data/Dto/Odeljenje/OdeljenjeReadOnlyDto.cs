using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace klinika.Data.Dto.Odeljenje
{
    public class OdeljenjeReadOnlyDto
    {
        public int OdeljenjeID { get; set; }
        public string Naziv { get; set; }
    }
}