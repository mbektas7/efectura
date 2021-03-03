using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Efectura.DTOs
{
    public class UserDTO
    {
        [Required]
        public string name { get; set; }

        [Required]
        public string surname { get; set; }
        [Required]
        public DateTime birthday { get; set; }
        public string address { get; set; }
    }
}
