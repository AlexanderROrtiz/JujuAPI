using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Entity
{
    public class CustomerEntity
    {
        [Key]
        public int CustomerId { get; set; }
        [StringLength(15, ErrorMessage ="{0}El nombre debe tener entre {2} y {1}", MinimumLength = 4)]
        public string Name { get; set; }
    }
}
