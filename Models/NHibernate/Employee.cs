using FluentNHibernate.Mapping;

namespace OrmPerformance.Models.NHibernate
{
    public class Employee
    {
        public virtual string LastName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string Title { get; set; }
        public virtual string TitleOfCourtesy { get; set; }
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string Region { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string Country { get; set; }
        public virtual string HomePhone { get; set; }
        public virtual string Extension { get; set; }
    }

    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {

            Map(x => x.LastName)
                .Nullable();

            Map(x => x.FirstName)
              .Nullable();

            Map(x => x.Title)
               .Nullable();

            Map(x => x.TitleOfCourtesy)
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

            Map(x => x.HomePhone)
              .Nullable();

            Map(x => x.Extension)
              .Nullable();

            //Property(b => b.LastName, x =>
            //{
            //    x.Length(40);
            //    x.Type(NHibernateUtil.StringClob);
            //    x.NotNullable(false);
            //});

            //Property(b => b.FirstName, x =>
            //{
            //    x.Length(40);
            //    x.Type(NHibernateUtil.StringClob);
            //    x.NotNullable(false);
            //});

            //Property(b => b.Title, x =>
            //{
            //    x.Length(60);
            //    x.Type(NHibernateUtil.StringClob);
            //    x.NotNullable(false);
            //});

            //Property(b => b.TitleOfCourtesy, x =>
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

            //Property(b => b.HomePhone, x =>
            //{
            //    x.Length(40);
            //    x.Type(NHibernateUtil.StringClob);
            //    x.NotNullable(false);
            //});

            //Property(b => b.Extension, x =>
            //{
            //    x.Length(40);
            //    x.Type(NHibernateUtil.StringClob);
            //    x.NotNullable(false);
            //});

            Table("Employees");
        }
    }
}
