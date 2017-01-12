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

var transformedFilePath = @"C:\Users\samartsev\Desktop\";

DbConnection connection = null;
if (false)//866
{
    string connString = "Driver={Microsoft dBase Driver (*.dbf)};SourceType=DBF;SourceDb=" + transformedFilePath;
    connection = new OdbcConnection(connString);
}
else
{
    string connString = 
    //"Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=False;Extended Properties=dbase 5.0;Data Source=" + transformedFilePath;
    "Provider=vfpoledb;Collating Sequence=RUSSIAN;Data Source=" + transformedFilePath;
    connection = new OleDbConnection(connString);
}

DbCommand command = connection.CreateCommand();
command.CommandText =
    String.Format(@"CREATE TABLE tmp98454 ([SDOK] numeric(18, 2), [FIO] varchar(50), [BILL_CODE] varchar(12), [DATE2] varchar(100), [SUBDIVIS] varchar(8), [ORDER_DATE] datetime,  [NUMKVIT] numeric)
    ").Dump();
    //[SDOK] numeric(18, 2), [FIO] varchar(50), [BILL_CODE] varchar(12), [DATE2] varchar(100), [SUBDIVIS] varchar(8), [ORDER_DATE] datetime, [NUMKVIT] numeric(9,2)

connection.Open();
var dataReader = command.ExecuteReader();

command = connection.CreateCommand();
command.CommandText =//10.01.2017 17:51:48
    String.Format(@"INSERT INTO tmp98454 ([SDOK], [FIO], [BILL_CODE], [DATE2], [SUBDIVIS], [ORDER_DATE], [NUMKVIT]) VALUES (1.00, 'ГО Тухачевского  -Посаженников --', '2300го00030', 'г.Текели, ул.Толе би, д.41, кв.2', '100', CTOT('01/01/17 10:00'), 349553084)
    ").Dump();
command.ExecuteReader();

connection.Close();
connection.Open();

command = connection.CreateCommand();
command.CommandText =
    String.Format(@"select * from TMP98454
    ").Dump();
dataReader = command.ExecuteReader();

for(int ct = 0;dataReader.Read(); ct++)
{
    int len = dataReader.FieldCount;
    
    $"{ct}---------------------".Dump();
    
    for(int i = 0; i < len; i++)
        (dataReader.GetName(i) + ": " + dataReader[i]).Dump();
    
    "".Dump();
}