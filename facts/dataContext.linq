<Query Kind="Statements" />

using System;
using System.Linq;
using System.Data.Linq; // in System.Data.Linq.dll
using System.Data.Linq.Mapping;
[Table] public class Customer
{
[Column(IsPrimaryKey=true)] public int ID;
[Column] public string Name;
}
class Test
{
static void Main()
{
DataContext dataContext = new DataContext ("connection string");
Table<Customer> customers = dataContext.GetTable <Customer>();
IQueryable<string> query = from c in customers
where c.Name.Contains ("a")
orderby c.Name.Length
select c.Name.ToUpper();
foreach (string name in query) Console.WriteLine (name);
}
}