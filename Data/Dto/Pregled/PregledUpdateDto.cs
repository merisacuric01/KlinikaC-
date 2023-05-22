using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using klinika.models;

namespace klinika.Data.Dto.Pregled
{
    public class PregledUpdateDto
    {
        [Required]
        public DateTime Datum { get; set; } = DateTime.Now;
        [Required]
        public StatusPregleda StatusPregleda { get; set; } = StatusPregleda.Zakazan;  
        [Required]
        [StringLength(50)]
        public string Dijagnoza { get; set; } = string.Empty;
        public decimal CenaPregleda { get; set; }
        public int PacijentID { get; set; }  
        public int DoktorID { get; set; }
        public int PregledID { get; internal set; }
    }
}