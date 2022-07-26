using OrmPerformance.ViewModels.Orders;

namespace OrmPerformance.Services.NHibernate
{
    public interface INHibernateService
    {
        OrderGet Get(int id);
        OrderGet GetExtended(string phrase);
        OrderGetExtended GetWithJoin(int id);
        OrderGetExtended GetWithJoinExtended(string phrase);
        int Create(OrderCreate create);
        void Update(OrderUpdate update);
        bool Delete(int id);
    }
}
