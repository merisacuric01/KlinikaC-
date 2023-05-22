using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using klinika.Data.Dto.Odeljenje;

namespace klinika.Data.Dto.Doktor
{
    public class DoktorReadOnlyDto
    {
        public int DoktorID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Kontact { get; set; }
        public OdeljenjeReadOnlyDto Odeljenje { get; set; }
    }
}