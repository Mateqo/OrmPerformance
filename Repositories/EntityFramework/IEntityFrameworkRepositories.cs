using OrmPerformance.Models.EntityFramework;

namespace OrmPerformance.Repositories.EntityFramework
{
    public interface IEntityFrameworkRepositories
    {
        Order Get(int id);
        Order GetExtended(string phrase);
        Order GetWithJoin(int id);
        Order GetWithJoinExtended(string phrase);
        int Create(Order order);
        void Update(Order order);
        bool Delete(int id);
    }
}
