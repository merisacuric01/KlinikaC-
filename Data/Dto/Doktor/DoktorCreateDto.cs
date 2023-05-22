using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace klinika.Data.Dto.Doktor
{
    public class DoktorCreateDto
    {
        [Required]
        [StringLength(50)]
        public string Ime { get; set; }
        [Required]
        [StringLength(50)]
        public string Prezime { get; set; }  
        [Required]
        [StringLength(50)]
        public string Kontact { get; set; }
        public int OdeljenjeID { get; set; }
    }
}