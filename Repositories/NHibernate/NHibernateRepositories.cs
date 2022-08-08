using OrmPerformance.Extension.NHibernate;
using OrmPerformance.Models.NHibernate;
using OrmPerformance.ViewModels.Orders;

namespace OrmPerformance.Repositories.NHibernate
{
    public class NHibernateRepositories : INHibernateRepositories
    {
        public Order Get(int id)
        {
            var session = NHibernateExtension.OpenSession();
            return session.Get<Order>(id);
        }

        public Order GetExtended(string phrase)
        {
            var session = NHibernateExtension.OpenSession();

            return session.Query<Order>().FirstOrDefault(x =>
                    x.ShipName.Contains(phrase) ||
                    x.ShipAddress.Contains(phrase) ||
                    x.ShipCity.Contains(phrase) ||
                    x.ShipRegion.Contains(phrase) ||
                    x.ShipPostalCode.Contains(phrase) ||
                    x.ShipCountry.Contains(phrase));
        }

        public Order GetWithJoin(int id)
        {
            var session = NHibernateExtension.OpenSession();
            return session.Get<Order>(id);

        }

        public Order GetWithJoinExtended(string phrase)
        {
            var session = NHibernateExtension.OpenSession();
            return session.Query<Order>().FirstOrDefault(x =>
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
                        x.Shipper.Phone.Contains(phrase));
        }

        public int Create(Order order)
        {
            var session = NHibernateExtension.OpenSession();
            session.Save(order);
            return order.OrderID;
        }

        public void Update(OrderUpdate order)
        {
            var session = NHibernateExtension.OpenSession();
            var item = session.Get<Order>(order.Id);

            item.ShipCity = order?.ShipCity;
            item.ShipRegion = order?.ShipRegion;
            item.ShipPostalCode = order?.ShipPostalCode;
            item.ShipCountry = order?.ShipCountry;
            item.ShipName = order?.ShipName;
            item.ShipAddress = order?.ShipAddress;

            session.SaveOrUpdate(item);
            session.Flush();
        }

        public bool Delete(int id)
        {
            var session = NHibernateExtension.OpenSession();
            var item = session.Get<Order>(id);
            if (item != null)
            {
                session.Delete(item);
                session.Flush();

                return true;
            }

            return false;
        }

    }
}
