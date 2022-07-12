using OrmPerformance.Models.EntityFramework;

namespace OrmPerformance.Repositories.EntityFramework
{
    public class EntityFrameworkRepositories : IEntityFrameworkRepositories
    {
        private readonly NorthwindContext _context;

        public EntityFrameworkRepositories(NorthwindContext context)
        {
            _context = context;
        }

        public Order Get(int id)
        {
            return _context.Orders.FirstOrDefault(x => x.OrderId == id);
        }
    }
}
