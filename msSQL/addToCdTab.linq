<Query Kind="Statements">
  <Connection>
    <ID>ed670bf1-8e48-4ac5-a7a5-c2eeedeb36f0</ID>
    <Persist>true</Persist>
    <Server>SQL1pc</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>Administrator</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAXpJ+KyRD6U+pcsygin2BCgAAAAACAAAAAAADZgAAwAAAABAAAAA/ZWiOduHkgIkhvz/llEoKAAAAAASAAACgAAAAEAAAAIDbBCMRDyw+3k0/3eEex8gIAAAAO8DL17C0ADQUAAAAygiYJ7Wd9JBoN3JVZTD6waAzLDU=</Password>
    <Database>testDb</Database>
    <ShowServer>true</ShowServer>
    <IncludeSystemObjects>true</IncludeSystemObjects>
    <DriverData>
      <SkipCertificateCheck>true</SkipCertificateCheck>
    </DriverData>
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

CdTab row = new CdTab();

row.Name = "first_";

var buf = new byte[1024];

buf[0] = 1;

row.Code = buf;

CdTabs.InsertOnSubmit(row);
SubmitChanges();

CdTabs.Dump();