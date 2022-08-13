using AccesoDatos.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class DataContext: DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public  DbSet<CustomerEntity> Customer { get; set; }
        public  DbSet<LogsEntity> Logs { get; set; }
        public  DbSet<PostEntity> Post { get; set; }
    }
}
