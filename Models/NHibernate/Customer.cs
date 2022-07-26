using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;

namespace OrmPerformance.Models.NHibernate
{
    public class Customer
    {
        public virtual string ContactName { get; set; }
        public virtual string ContactTitle { get; set; }
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string Region { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string Country { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
    }

    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {

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

            //Property(b => b.ContactName, x =>
            //{
            //    x.Length(40);
            //    x.Type(NHibernateUtil.StringClob);
            //    x.NotNullable(false);
            //});

            //Property(b => b.ContactTitle, x =>
            //{
            //    x.Length(40);
            //    x.Type(NHibernateUtil.StringClob);
            //    x.NotNullable(false);
            //});

            //Property(b => b.Address, x =>
            //{
            //    x.Length(60);
            //    x.Type(NHibernateUtil.StringClob);
            //    x.NotNullable(false);
            //});

            //Property(b => b.City, x =>
            //{
            //    x.Length(40);
            //    x.Type(NHibernateUtil.StringClob);
            //    x.NotNullable(false);
            //});

            //Property(b => b.Region, x =>
            //{
            //    x.Length(40);
            //    x.Type(NHibernateUtil.StringClob);
            //    x.NotNullable(false);
            //});

            //Property(b => b.PostalCode, x =>
            //{
            //    x.Length(40);
            //    x.Type(NHibernateUtil.StringClob);
            //    x.NotNullable(false);
            //});

            //Property(b => b.Country, x =>
            //{
            //    x.Length(40);
            //    x.Type(NHibernateUtil.StringClob);
            //    x.NotNullable(false);
            //});

            //Property(b => b.Phone, x =>
            //{
            //    x.Length(40);
            //    x.Type(NHibernateUtil.StringClob);
            //    x.NotNullable(false);
            //});

            //Property(b => b.Fax, x =>
            //{
            //    x.Length(40);
            //    x.Type(NHibernateUtil.StringClob);
            //    x.NotNullable(false);
            //});

            Table("Customers");
        }
    }
}
