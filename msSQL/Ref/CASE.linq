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

DECLARE @tab table ( id int )

INSERT INTO @tab VALUES (1)
INSERT INTO @tab VALUES (2)
INSERT INTO @tab VALUES (3)

SELECT
    (CASE id
    WHEN 1 THEN 'One'
    ELSE 'Many'
    END) AS String
FROM
    @tab

SELECT
    (CASE
    WHEN id = 1 THEN 'A'
    WHEN id = 3 Then 'C'
    --ELSE ''
    END) AS String
FROM
    @tab