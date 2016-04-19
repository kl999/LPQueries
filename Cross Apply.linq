<Query Kind="SQL">
  <Connection>
    <ID>272431ed-01c6-4bb4-ac55-985d26c201f4</ID>
    <Persist>true</Persist>
    <Server>db-paynet</Server>
    <SqlSecurity>true</SqlSecurity>
    <Database>PaynetDB</Database>
    <UserName>PaynetDBOwner</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAD3LmAGy+IkOR/3qrx+HoeQAAAAACAAAAAAADZgAAwAAAABAAAABwJob4wHhJ0FrmTrlQyzE0AAAAAASAAACgAAAAEAAAANTm1Lg7+5jWttn1vDbAlk4QAAAAyOEb7K/LTdFm+Pal30glnRQAAAA7Rs2x/65mA3EGU17VAcgeeJysMw==</Password>
    <NoPluralization>true</NoPluralization>
    <IsProduction>true</IsProduction>
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

select *
from
(select 1 z union all select 2) a
cross apply
(
    select (a.z + 3) as x
    union all
    select (a.z - 1) as x
) as b
--where x = 1