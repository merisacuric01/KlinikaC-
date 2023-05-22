using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace klinika.Data.Dto.Odeljenje
{
    public class OdeljenjeCreateDto
    {
        [Required]
        [StringLength(50)]
        public string Naziv { get; set; }
      
    }
}