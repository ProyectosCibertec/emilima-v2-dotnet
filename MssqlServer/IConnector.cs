using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MssqlServer
{
    public interface IConnector
    {
        public SqlConnection GetConnection(String connectionString);
    }
}
