using OrmPerformance.Models.EntityFramework;

namespace OrmPerformance.Repositories.Dapper
{
    public interface IDapperRepositories
    {
        Order Get(int id);
    }
}
