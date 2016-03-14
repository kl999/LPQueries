<Query Kind="Statements">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Data</Namespace>
  <Namespace>System.Data.Common</Namespace>
  <Namespace>System.Data.Linq.SqlClient</Namespace>
  <Namespace>System.Data.Odbc</Namespace>
  <Namespace>System.Data.OleDb</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var transformedFilePath = @"C:\Users\samartsev\Desktop\TEO.dbf";

DbConnection connection = null;
if (true)//866
{
    string connString = "Driver={Microsoft dBase Driver (*.dbf)};SourceType=DBF;SourceDb=" + transformedFilePath;
    connection = new OdbcConnection(connString);
}
else
{
    string connString = "Provider=vfpoledb;Collating Sequence=machine;Data Source=" + transformedFilePath;
    connection = new OleDbConnection(connString);
}

DbCommand command = connection.CreateCommand();
command.CommandText =
    String.Format("SELECT * FROM {0}",
    Path.Combine(Path.GetDirectoryName(transformedFilePath), Path.GetFileNameWithoutExtension(transformedFilePath)));

connection.Open();
var dataReader = command.ExecuteReader();

for(;dataReader.Read();)
{
    int len = dataReader.FieldCount;
    
    for(int i = 0; i < len; i++)
        (dataReader.GetName(i) + ": " + dataReader[i]).Dump();
    
    "".Dump();
}