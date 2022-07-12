using OrmPerformance.Repositories.Dapper;
using OrmPerformance.ViewModels.Orders;

namespace OrmPerformance.Services.Dapper
{
    public class DapperService : IDapperService
    {
        private readonly IDapperRepositories _dapperRepositories;

        public DapperService(IDapperRepositories dapperRepositories)
        {
            _dapperRepositories = dapperRepositories;
        }

        public OrderGet Get(int id)
        {
            var order = _dapperRepositories.Get(id);

            return new OrderGet()
            {
                Id = order.OrderId,
                Name = order.ShipName
            };
        }
    }
}
