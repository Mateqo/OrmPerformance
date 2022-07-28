using OrmPerformance.Models.Dapper;
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

            if (order == null)
                return null;

            return new OrderGet()
            {
                Id = order.OrderId,
                ShipName = order.ShipName,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipRegion = order.ShipRegion,
                ShipPostalCode = order.ShipPostalCode,
                ShipCountry = order.ShipCountry,
            };
        }

        public OrderGet GetExtended(string phrase)
        {
            var order = _dapperRepositories.GetExtended(phrase);

            if (order == null)
                return null;

            return new OrderGet()
            {
                Id = order.OrderId,
                ShipName = order.ShipName,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipRegion = order.ShipRegion,
                ShipPostalCode = order.ShipPostalCode,
                ShipCountry = order.ShipCountry,
            };
        }

        public OrderGetExtended GetWithJoin(int id)
        {
            var order = _dapperRepositories.GetWithJoin(id);

            if (order == null)
                return null;

            return new OrderGetExtended()
            {
                Id = order.OrderId,
                ShipName = order.ShipName,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipRegion = order.ShipRegion,
                ShipPostalCode = order.ShipPostalCode,
                ShipCountry = order.ShipCountry,
                CustomerContactName = order.CustomerContactName,
                CustomerContactTitle = order.CustomerContactTitle,
                CustomerAddress = order.CustomerAddress,
                CustomerCity = order.CustomerCity,
                CustomerRegion = order.CustomerRegion,
                CustomerPostalCode = order.CustomerPostalCode,
                CustomerCountry = order.CustomerCountry,
                CustomerPhone = order.CustomerPhone,
                CustomerFax = order.CustomerFax,
                EmployeeLastName = order.EmployeeLastName,
                EmployeeFirstName = order.EmployeeFirstName,
                EmployeeTitle = order.EmployeeTitle,
                EmployeeTitleOfCourtesy = order.EmployeeTitleOfCourtesy,
                EmployeeAddress = order.EmployeeAddress,
                EmployeeCity = order.EmployeeCity,
                EmployeeRegion = order.EmployeeRegion,
                EmployeePostalCode = order.EmployeePostalCode,
                EmployeeCountry = order.EmployeeCountry,
                EmployeeHomePhone = order.EmployeeHomePhone,
                EmployeeExtension = order.EmployeeExtension,
                ShipViaNavigationPhone = order.ShipViaNavigationPhone,
            };
        }

        public OrderGetExtended GetWithJoinExtended(string phrase)
        {
            var order = _dapperRepositories.GetWithJoinExtended(phrase);

            if (order == null)
                return null;

            return new OrderGetExtended()
            {
                Id = order.OrderId,
                ShipName = order.ShipName,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipRegion = order.ShipRegion,
                ShipPostalCode = order.ShipPostalCode,
                ShipCountry = order.ShipCountry,
                CustomerContactName = order.CustomerContactName,
                CustomerContactTitle = order.CustomerContactTitle,
                CustomerAddress = order.CustomerAddress,
                CustomerCity = order.CustomerCity,
                CustomerRegion = order.CustomerRegion,
                CustomerPostalCode = order.CustomerPostalCode,
                CustomerCountry = order.CustomerCountry,
                CustomerPhone = order.CustomerPhone,
                CustomerFax = order.CustomerFax,
                EmployeeLastName = order.EmployeeLastName,
                EmployeeFirstName = order.EmployeeFirstName,
                EmployeeTitle = order.EmployeeTitle,
                EmployeeTitleOfCourtesy = order.EmployeeTitleOfCourtesy,
                EmployeeAddress = order.EmployeeAddress,
                EmployeeCity = order.EmployeeCity,
                EmployeeRegion = order.EmployeeRegion,
                EmployeePostalCode = order.EmployeePostalCode,
                EmployeeCountry = order.EmployeeCountry,
                EmployeeHomePhone = order.EmployeeHomePhone,
                EmployeeExtension = order.EmployeeExtension,
                ShipViaNavigationPhone = order.ShipViaNavigationPhone,
            };
        }


        public int Create(OrderCreate create)
        {
            var order = new Order()
            {
                ShipName = create.ShipName,
                ShipAddress = create.ShipAddress,
                ShipCity = create.ShipCity,
                ShipRegion = create.ShipRegion,
                ShipPostalCode = create.ShipPostalCode,
                ShipCountry = create.ShipCountry,
            };

            return _dapperRepositories.Create(order);
        }

        public void Update(OrderUpdate update)
        {
            var order = new Order()
            {
                OrderId = update.Id,
                ShipName = update.ShipName,
                ShipAddress = update.ShipAddress,
                ShipCity = update.ShipCity,
                ShipRegion = update.ShipRegion,
                ShipPostalCode = update.ShipPostalCode,
                ShipCountry = update.ShipCountry,
            };

            _dapperRepositories.Update(order);
        }

        public bool Delete(int id)
        {
            return _dapperRepositories.Delete(id);
        }
    }
}
