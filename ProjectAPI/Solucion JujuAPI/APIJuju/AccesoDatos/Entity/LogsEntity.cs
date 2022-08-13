using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AccesoDatos.Entity
{
    public class LogsEntity
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public string Level { get; set; }

        [DataType(DataType.Date)]
        public DateTime? TimeStamp { get; set; }
        public string Exception { get; set; }
        public string Properties { get; set; }
    }
}
