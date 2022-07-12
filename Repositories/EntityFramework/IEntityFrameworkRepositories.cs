using OrmPerformance.Models.EntityFramework;

namespace OrmPerformance.Repositories.EntityFramework
{
    public interface IEntityFrameworkRepositories
    {
        Order Get(int id);
    }
}
