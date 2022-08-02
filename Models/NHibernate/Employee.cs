using FluentNHibernate.Mapping;

namespace OrmPerformance.Models.NHibernate
{
    public class Employee
    {
        public virtual int EmployeeID { get; set; }
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
        public virtual IList<Order> Orders { get; set; }
    }

    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Id(x => x.EmployeeID);

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

            HasMany(x => x.Orders).KeyColumn("EmployeeID").Inverse().Cascade.All();

            Table("Employees");
        }
    }
}
