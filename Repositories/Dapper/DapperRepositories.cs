using Dapper;
using Microsoft.Data.SqlClient;
using OrmPerformance.Models.Dapper;
using System.Data;

namespace OrmPerformance.Repositories.Dapper
{
    public class DapperRepositories : IDapperRepositories
    {
        private IDbConnection db;

        public DapperRepositories(IConfiguration configuration)
        {
            db = new SqlConnection(configuration.GetValue<string>("Connectionstring"));
        }


        public Order Get(int id)
        {
            var sql = $@"
                            SELECT 
                                OrderId,
                                ShipName,
                                ShipAddress,
                                ShipCity,
                                ShipRegion,
                                ShipPostalCode,
                                ShipCountry
                            FROM Orders 
                            WHERE 
                                OrderID = @OrderId";

            return db.Query<Order>(sql, new { @OrderId = id }).Single();
        }

        public Order GetExtended(string phrase)
        {
            var sql = $@"
                            SELECT 
                                OrderId,
                                ShipName,
                                ShipAddress,
                                ShipCity,
                                ShipRegion,
                                ShipPostalCode,
                                ShipCountry
                            FROM Orders 
                            WHERE 
                                ShipName LIKE '%' + @Phrase + '%' OR
                                ShipAddress LIKE '%' + @Phrase + '%' OR
                                ShipCity LIKE '%' + @Phrase + '%' OR
                                ShipRegion LIKE '%' + @Phrase + '%' OR
                                ShipPostalCode LIKE '%' + @Phrase + '%' OR
                                ShipCountry LIKE '%' + @Phrase + '%'";

            return db.Query<Order>(sql, new { @Phrase = phrase }).Single();
        }

        public Order GetWithJoin(int id)
        {
            var sql = $@"
                            SELECT 
                                O.OrderId,
                                O.ShipName,
                                O.ShipAddress,
                                O.ShipCity,
                                O.ShipRegion,
                                O.ShipPostalCode,
                                O.ShipCountry,
                                C.ContactName AS CustomerContactName,
                                C.ContactTitle AS CustomerContactTitle,
                                C.Address AS CustomerAddress,
                                C.City AS CustomerCity,
                                C.Region AS CustomerRegion,
                                C.PostalCode AS CustomerPostalCode,
                                C.Country AS CustomerCountry,
                                C.Phone AS CustomerPhone,
                                C.Fax AS CustomerFax,
                                E.LastName AS EmployeeLastName,
                                E.FirstName AS EmployeeFirstName,
                                E.Title AS EmployeeTitle,
                                E.TitleOfCourtesy AS EmployeeTitleOfCourtesy,
                                E.Address AS EmployeeAddress,
                                E.City AS EmployeeCity,
                                E.Region AS EmployeeRegion,
                                E.PostalCode AS EmployeePostalCode,
                                E.Country AS EmployeeCountry,
                                E.HomePhone AS EmployeeHomePhone,
                                E.Extension AS EmployeeExtension,
                                S.Phone AS ShipViaNavigationPhone
                            FROM 
                                Orders O LEFT OUTER JOIN
                                Customers C LEFT OUTER JOIN ON O.CustomerID = C.CustomerID
                                Employees E LEFT OUTER JOIN ON O.EmployeeID = E.EmployeeID
                                Shippers S LEFT OUTER JOIN ON O.ShipVia = S.ShipperID
                            WHERE 
                                O.OrderID = @OrderId";

            return db.Query<Order>(sql, new { @OrderId = id }).Single();
        }

