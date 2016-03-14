<Query Kind="Statements">
  <Connection>
    <ID>f2f6e2b4-0f40-48df-b2c7-82584a77c393</ID>
    <Server>.\SQLEXPRESS</Server>
    <AttachFile>true</AttachFile>
    <UserInstance>true</UserInstance>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\Nutshell.mdf</AttachFileName>
  </Connection>
</Query>

Purchases.Dump("Table");

"".Dump();

Purchases.Select (p => p.Description).Distinct().Dump("By types");

"".Dump();

var query = Purchases
.GroupBy(p => p.Description, p => new {p.CustomerID, p.Price} ).Dump("Grouped")
.Select(g => new {Desc = g.Key, Count = g.Count(), Price = g.Sum(i => i.Price)})
.OrderByDescending(o => o.Price)
.Dump("Result");

var a = query.ToArray();
a[0].Desc.Dump("Take \"Desc\" from 1-st row");


var query2 = Purchases
.GroupBy(p => p.Description, p => new {p.CustomerID, p.Price} )
.Select(g => 
	g.Select(i =>
		new { ID = i.CustomerID, Price_in_tg = String.Format("{0:### ### ###} tg", (i.Price * 150)) } 
			)).Dump();

Purchases
.GroupBy(p => p.Description, p => new {p.CustomerID, p.Price} )
.Select(g => 
		new { ID = g.Key
				, Price_tg = String.Format("{0:### ### ###} tg", g.Sum(s => s.Price * 150))
				, Price = g.Sum(s => s.Price * 150)} 
			).Dump();