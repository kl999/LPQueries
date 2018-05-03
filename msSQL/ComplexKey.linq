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

drop table ComplexKeyTab
GO

create table ComplexKeyTab
(
    a varchar(10) not null,
    b varchar(10) not null,
    name varchar(50)
)

ALTER TABLE ComplexKeyTab
    ADD CONSTRAINT pk_ComplexKeyTab PRIMARY KEY (a,b)


insert into ComplexKeyTab values ('1', 'a', 'qwerty')
insert into ComplexKeyTab values ('2', 'a', 'uiop')
insert into ComplexKeyTab values ('1', 'b', 'asdfg')

select * from ComplexKeyTab

delete fst
from ComplexKeyTab as fst
inner join (select '1' c, 'a' d) as scnd on a = c and b = d

select * from ComplexKeyTab