        public Order GetWithJoinExtended(string phrase)
        {
            var sql = $@"
                            SELECT 
                                O.OrderId,
                                O.ShipName,
                                O.ShipAddress,
                                O.ShipCity,
                                O.ShipRegion,
                                O.ShipPostalCode,
                                O.ShipCountry,
                                C.ContactName AS CustomerContactName,
                                C.ContactTitle AS CustomerContactTitle,
                                C.Address AS CustomerAddress,
                                C.City AS CustomerCity,
                                C.Region AS CustomerRegion,
                                C.PostalCode AS CustomerPostalCode,
                                C.Country AS CustomerCountry,
                                C.Phone AS CustomerPhone,
                                C.Fax AS CustomerFax,
                                E.LastName AS EmployeeLastName,
                                E.FirstName AS EmployeeFirstName,
                                E.Title AS EmployeeTitle,
                                E.TitleOfCourtesy AS EmployeeTitleOfCourtesy,
                                E.Address AS EmployeeAddress,
                                E.City AS EmployeeCity,
                                E.Region AS EmployeeRegion,
                                E.PostalCode AS EmployeePostalCode,
                                E.Country AS EmployeeCountry,
                                E.HomePhone AS EmployeeHomePhone,
                                E.Extension AS EmployeeExtension,
                                S.Phone AS ShipViaNavigationPhone
                            FROM 
                                Orders O LEFT OUTER JOIN
                                Customers C LEFT OUTER JOIN ON O.CustomerID = C.CustomerID
                                Employees E LEFT OUTER JOIN ON O.EmployeeID = E.EmployeeID
                                Shippers S LEFT OUTER JOIN ON O.ShipVia = S.ShipperID
                            WHERE 
                                O.ShipName LIKE '%' + @Phrase + '%' OR
                                O.ShipAddress LIKE '%' + @Phrase + '%' OR
                                O.ShipCity LIKE '%' + @Phrase + '%' OR
                                O.ShipRegion LIKE '%' + @Phrase + '%' OR
                                O.ShipPostalCode LIKE '%' + @Phrase + '%' OR
                                O.ShipCountry LIKE '%' + @Phrase + '%' OR
                                C.ContactName LIKE '%' + @Phrase + '%' OR
                                C.ContactTitle LIKE '%' + @Phrase + '%' OR
                                C.Address LIKE '%' + @Phrase + '%' OR
                                C.City LIKE '%' + @Phrase + '%' OR
                                C.Region LIKE '%' + @Phrase + '%' OR
                                C.PostalCode LIKE '%' + @Phrase + '%' OR
                                C.Country LIKE '%' + @Phrase + '%' OR
                                C.Phone LIKE '%' + @Phrase + '%' OR
                                C.Fax LIKE '%' + @Phrase + '%' OR
                                E.LastName LIKE '%' + @Phrase + '%' OR
                                E.FirstName LIKE '%' + @Phrase + '%' OR
                                E.Title LIKE '%' + @Phrase + '%' OR
                                E.TitleOfCourtesy LIKE '%' + @Phrase + '%' OR
                                E.Address LIKE '%' + @Phrase + '%' OR
                                E.City LIKE '%' + @Phrase + '%' OR
                                E.Region LIKE '%' + @Phrase + '%' OR
                                E.PostalCode LIKE '%' + @Phrase + '%' OR
                                E.Country LIKE '%' + @Phrase + '%' OR
                                E.HomePhone LIKE '%' + @Phrase + '%' OR
                                E.Extension LIKE '%' + @Phrase + '%' OR
                                S.Phone LIKE '%' + @Phrase + '%'";

            return db.Query<Order>(sql, new { @Phrase = phrase }).Single();
        }


        public int Create(Order order)
        {
            var sql = $@"
                            INSERT INTO Orders (
                                ShipName,
                                ShipAddress,
                                ShipCity,
                                ShipRegion,
                                ShipPostalCode,
                                ShipCountry)
                            VALUES (
                                ShipName,
                                ShipAddress,
                                ShipCity,
                                ShipRegion,
                                ShipPostalCode,
                                ShipCountry)
                                
                            
                            SELECT SCOPE_IDENTITY()";

            return db.Query<int>(sql, new { 
                @ShipName = order.ShipName,
                @ShipAddress = order.ShipAddress,
                @ShipCity = order.ShipCity,
                @ShipRegion = order.ShipRegion,
                @ShipPostalCode = order.ShipPostalCode,
                @ShipCountry = order.ShipCountry }).Single();
        }

        public void Update(Order order)
        {
            var sql = $@"
                            UPDATE Orders
                            SET 
                                ShipName = @ShipName,
                                ShipAddress = @ShipAddress,
                                ShipCity = @ShipCity,
                                ShipRegion = @ShipRegion,
                                ShipPostalCode = @ShipPostalCode,
                                ShipCountry = @ShipCountry
                            WHERE
                                 OrderID = @OrderId";

            db.Query<int>(sql, new
            {
                @ShipName = order.ShipName,
                @ShipAddress = order.ShipAddress,
                @ShipCity = order.ShipCity,
                @ShipRegion = order.ShipRegion,
                @ShipPostalCode = order.ShipPostalCode,
                @ShipCountry = order.ShipCountry,
                @OrderId = order.OrderId,
            });
        }

        public bool Delete(int id)
        {
            var sql = $@"   DECLARE @IsExists = 0;

                            IF EXISTS (SELECT * FROM Orders WHERE OrderID = @OrderId)
                            BEGIN
                                
                            DELETE FROM Orders 
                            WHERE 
                                OrderID = @OrderId
                            
                            SET @IsExists = 1;

                            END
    
                            SELECT @IsExists;";

            return db.Query<bool>(sql, new { @OrderId = id }).Single();
        }

    }
}
