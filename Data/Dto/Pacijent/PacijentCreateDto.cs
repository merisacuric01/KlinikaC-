using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace klinika.Data.Dto.Pacijent
{
    public class PacijentCreateDto
    {
        [Required]
        [StringLength(50)]
        public string Ime { get; set; }
        [Required]
        [StringLength(50)]
        public string Prezime { get; set; }  
        [Required]
        [StringLength(50)]
        public string Istorija { get; set; }
       
    }
}