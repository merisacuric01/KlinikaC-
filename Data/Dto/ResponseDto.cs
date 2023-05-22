using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace klinika.Data.Dto
{
    public class ResponseDto
    {
        public Object Data { get; set; }
        public bool Success { get; set; } = true;
        public string DisplayMessage { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}