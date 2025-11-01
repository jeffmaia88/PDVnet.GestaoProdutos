using Microsoft.Data.SqlClient;
using System.Configuration;


namespace PDVnet.GestaoProdutos.Data
{
    public static class ConnectionHelper
    {
        public static SqlConnection GetConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["PDVnetConnection"].ConnectionString;
            return new SqlConnection(connectionString);
        }
    }
}
