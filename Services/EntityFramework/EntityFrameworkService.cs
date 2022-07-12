using OrmPerformance.Repositories.EntityFramework;
using OrmPerformance.ViewModels.Orders;

namespace OrmPerformance.Services.EntityFramework
{
    public class EntityFrameworkService : IEntityFrameworkService
    {
        private readonly IEntityFrameworkRepositories _entityFrameworkRepositories;

        public EntityFrameworkService(IEntityFrameworkRepositories entityFrameworkRepositories)
        {
            _entityFrameworkRepositories = entityFrameworkRepositories;
        }

        public OrderGet Get(int id)
        {
            var order = _entityFrameworkRepositories.Get(id);

            return new OrderGet()
            {
               Id = order.OrderId,
               Name = order.ShipName        
            };
        }
    }
}
