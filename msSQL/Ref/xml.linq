<Query Kind="SQL">
  <Connection>
    <ID>47cc8142-e084-41ed-a7c3-a70fbeb29153</ID>
    <Persist>true</Persist>
    <Server>tb-impex-db</Server>
    <SqlSecurity>true</SqlSecurity>
    <Database>ImexOfflineRegistry</Database>
    <NoPluralization>true</NoPluralization>
    <UserName>ImExDBUser</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAA9QqopYu6QUSrcyly5v9QgQAAAAACAAAAAAADZgAAwAAAABAAAAD5WIs4mgqCtfMTKwgxN5ROAAAAAASAAACgAAAAEAAAADce6p38+wVTbpEMAhy9e/QIAAAAY6XnGQx0MOUUAAAAI8qi4BtECYD8fusyRg6gkjS/ggI=</Password>
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

declare @xmlPayDetails varchar(max)/*text*/ = '<dets><det code="15" amount="300"><amount2>280</amount2></det></dets>'

DECLARE @idoc int

EXEC sp_xml_preparedocument @idoc OUTPUT, @xmlPayDetails

SELECT
	a.code,
	a.amount,
    a.amount2
FROM
	OPENXML (@idoc, '/dets/det', 3)
WITH 
(
	code varchar(20),
	amount bigint,
    amount2 bigint
) a

SELECT
	code,
	amount,
    amount2
FROM
	OPENXML (@idoc, '/dets/det', 3)
WITH 
(
	code varchar(20),
	amount bigint,
    amount2 bigint
)

EXEC sp_xml_removedocument @idoc