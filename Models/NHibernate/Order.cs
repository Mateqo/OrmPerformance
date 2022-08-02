using FluentNHibernate.Mapping;

namespace OrmPerformance.Models.NHibernate
{
    public class Order
    {
        public virtual int OrderID { get; set; }
        public virtual string CustomerID { get; set; }
        public virtual int EmployeeID { get; set; }
        public virtual int ShipVia { get; set; }
        public virtual string ShipName { get; set; }
        public virtual string ShipAddress { get; set; }
        public virtual string ShipCity { get; set; }
        public virtual string ShipRegion { get; set; }
        public virtual string ShipPostalCode { get; set; }
        public virtual string ShipCountry { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Shipper Shipper { get; set; }
    }

    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Table("dbo.Orders");

            Id(x => x.OrderID);

            Map(x => x.ShipName);

            Map(x => x.ShipAddress);

            Map(x => x.ShipCity);

            Map(x => x.ShipRegion);

            Map(x => x.ShipPostalCode);

            Map(x => x.ShipCountry);

            References(x => x.Customer, "CustomerID").Cascade.None();
            References(x => x.Employee, "EmployeeID").Cascade.None(); 
            References(x => x.Shipper, "ShipVia").Cascade.None();         
        }
    }
}
