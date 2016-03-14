<Query Kind="Statements">
  <Connection>
    <ID>ed670bf1-8e48-4ac5-a7a5-c2eeedeb36f0</ID>
    <Persist>true</Persist>
    <Server>SQL1pc</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>Administrator</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAXpJ+KyRD6U+pcsygin2BCgAAAAACAAAAAAADZgAAwAAAABAAAAA/ZWiOduHkgIkhvz/llEoKAAAAAASAAACgAAAAEAAAAIDbBCMRDyw+3k0/3eEex8gIAAAAO8DL17C0ADQUAAAAygiYJ7Wd9JBoN3JVZTD6waAzLDU=</Password>
    <IncludeSystemObjects>true</IncludeSystemObjects>
    <Database>testDb</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var str = (
  "Some say the world will end in fire "
+ "Some say in ice "
+ "From what I’ve tasted of desire "
+ "I stand with those who favor fire "
+ "But if it was to parish twice "
+ "I think I know enough of hate "
+ "To say that for distraction ice is also great "
+ "And will suffice"
).Split().Select((i, ind) => new { ind, i }).ToList();//.Dump();

foreach(WordTab row in
	str.Select(i => new WordTab(){ Number = i.ind, String = i.i, TextId = 0 })
)
{
	WordTabs.InsertOnSubmit(row);
}

SubmitChanges();

WordTabs.Dump();