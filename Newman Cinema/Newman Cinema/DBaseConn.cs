using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newman_Cinema
{
    public class DBaseConn
    {
        private static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CustomerDatabase.accdb;Jet OLEDB:Database Password=cinema";

        public static string ConnectionString
        { get
            {
                return connectionString;
            }

            set
            {
                connectionString = value;
            }
        }
    }
}
