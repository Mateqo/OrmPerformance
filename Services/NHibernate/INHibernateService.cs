using OrmPerformance.ViewModels.Orders;

namespace OrmPerformance.Services.NHibernate
{
    public interface INHibernateService
    {
        OrderGet Get(int id);
    }
}
