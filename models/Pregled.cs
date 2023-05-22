using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace klinika.models
{
    public class Pregled
    {
        public int PregledID { get; set; }
        public DateTime Datum { get; set; } = DateTime.Now;
        public StatusPregleda StatusPregleda { get; set; } = StatusPregleda.Zakazan;
        public int DoktorID { get; set; }
        public Doktor Doktor { get; set; }
        public string Dijagnoza { get; set; } = string.Empty;

        public int PacijentID { get; set; }
        public Pacijent Pacijent { get; set; }
        [Precision(5,2)]
        public decimal CenaPregleda { get; set; }

        

    }

    public enum StatusPregleda 
    {
        Zakazan,
        Obavljen,
        Otkazan,

    }
}