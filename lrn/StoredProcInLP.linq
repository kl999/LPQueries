<Query Kind="Statements">
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

//ALTER PROCEDURE [Tst].[getNTablesSp]
//(
//	@tCt int,
//    @rezVal int = 0 out
//)
//AS
//
//declare @ct int = 0
//
//while @tct > 0
//begin
//    set @ct = @ct + 2
//    
//    if @tct % 2 = 0
//    
//    select
//        'Hello World x ' as hel,
//        @ct - 1 as 'lo'
//    union all
//    select
//        'Hello World x ' as hel,
//        @ct as lo
//        
//    else
//    
//    select
//        'Hello World x ' as asd,
//        @ct - 1 as 'zxc'
//    union all
//    select
//        'Hello World x ' as zxc,
//        @ct as lo
//    
//    set @tct -= 1
//    
//end
//
//set @rezVal = @ct

ReturnDataSet rez = getNTablesSp(2);
rez = getNTablesSp(2, 0);

rez.OutputParameters["@rezVal"].Dump();
rez.ReturnValue.Dump();

for(int i = 0; i < rez.Tables.Count; i++)
{
    rez
    .AsDynamic(i)
    .OrderByDescending(o => {try{return o.lo;}catch{return o.zxc;}})
    .Dump();
}