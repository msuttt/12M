using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class ConnectionAdress
    {
        public SqlConnection con = new SqlConnection(@"Data Source= LAPTOP-MSV44HS0\MINE;Initial Catalog=12MDB;Integrated Security=True");
    }
}
