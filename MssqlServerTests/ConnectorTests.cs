using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MssqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace MssqlServer.Tests
{
    [TestClass()]
    public class ConnectorTests
    {
        private string connectionString = "Server=localhost;Database=schema;User ID=sa;Password=password;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";

        [TestMethod()]
        public void GetConnectionTest()
        {
            var connector = new Mock<IConnector>();
            connector.Setup(x => x.GetConnection(connectionString)).Returns(new SqlConnection());
        }
    }
}