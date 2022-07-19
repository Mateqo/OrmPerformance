using Microsoft.EntityFrameworkCore;
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
            return _context.Orders
                .FirstOrDefault(x => x.OrderId == id);
        }

        public Order GetExtended(string phrase)
        {
            return _context.Orders.FirstOrDefault(x => 
            x.ShipName.Contains(phrase) ||
            x.ShipAddress.Contains(phrase) ||
            x.ShipCity.Contains(phrase) ||
            x.ShipRegion.Contains(phrase) ||
            x.ShipPostalCode.Contains(phrase) ||
            x.ShipCountry.Contains(phrase) 
            );
        }

        public Order GetWithJoin(int id)
        {
            return _context.Orders
                .Include(x=>x.Customer)
                .Include(x=>x.Employee)
                .Include(x=>x.ShipViaNavigation)
                .FirstOrDefault(x =>x.OrderId == id);
        }

        public Order GetWithJoinExtended(string phrase)
        {
            return _context.Orders
                .Include(x => x.Customer)
                .Include(x => x.Employee)
                .Include(x => x.ShipViaNavigation)
                .FirstOrDefault(x =>
                    x.ShipName.Contains(phrase) ||
                    x.ShipAddress.Contains(phrase) ||
                    x.ShipCity.Contains(phrase) ||
                    x.ShipRegion.Contains(phrase) ||
                    x.ShipPostalCode.Contains(phrase) ||
                    x.ShipCountry.Contains(phrase) ||
                    x.Customer.ContactName.Contains(phrase) ||
                    x.Customer.ContactTitle.Contains(phrase) ||
                    x.Customer.Address.Contains(phrase) ||
                    x.Customer.City.Contains(phrase) ||
                    x.Customer.Region.Contains(phrase) ||
                    x.Customer.PostalCode.Contains(phrase) ||
                    x.Customer.Country.Contains(phrase) ||
                    x.Customer.Phone.Contains(phrase) ||
                    x.Customer.Fax.Contains(phrase) ||
                    x.Employee.LastName.Contains(phrase) ||
                    x.Employee.FirstName.Contains(phrase) ||
                    x.Employee.Title.Contains(phrase) ||
                    x.Employee.TitleOfCourtesy.Contains(phrase) ||
                    x.Employee.Address.Contains(phrase) ||
                    x.Employee.City.Contains(phrase) ||
                    x.Employee.Region.Contains(phrase) ||
                    x.Employee.PostalCode.Contains(phrase) ||
                    x.Employee.Country.Contains(phrase) ||
                    x.Employee.HomePhone.Contains(phrase) ||
                    x.Employee.Extension.Contains(phrase) ||
                    x.ShipViaNavigation.Phone.Contains(phrase));
        }


        public int Create(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();

            return order.OrderId;
        }

        public void Update(Order order)
        {
            _context.Attach(order);
            _context.Entry(order).Property("ShipName").IsModified = true;
            _context.Entry(order).Property("ShipAddress").IsModified = true;
            _context.Entry(order).Property("ShipCity").IsModified = true;
            _context.Entry(order).Property("ShipRegion").IsModified = true;
            _context.Entry(order).Property("ShipPostalCode").IsModified = true;
            _context.Entry(order).Property("ShipCountry").IsModified = true;
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var item = _context.Orders.Find(id);
            if (item != null)
            {
                _context.Orders.Remove(item);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
