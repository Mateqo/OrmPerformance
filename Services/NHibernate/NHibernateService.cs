using OrmPerformance.Repositories.NHibernate;
using OrmPerformance.ViewModels.Orders;

namespace OrmPerformance.Services.NHibernate
{
    public class NHibernateService : INHibernateService
    {
        private readonly INHibernateRepositories _nHibernateRepositories;

        public NHibernateService(INHibernateRepositories nHibernateRepositories)
        {
            _nHibernateRepositories = nHibernateRepositories;
        }

        public OrderGet Get(int id)
        {
            var order = _nHibernateRepositories.Get(id);

            return new OrderGet()
            {
                Id = order.OrderID,
                Name = order.ShipName
            };
        }
    }
}
