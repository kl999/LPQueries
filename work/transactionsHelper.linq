<Query Kind="Program">
  <Connection>
    <ID>f2f6e2b4-0f40-48df-b2c7-82584a77c393</ID>
    <Server>.\MSSQLSERVERSPA</Server>
    <Database>Test</Database>
    <NoPluralization>true</NoPluralization>
    <Persist>true</Persist>
  </Connection>
  <Namespace>System.Data.Linq.SqlClient</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
    for(int z = 0; z < 1000; z++)
    {
        reset();
        
        var t1 = new Task(() =>
        {
            ":a start".Dump();
            take("a");
            ":a finish".Dump();
        });
        
        var t2 = new Task(() =>
        {
            ":b start".Dump();
            take("b");
            ":b finish".Dump();
        });
        t1.Start();
        Thread.Sleep(1000);
        t2.Start();
        
        Task.WaitAll(new[]{ t1, t2 });
    }
}

void take(string name)
{
    using (SqlConnection connection = new SqlConnection("Server=.\\MSSQLSERVERSPA;Database=Test;Trusted_Connection=Yes;"))
    {
        SqlCommand command = new SqlCommand("dbo.transTestSp", connection);
        command.CommandType = CommandType.StoredProcedure;

        SqlParameter param;

        param = new SqlParameter("name", SqlDbType.VarChar, 50);
        param.Value = name;
        command.Parameters.Add(param);

        connection.Open();
        using (SqlDataReader reader = command.ExecuteReader())
        {
            (":" + name).Dump();
            while (reader.Read())
            {
                reader["wasName"].Dump();
            }
        }
    }
    
    //transTestSp(name).Dump();
}

void reset()
{
    using (SqlConnection connection = new SqlConnection("Server=.\\MSSQLSERVERSPA;Database=Test;Trusted_Connection=Yes;"))
    {
        SqlCommand command = new SqlCommand("update testTransaction set strTst = 'start' where numTst = 1", connection);
        
        connection.Open();
        command.ExecuteNonQuery();
    }
}