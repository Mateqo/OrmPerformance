using Dapper;
using Microsoft.Data.SqlClient;
using OrmPerformance.Models.Dapper;
using System.Data;

namespace OrmPerformance.Repositories.Dapper
{
    public class DapperRepositories : IDapperRepositories
    {
        private IDbConnection db;

        public DapperRepositories(IConfiguration configuration)
        {
            db = new SqlConnection(configuration.GetValue<string>("Connectionstring"));
        }

        public Order Get(int id)
        {
            var sql = "SELECT * FROM Orders WHERE OrderID = @OrderId";
            return db.Query<Order>(sql, new { @OrderId = id }).Single();
        }

    }
}
