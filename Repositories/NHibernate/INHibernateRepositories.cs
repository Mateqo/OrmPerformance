using OrmPerformance.Models.NHibernate;
using OrmPerformance.ViewModels.Orders;

namespace OrmPerformance.Repositories.NHibernate
{
    public interface INHibernateRepositories
    {
        Order Get(int id);
        Order GetExtended(string phrase);
        Order GetWithJoin(int id);
        Order GetWithJoinExtended(string phrase);
        int Create(Order order);
        void Update(OrderUpdate order);
        bool Delete(int id);
    }
}
