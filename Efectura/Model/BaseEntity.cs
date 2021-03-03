using Efectura.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Efectura.Model
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreationDate = DateTime.Now;
            string tc = TCKNService.TcknGenerator();
            if (TCKNService.TcknDogrula(tc))
            {
                TCKN = tc;
            }

        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [MinLength(11)]
        [MaxLength(11)]
        public string TCKN { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public DateTime LastModified { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
