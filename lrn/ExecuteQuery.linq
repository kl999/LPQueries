<Query Kind="Program">
  <Connection>
    <ID>a6bbe6d0-1633-48b8-b9e9-e15038454d48</ID>
    <Persist>true</Persist>
    <Server>kaspi-rep</Server>
    <NoPluralization>true</NoPluralization>
    <IncludeSystemObjects>true</IncludeSystemObjects>
    <Database>PaynetDB</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Namespace>System.Data.Linq.SqlClient</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Security</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Security.Cryptography.X509Certificates</Namespace>
  <Namespace>System.Threading</Namespace>
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