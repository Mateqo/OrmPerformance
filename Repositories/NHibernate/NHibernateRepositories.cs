using NHibernate;
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
    }
}
