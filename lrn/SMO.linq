<Query Kind="Statements">
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\130\SDK\Assemblies\Microsoft.SqlServer.ConnectionInfo.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Microsoft SQL Server\130\SDK\Assemblies\Microsoft.SqlServer.Management.Sdk.Sfc.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Microsoft SQL Server\130\SDK\Assemblies\Microsoft.SqlServer.Smo.dll</Reference>
  <Reference>&lt;ProgramFilesX64&gt;\Microsoft SQL Server\130\SDK\Assemblies\Microsoft.SqlServer.SqlEnum.dll</Reference>
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

Server srv = new Server(new ServerConnection("tb-impex-db", "ImExDBUser", "123"));

Database db = srv.Databases["Energopotok"];

ScriptingOptions sopt = new ScriptingOptions
{
    NoCollation = true,
    DriPrimaryKey = true,
    DriAllConstraints = true,
    
    
};

foreach (Table t in db.Tables)
{
    Console.Write(new string('-', 10));
    Console.WriteLine(t.Name);
    Console.Write(new string('-', 10));

    foreach (var s in t.Script(sopt))
    {
        Console.WriteLine("s: " + s.Replace("[dbo]", "[energopotok]"));
    }
}

foreach (StoredProcedure sp in db.StoredProcedures)
{
    if (sp.IsSystemObject) continue;

    Console.Write(new string('-', 10));
    Console.WriteLine(sp.Name);
    Console.Write(new string('-', 10));

    foreach (var s in sp.Script(sopt))
    {
        Console.WriteLine("s: " + s.Replace("[dbo]", "[energopotok]"));
    }
}