<Query Kind="Statements">
  <Namespace>System.Data</Namespace>
  <Namespace>System.Data.OleDb</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

string dir = @"C:\Users\samartsev\Desktop\connectors\Актобе энерго снаб Регионы\район";

var di = new DirectoryInfo(dir);

string constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" + dir
	+ "\";Extended Properties=dBASE IV;User ID=Admin;Password=;";

DataTable dt = null;

var q = new List<string[]>();

using (OleDbConnection con = new OleDbConnection(constr))
{
	con.Open();

	foreach(var file in di.GetFiles("*.dbf"))
	{
		string fileName = Path.GetFileNameWithoutExtension(file.Name);
		
		var sql = "select * from " + fileName;
		OleDbCommand cmd = new OleDbCommand(sql, con);
		
		DataSet ds = new DataSet(); ;
		OleDbDataAdapter da = new OleDbDataAdapter(cmd);
		da.Fill(ds);
		
		dt = ds.Tables[0];
		
		foreach (var orow in dt.Rows)
		{
			var row = (DataRow)orow;
			
			var arr = new string[]
			{
				(row["NLS"] ?? "").ToString(),
				(string)(row["FIO1"].GetType() == typeof(DBNull) ? "" : row["FIO1"]),
				//(string)(row["ADDRESS"] ?? ""),
				((double)(row["SUM"].GetType() == typeof(DBNull) ? 0.0 : row["SUM"]))
					.ToString("0.00"),
				fileName,
			};
			
			q.Add(arr);
		}
	}
}

q
.GroupBy(i => i[0])
.OrderByDescending(i => i.Count())
.Dump();