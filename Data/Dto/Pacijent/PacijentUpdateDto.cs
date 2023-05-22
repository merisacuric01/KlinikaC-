using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace klinika.Data.Dto.Pacijent
{
    public class PacijentUpdateDto
    {
       public int PacijentID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Istorija { get; set; }
    }
}