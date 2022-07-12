using OrmPerformance.ViewModels.Orders;

namespace OrmPerformance.Services.EntityFramework
{
    public interface IEntityFrameworkService
    {
        OrderGet Get(int id);
    }
}
