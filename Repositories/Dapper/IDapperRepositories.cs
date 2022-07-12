using OrmPerformance.Models.Dapper;

namespace OrmPerformance.Repositories.Dapper
{
    public interface IDapperRepositories
    {
        Order Get(int id);
    }
}
