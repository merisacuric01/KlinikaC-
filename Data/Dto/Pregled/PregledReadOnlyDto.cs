using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using klinika.Data.Dto.Doktor;
using klinika.Data.Dto.Pacijent;
using klinika.models;

namespace klinika.Data.Dto.Pregled
{
    public class PregledReadOnlyDto
    {
        public DateTime Datum { get; set; } = DateTime.Now;
        public StatusPregleda StatusPregleda { get; set; } = StatusPregleda.Zakazan;  
        public string Dijagnoza { get; set; } = string.Empty;
        public decimal CenaPregleda { get; set; }
        public PacijentReadOnlyDto Pacijent { get; set; }  
        public DoktorReadOnlyDto Doktor { get; set; } 
    }
}