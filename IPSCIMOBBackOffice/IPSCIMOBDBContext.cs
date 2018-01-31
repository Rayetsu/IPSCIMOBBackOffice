using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSCIMOBBackOffice
{
    class IPSCIMOBDBContext : DbContext
    {
        public IPSCIMOBDBContext() : base(@"Data Source=SQL6003.site4now.net;Initial Catalog=DB_A30AB8_ipscimob;User Id=DB_A30AB8_ipscimob_admin;Password=ips12345;")
        {

        }

        public DbSet<Sugestao> Sugestoes { get; set; }
    }
}
