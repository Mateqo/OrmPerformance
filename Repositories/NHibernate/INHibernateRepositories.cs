using OrmPerformance.Models.NHibernate;

namespace OrmPerformance.Repositories.NHibernate
{
    public interface INHibernateRepositories
    {
        void BeginTransaction();
        Task Commit();
        Task Rollback();
        void CloseTransaction();
        Task Save(Order entity);
        Task Delete(Order entity);

        IQueryable<Order> Orders { get; }
        Order Get(int id);
    }
}
