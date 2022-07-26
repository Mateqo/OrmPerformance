using NHibernate;
using NHibernate.Linq;
using OrmPerformance.Models.NHibernate;
using ISession = NHibernate.ISession;


namespace OrmPerformance.Repositories.NHibernate
{
    public class NHibernateRepositories : INHibernateRepositories
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        public NHibernateRepositories(ISession session)
        {
            _session = session;
        }

        public IQueryable<Order> Orders => _session.Query<Order>();

        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }

        public void CloseTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task Save(Order entity)
        {
            await _session.SaveOrUpdateAsync(entity);
        }

        public async Task Delete(Order entity)
        {
            await _session.DeleteAsync(entity);
        }


        public Order Get(int id)
        {
            return _session.Get<Order>(id);
        }

        public Order GetExtended(string phrase)
        {
            return _session.Query<Order>().FirstOrDefault(x =>
                    x.ShipName.Like(phrase) ||
                    x.ShipAddress.Like(phrase) ||
                    x.ShipCity.Like(phrase) ||
                    x.ShipRegion.Like(phrase) ||
                    x.ShipPostalCode.Like(phrase) ||
                    x.ShipCountry.Like(phrase));
        }

        public Order GetWithJoin(int id)
        {
            return _session.Get<Order>(id);
        }

        public Order GetWithJoinExtended(string phrase)
        {
            return _session.Query<Order>().FirstOrDefault(x =>
                        x.ShipName.Like(phrase) ||
                        x.ShipAddress.Like(phrase) ||
                        x.ShipCity.Like(phrase) ||
                        x.ShipRegion.Like(phrase) ||
                        x.ShipPostalCode.Like(phrase) ||
                        x.ShipCountry.Like(phrase) ||
                        x.Customer.ContactName.Like(phrase) ||
                        x.Customer.ContactTitle.Like(phrase) ||
                        x.Customer.Address.Like(phrase) ||
                        x.Customer.City.Like(phrase) ||
                        x.Customer.Region.Like(phrase) ||
                        x.Customer.PostalCode.Like(phrase) ||
                        x.Customer.Country.Like(phrase) ||
                        x.Customer.Phone.Like(phrase) ||
                        x.Customer.Fax.Like(phrase) ||
                        x.Employee.LastName.Like(phrase) ||
                        x.Employee.FirstName.Like(phrase) ||
                        x.Employee.Title.Like(phrase) ||
                        x.Employee.TitleOfCourtesy.Like(phrase) ||
                        x.Employee.Address.Like(phrase) ||
                        x.Employee.City.Like(phrase) ||
                        x.Employee.Region.Like(phrase) ||
                        x.Employee.PostalCode.Like(phrase) ||
                        x.Employee.Country.Like(phrase) ||
                        x.Employee.HomePhone.Like(phrase) ||
                        x.Employee.Extension.Like(phrase) ||
                        x.Shipper.Phone.Like(phrase));
        }

        public int Create(Order order)
        {
            _session.Save(order);
            return order.OrderID;
        }

        public void Update(Order order)
        {
            _session.Update(order);
        }

        public bool Delete(int id)
        {
            var item = _session.Get<Order>(id);
            if (item != null)
            {
                _session.DeleteAsync(item);

                return true;
            }

            return false;
        }
    }
}
