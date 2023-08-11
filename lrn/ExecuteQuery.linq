<Query Kind="Program">
  <Connection>
    <ID>67658466-48a3-40db-b678-ecd54267da8b</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>MyDB</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
  <Namespace>System.Data.Linq.SqlClient</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Security</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Security.Cryptography.X509Certificates</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
    ExecuteQuery<A>(@"
    select cast(0 as bigint) as a, 'hi' as s, 'world' as d
    union all
    select 2488945 as a, 'z' as s, null as d
    ")
    .Dump();
}

class A
{
    public long a;
    public string s;
    public string d;
}