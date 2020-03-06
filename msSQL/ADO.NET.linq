<Query Kind="Statements">
  <Namespace>System.Data.SqlClient</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <IncludeLinqToSql>true</IncludeLinqToSql>
</Query>

string connectionString =
@"Data Source=(localdb)\MyDB;Integrated Security=SSPI;app=LINQPad;Initial Catalog=test";

string queryString =
@"SELECT * FROM Tab1
select * from Test2";

int paramValue = 5;

using (SqlConnection connection = new SqlConnection(connectionString))
{
	SqlCommand command = new SqlCommand(queryString, connection);
	//command.Parameters.AddWithValue("@pricePoint", paramValue);
	
	DataSet dataset = new DataSet();
	
	try
	{
		connection.Open();
		
		SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = new SqlCommand(
            queryString, connection);
        adapter.Fill(dataset);
		
		dataset.Dump();
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.Message);
	}
}