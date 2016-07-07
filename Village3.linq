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

foreach(var raw in File.ReadAllLines(@"C:\Users\samartsev\Desktop\village.txt").Select(i => i.Split(';')))
{
    Organizations.InsertOnSubmit(new Organizations()
    {
        ObjectCode = raw[0],
        BIN = raw[1],
        BIK = raw[3],
        Account = raw[2],
    });
}

SubmitChanges();