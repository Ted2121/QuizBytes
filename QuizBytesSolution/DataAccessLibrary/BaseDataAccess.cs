using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLAccessImplementationLibrary
{
    public abstract class BaseDataAccess
    {
        private string _connectionstring;

        protected BaseDataAccess(string connectionstring) => _connectionstring = connectionstring;

        protected SqlConnection CreateConnection() => new SqlConnection(_connectionstring);
    }
}
