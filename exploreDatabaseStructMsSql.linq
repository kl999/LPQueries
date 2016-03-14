<Query Kind="Statements">
  <GACReference>Microsoft.SqlServer.ConnectionInfo, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91</GACReference>
  <GACReference>Microsoft.SqlServer.Management.Sdk.Sfc, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91</GACReference>
  <GACReference>Microsoft.SqlServer.Smo, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91</GACReference>
  <GACReference>Microsoft.SqlServer.SqlEnum, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91</GACReference>
  <Namespace>Microsoft.SqlServer.Management.Common</Namespace>
  <Namespace>Microsoft.SqlServer.Management.Smo</Namespace>
  <Namespace>Microsoft.SqlServer.Management.Smo.Agent</Namespace>
  <Namespace>Microsoft.SqlServer.Management.Smo.Broker</Namespace>
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

string dbName = "[ImexOfflineRegistry]";

Server srv = new Server(new ServerConnection("tb-impex-db", "ImExDBUser", "123"));

Database db = srv.Databases[Regex.Match(dbName, @"^\[(.*)]$").Groups[1].Value];

ScriptingOptions sopt = new ScriptingOptions
{
    NoCollation = true,
    DriPrimaryKey = true,
    DriAllConstraints = true,
};

StringBuilder scriptStrBldr = new StringBuilder();

/*foreach (Table t in db.Tables)
{
    scriptStrBldr.AppendLine("--" + (t.Name));

    foreach (var s in t.Script(sopt))
    {
        scriptStrBldr.AppendLine(s.Replace("[dbo]", dbName));
    
        scriptStrBldr.AppendLine("GO");
    }
    
    scriptStrBldr.AppendLine();
}*/

scriptStrBldr.AppendLine();
scriptStrBldr.AppendLine("------------------");
scriptStrBldr.AppendLine();

foreach (StoredProcedure sp in db.StoredProcedures)
{
    if (sp.IsSystemObject) continue;

    scriptStrBldr.AppendLine("--" + sp.Name);

    foreach (var s in sp.Script(sopt))
    {
        /*scriptStrBldr.AppendLine(s);
    
        scriptStrBldr.AppendLine("GO");*/
        
        if(s.Contains("RemoveNonNumericChar"))
            Console.WriteLine(sp.Schema + "." + sp.Name);
    }
    
    scriptStrBldr.AppendLine();
}

/*foreach (Table t in db.Tables)
{
    Func<Table, string> getCols = tbl =>
    {
        string rez = "";
        
        foreach(Column o in t.Columns)
            if(!o.Identity) rez += o.Name + ",";
        
        rez = rez.Substring(0, rez.Length - 1);
        
        return rez;
    };
    
    scriptStrBldr.AppendLine(
@"insert into [ImexOfflineRegistry]." + dbName + @".[" + t.Name + @"] (" + getCols(t) + @")
select " + getCols(t) + " from " + dbName + ".[dbo].[" + t.Name + @"]");

    scriptStrBldr.AppendLine("GO");
    scriptStrBldr.AppendLine();
}*/

//scriptStrBldr.ToString().Dump();

/*new Hyperlinq(new Action(() =>
{
    //throw new Exception("ezvliol");
    
    srv.ConnectionContext.ExecuteNonQuery(scriptStrBldr.ToString());
    
}), "Transfer").Dump();*/