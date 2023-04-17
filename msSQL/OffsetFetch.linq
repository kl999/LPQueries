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

select *
from app.Contragents
order by ID asc
offset 5 ROWS
Fetch First 5 Rows Only