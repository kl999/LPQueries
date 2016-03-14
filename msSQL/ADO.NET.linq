<Query Kind="Statements">
  <Namespace>System.Data</Namespace>
  <Namespace>System.Data.SqlClient</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

string connectionString =
@"Data Source=SQL1pc;Initial Catalog=testDb;user=Administrator;password=admin";

string queryString =
@"SELECT * FROM wordTab";

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
		
		dataset.DataTable[0].Dump();
	}
	catch (Exception ex)
	{
		Console.WriteLine(ex.Message);
	}
}