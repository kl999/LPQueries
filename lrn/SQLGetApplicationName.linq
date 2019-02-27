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

--Data Source=(localdb)\MyDB;Integrated Security=SSPI;Application Name=TestApp

select * from tab1

select program_name, host_name, count(*), SUM(cpu_time) AS CPU,  SUM(reads) AS Reads,  SUM(s.logical_reads) AS LogicalReads,  SUM(s.writes) AS Writes, 
              SUM(s.total_elapsed_time) AS TotalTime,  SUM(s.total_scheduled_time) AS TotalScheduleTime
from sys.dm_exec_sessions s
where 1=1
    --and session_id > 50 and session_id <> @@spid
    --and login_name <> '' and program_name not like '%SQL%'
    and database_id = db_id()
group by program_name, host_name
order by LogicalReads desc