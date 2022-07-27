using OrmPerformance.Models.EntityFramework;
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
            var order = _entityFrameworkRepositories.GetExtended(phrase);

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
            var order = _entityFrameworkRepositories.GetWithJoin(id);

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
                CustomerContactName = order.Customer?.ContactName,
                CustomerContactTitle = order.Customer?.ContactTitle,
                CustomerAddress = order.Customer?.Address,
                CustomerCity = order.Customer?.City,
                CustomerRegion = order.Customer?.Region,
                CustomerPostalCode = order.Customer?.PostalCode,
                CustomerCountry = order.Customer?.Country,
                CustomerPhone = order.Customer?.Phone,
                CustomerFax = order.Customer?.Fax,
                EmployeeLastName = order.Employee?.LastName,
                EmployeeFirstName = order.Employee?.FirstName,
                EmployeeTitle = order.Employee?.Title,
                EmployeeTitleOfCourtesy = order.Employee?.TitleOfCourtesy,
                EmployeeAddress = order.Employee?.Address,
                EmployeeCity = order.Employee?.City,
                EmployeeRegion = order.Employee?.Region,
                EmployeePostalCode = order.Employee?.PostalCode,
                EmployeeCountry = order.Employee?.Country,
                EmployeeHomePhone = order.Employee?.HomePhone,
                EmployeeExtension = order.Employee?.Extension,
                ShipViaNavigationPhone = order.ShipViaNavigation?.Phone,
            };
        }

        public OrderGetExtended GetWithJoinExtended(string phrase)
        {
            var order = _entityFrameworkRepositories.GetWithJoinExtended(phrase);

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
                CustomerContactName = order.Customer?.ContactName,
                CustomerContactTitle = order.Customer?.ContactTitle,
                CustomerAddress = order.Customer?.Address,
                CustomerCity = order.Customer?.City,
                CustomerRegion = order.Customer?.Region,
                CustomerPostalCode = order.Customer?.PostalCode,
                CustomerCountry = order.Customer?.Country,
                CustomerPhone = order.Customer?.Phone,
                CustomerFax = order.Customer?.Fax,
                EmployeeLastName = order.Employee?.LastName,
                EmployeeFirstName = order.Employee?.FirstName,
                EmployeeTitle = order.Employee?.Title,
                EmployeeTitleOfCourtesy = order.Employee?.TitleOfCourtesy,
                EmployeeAddress = order.Employee?.Address,
                EmployeeCity = order.Employee?.City,
                EmployeeRegion = order.Employee?.Region,
                EmployeePostalCode = order.Employee?.PostalCode,
                EmployeeCountry = order.Employee?.Country,
                EmployeeHomePhone = order.Employee?.HomePhone,
                EmployeeExtension = order.Employee?.Extension,
                ShipViaNavigationPhone = order.ShipViaNavigation?.Phone,
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

            return _entityFrameworkRepositories.Create(order);
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

            _entityFrameworkRepositories.Update(order);
        }

        public bool Delete(int id)
        {
            return _entityFrameworkRepositories.Delete(id);
        }
    }
}
