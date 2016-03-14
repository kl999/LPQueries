<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Data.Linq</Namespace>
  <Namespace>System.Data.Linq.Mapping</Namespace>
  <Namespace>System.Linq</Namespace>
</Query>

void Main()
{
	DataContext dc = new DataContext 
		(@"Data Source=(localdb)\v11.0;Initial Catalog=NORTHWND; Integrated Security=True");
	
	Table<Orders> country = dc.GetTable <Orders>();
	
	country
	.Where(s => s.OrderID == 3)
	.Dump();
}

#pragma warning disable
[Table]
class Orders
{
	[Column(IsPrimaryKey=true)] public int OrderID;
	
	[Column] public string ShipCountry;
}
#pragma warning enable