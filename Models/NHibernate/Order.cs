using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace OrmPerformance.Models.NHibernate
{
    public class Order
    {
        public virtual int OrderID { get; set; }
        //public virtual Guid CustomerID { get; set; }
        //public virtual int EmployeeID { get; set; }
        //public virtual DateTime OrderDate { get; set; }
        //public virtual DateTime RequiredDate { get; set; }
        //public virtual DateTime ShippedDate { get; set; }
        //public virtual decimal Freight { get; set; }
        public virtual string ShipName { get; set; }
        //public virtual string ShipAddress { get; set; }
        //public virtual string ShipCity { get; set; }
        //public virtual string ShipRegion { get; set; }
        //public virtual string ShipPostalCode { get; set; }
        //public virtual string ShipCountry { get; set; }
    }

    //public class OrderMappingAlteration : IAutoMappingOverride<Order>
    //{
    //    public void Override(AutoMapping<Order> mapping)
    //    {
    //        mapping.Schema("[dbo]");
    //        mapping.Table("[Orders]");

    //        mapping.Id(m => m.OrderID).GeneratedBy.Identity();
    //    }
    //}

    public class OrderMap : ClassMapping<Order>
    {
        public OrderMap()
        {
            Id(x => x.OrderID, x =>
            {
                x.Generator(Generators.Assigned);
                x.Type(NHibernateUtil.Int32);
                x.Column("OrderID");
            });

            Property(b => b.ShipName, x =>
            {
                x.Length(40);
                x.Type(NHibernateUtil.StringClob);
                x.NotNullable(false);
            });

            Table("Orders");
        }
    }
}
