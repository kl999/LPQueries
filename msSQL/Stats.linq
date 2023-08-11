<Query Kind="SQL">
  <Connection>
    <ID>48339ccd-82c9-4fb8-b5a2-7fe6b66216da</ID>
    <Persist>true</Persist>
    <Server>kkz-pndb-rep</Server>
    <NoPluralization>true</NoPluralization>
    <IncludeSystemObjects>true</IncludeSystemObjects>
    <NoCapitalization>true</NoCapitalization>
    <Database>PaynetDB</Database>
  </Connection>
</Query>

SET STATISTICS TIME ON
SET STATISTICS IO ON

select *
from IBSO.KaspiPayByDate
where [Date] = '20230807'

SET STATISTICS IO OFF
SET STATISTICS TIME OFF
