using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace klinika.Data.Dto.Doktor
{
    public class DoktorUpdateDto
    {
        public int DoktorID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Kontact { get; set; }
        public int OdeljenjeID { get; set; }
    }
}