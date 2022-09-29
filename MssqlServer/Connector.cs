using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace MssqlServer
{
    public class Connector : IConnector
    {
        private readonly ILogger<Connector> _logger;

        public Connector(ILogger<Connector> logger)
        {
            _logger = logger;
        }

        public SqlConnection GetConnection(string connectionString)
        {
            _logger.LogInformation("{class}.GetConnection Generating connection", ToString());

            SqlConnection sqlConnection = new();

            sqlConnection.ConnectionString = connectionString;

            return sqlConnection;
        }
    }
}