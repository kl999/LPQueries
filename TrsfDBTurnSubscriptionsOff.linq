<Query Kind="SQL">
  <Connection>
    <ID>df0f6230-0fa9-4f65-94fc-c88d0367ea59</ID>
    <Persist>true</Persist>
    <Server>kaspi-rdb</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>TBRDBUser</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAIMLSY0QYdkKlD16aqsiScQAAAAACAAAAAAADZgAAwAAAABAAAABldVra9Xw6CLV5O3cm2ihAAAAAAASAAACgAAAAEAAAAAqMpoY4LSt+eVnFzJdNmk4QAAAAOmq1Xxfiu908b33P2HN8hhQAAAC0x1SNrc0kV4PHgN/bRwDtwa8NCA==</Password>
    <IsProduction>true</IsProduction>
    <Database>TBRDB</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Output>DataGrids</Output>
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

SELECT
	*
FROM
	[TBRDB].[dbo].[tb_Payments_Subscriptions] s (nolock)
WHERE
	s.intServiceId in (505)
	AND s.bitIsActive = 1

return
-----------------------------------------------------------------

declare @svcId int = 505

INSERT INTO [TBRDB].[dbo].[tb_Payments_Subscriptions_Saved_Active]
SELECT
	*
FROM
	[TBRDB].[dbo].[tb_Payments_Subscriptions] s (nolock)
WHERE
	s.intServiceId in (@svcId)
	AND s.bitIsActive = 1

UPDATE [TBRDB].[dbo].[tb_Payments_Subscriptions]
SET bitIsActive = 0
WHERE
	intServiceId in (@svcId)
	AND bitIsActive = 1

select * from [TBRDB].[dbo].[tb_Payments_Subscriptions_Saved_Active]

------------------------------------------------

UPDATE [TBRDB].[dbo].[tb_Payments_Subscriptions]
SET bitIsActive = 1
WHERE
	bintId in (select bintid from [dbo].[tb_Payments_Subscriptions_Saved_Active])

delete from [dbo].[tb_Payments_Subscriptions_Saved_Active]