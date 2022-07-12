using OrmPerformance.ViewModels.Orders;

namespace OrmPerformance.Services.Dapper
{
    public interface IDapperService
    {
        OrderGet Get(int id);
    }
}
