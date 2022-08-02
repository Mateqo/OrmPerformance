using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;

namespace OrmPerformance.Models.NHibernate
{
    public class Customer
    {
        public virtual string CustomerID { get; set; }

        public virtual string ContactName { get; set; }
        public virtual string ContactTitle { get; set; }
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string Region { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string Country { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
        public virtual IList<Order> Orders { get; set; }
    }

    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.CustomerID);

            Map(x => x.ContactName)
                .Nullable();

            Map(x => x.ContactTitle)
              .Nullable();

            Map(x => x.Address)
               .Nullable();

            Map(x => x.City)
              .Nullable();

            Map(x => x.Region)
              .Nullable();

            Map(x => x.PostalCode)
             .Nullable();

            Map(x => x.Country)
              .Nullable();

            Map(x => x.Phone)
              .Nullable();

            Map(x => x.Fax)
             .Nullable();

            HasMany(x => x.Orders).KeyColumn("CustomerID").Inverse().Cascade.All();       

            Table("Customers");
        }
    }
}
