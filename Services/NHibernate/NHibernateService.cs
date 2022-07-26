using OrmPerformance.Models.NHibernate;
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
            var order = _nHibernateRepositories.GetExtended(phrase);

            return new OrderGet()
            {
                Id = order.OrderID,
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
            var order = _nHibernateRepositories.GetWithJoin(id);

            return new OrderGetExtended()
            {
                Id = order.OrderID,
                ShipName = order.ShipName,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipRegion = order.ShipRegion,
                ShipPostalCode = order.ShipPostalCode,
                ShipCountry = order.ShipCountry,
                CustomerContactName = order.Customer.ContactName,
                CustomerContactTitle = order.Customer.ContactTitle,
                CustomerAddress = order.Customer.Address,
                CustomerCity = order.Customer.City,
                CustomerRegion = order.Customer.Region,
                CustomerPostalCode = order.Customer.PostalCode,
                CustomerCountry = order.Customer.Country,
                CustomerPhone = order.Customer.Phone,
                CustomerFax = order.Customer.Fax,
                EmployeeLastName = order.Employee.LastName,
                EmployeeFirstName = order.Employee.FirstName,
                EmployeeTitle = order.Employee.Title,
                EmployeeTitleOfCourtesy = order.Employee.TitleOfCourtesy,
                EmployeeAddress = order.Employee.Address,
                EmployeeCity = order.Employee.City,
                EmployeeRegion = order.Employee.Region,
                EmployeePostalCode = order.Employee.PostalCode,
                EmployeeCountry = order.Employee.Country,
                EmployeeHomePhone = order.Employee.HomePhone,
                EmployeeExtension = order.Employee.Extension,
                ShipViaNavigationPhone = order.Shipper.Phone,
            };
        }

        public OrderGetExtended GetWithJoinExtended(string phrase)
        {
            var order = _nHibernateRepositories.GetWithJoinExtended(phrase);

            return new OrderGetExtended()
            {
                Id = order.OrderID,
                ShipName = order.ShipName,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipRegion = order.ShipRegion,
                ShipPostalCode = order.ShipPostalCode,
                ShipCountry = order.ShipCountry,
                CustomerContactName = order.Customer.ContactName,
                CustomerContactTitle = order.Customer.ContactTitle,
                CustomerAddress = order.Customer.Address,
                CustomerCity = order.Customer.City,
                CustomerRegion = order.Customer.Region,
                CustomerPostalCode = order.Customer.PostalCode,
                CustomerCountry = order.Customer.Country,
                CustomerPhone = order.Customer.Phone,
                CustomerFax = order.Customer.Fax,
                EmployeeLastName = order.Employee.LastName,
                EmployeeFirstName = order.Employee.FirstName,
                EmployeeTitle = order.Employee.Title,
                EmployeeTitleOfCourtesy = order.Employee.TitleOfCourtesy,
                EmployeeAddress = order.Employee.Address,
                EmployeeCity = order.Employee.City,
                EmployeeRegion = order.Employee.Region,
                EmployeePostalCode = order.Employee.PostalCode,
                EmployeeCountry = order.Employee.Country,
                EmployeeHomePhone = order.Employee.HomePhone,
                EmployeeExtension = order.Employee.Extension,
                ShipViaNavigationPhone = order.Shipper.Phone,
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

            return _nHibernateRepositories.Create(order);
        }

        public void Update(OrderUpdate update)
        {
            var order = new Order()
            {
                OrderID = update.Id,
                ShipName = update.ShipName,
                ShipAddress = update.ShipAddress,
                ShipCity = update.ShipCity,
                ShipRegion = update.ShipRegion,
                ShipPostalCode = update.ShipPostalCode,
                ShipCountry = update.ShipCountry,
            };

            _nHibernateRepositories.Update(order);
        }

        public bool Delete(int id)
        {
            return _nHibernateRepositories.Delete(id);
        }
    }
}
