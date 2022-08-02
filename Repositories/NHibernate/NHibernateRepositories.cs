using NHibernate;
using NHibernate.Linq;
using OrmPerformance.Extension.NHibernate;
using OrmPerformance.Models.NHibernate;
using ISession = NHibernate.ISession;


namespace OrmPerformance.Repositories.NHibernate
{
    public class NHibernateRepositories : INHibernateRepositories
    {
        //private readonly ISession _session;
        //private ITransaction _transaction;

        //public NHibernateRepositories(ISession session)
        //{
        //    _session = session;
        //}

        //public IQueryable<Order> Orders => _session.Query<Order>();

        //public void BeginTransaction()
        //{
        //    _transaction = _session.BeginTransaction();
        //}

        //public async Task Commit()
        //{
        //    await _transaction.CommitAsync();
        //}

        //public async Task Rollback()
        //{
        //    await _transaction.RollbackAsync();
        //}

        //public void CloseTransaction()
        //{
        //    if (_transaction != null)
        //    {
        //        _transaction.Dispose();
        //        _transaction = null;
        //    }
        //}

        //public async Task Save(Order entity)
        //{
        //    await _session.SaveOrUpdateAsync(entity);
        //}

        //public async Task Delete(Order entity)
        //{
        //    await _session.DeleteAsync(entity);
        //}


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

        //public int Create(Order order)
        //{
        //    _session.Save(order);
        //    return order.OrderID;
        //}

        //public void Update(Order order)
        //{
        //    _session.Update(order);
        //}

        //public bool Delete(int id)
        //{
        //    var item = _session.Get<Order>(id);
        //    if (item != null)
        //    {
        //        _session.DeleteAsync(item);

        //        return true;
        //    }

        //    return false;
        //}
    }
}
