using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DXApplication1
{
    class Connect
    {
        public static SqlConnection GetDBConnection()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-PC1IU8F\\SQLEXPRESS;Initial Catalog=TKB;Integrated Security=SSPI;");
            return conn;
        }
    }
}
