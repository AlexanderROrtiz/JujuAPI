using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AccesoDatos.Entity
{
    public class PostEntity
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }

        [StringLength(97, ErrorMessage = "{0}El body debe tener entre {2} y {1}", MinimumLength = 20)]
        public string Body { get; set; }
        public int Type { get; set; }
        public string Category { get; set; }
        public int CustomerId { get; set; }

       
    }
}
