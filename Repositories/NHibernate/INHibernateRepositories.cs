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
        Order GetExtended(string phrase);
        Order GetWithJoin(int id);
        Order GetWithJoinExtended(string phrase);
        int Create(Order order);
        void Update(Order order);
        bool Delete(int id);
    }
}
