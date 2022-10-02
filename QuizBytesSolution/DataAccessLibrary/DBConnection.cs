using System.Configuration;
using System.Data.SqlClient;

namespace DataAccessLibrary
{
    public static class SQLConnectionFactory
    {
        private static string connectionstring = GetConnectionStringByName("ConnectionString");
        private static SqlConnection connection;

        private static void InitializeConnection()
        {
            try
            {
                connection = new SqlConnection(connectionstring);
            }
            catch (SqlException e)
            {
                Console.WriteLine("Problems with the connection to the database:");
                Console.WriteLine(e.Message);
                Console.WriteLine(connectionstring);
            }
        }
        public static SqlConnection GetSqlConnection()
        {
            InitializeConnection();
            return connection;
        }

        private static string GetConnectionStringByName(string name)
        {
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings[name];

            // If found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }
    }
}