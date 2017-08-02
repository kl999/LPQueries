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
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

declare @tab table(a bit, b bit null)

insert into @tab values(1, null)
insert into @tab values(0, null)
insert into @tab values(1, null)

update @tab set b = a

select * from @tab

print('---------------------')

declare @tab2 table(a bit, b varchar(100) null)
declare @tab3 table(v bit, n varchar(100))

insert into @tab2 values(1, null)
insert into @tab2 values(0, null)
insert into @tab2 values(1, null)

insert into @tab3 values(1, 'Yes')
insert into @tab3 values(0, 'No')

update t
set b = n
from
    @tab2 as t
inner join
    @tab3 as d on a = v

select * from @tab2