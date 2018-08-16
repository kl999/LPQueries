<Query Kind="SQL">
  <Connection>
    <ID>67658466-48a3-40db-b678-ecd54267da8b</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MyDB</Server>
    <Database>Test</Database>
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

declare @t table (a int, b int, c int)

insert into @t values (1, 1, 1)

insert into @t values (1, 1, 2)

insert into @t values (1, 2, 1)

insert into @t values (1, 2, 2)

insert into @t values (1, 2, 3)

insert into @t values (2, 1, 1)

insert into @t values (2, 1, 2)

insert into @t values (2, 2, 1)

insert into @t values (2, 2, 2)

insert into @t values (2, 3, 1)

insert into @t values (2, 3, 2)

insert into @t values (2, 3, 3)

select * from @t

select
    a,
    count(distinct b) primct,
    count(c) subct
from @t
group by a