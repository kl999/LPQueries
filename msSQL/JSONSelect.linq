<Query Kind="SQL">
  <Connection>
    <ID>67658466-48a3-40db-b678-ecd54267da8b</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>PaynetDB</Database>
  </Connection>
</Query>

select ISJSON(a) isJson, JSON_QUERY(a, '$.b') o, JSON_VALUE(a, '$.a') v/*, JSON_PATH_EXISTS(a, '$.b.r') as [exists]*/
from (select '{"a":391,"b":{"q":5,"r":"hello"}}' a) tbl

DECLARE @info NVARCHAR(100)='{"name":"John","skills":["C#","SQL"]}'

select JSON_MODIFY(@info,'$.name','Mike')
