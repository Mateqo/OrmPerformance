using OrmPerformance.Models.NHibernate;

namespace OrmPerformance.Repositories.NHibernate
{
    public interface INHibernateRepositories
    {
        Order Get(int id);
        Order GetExtended(string phrase);
        Order GetWithJoin(int id);
        Order GetWithJoinExtended(string phrase);
        //int Create(Order order);
        //void Update(Order order);
        //bool Delete(int id);
    }
}
