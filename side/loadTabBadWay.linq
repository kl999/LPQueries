<Query Kind="Statements">
  <Connection>
    <ID>b35e2479-3b0e-4dd6-bd5f-36670a7fe583</ID>
    <Persist>true</Persist>
    <Driver Assembly="IQDriver" PublicKeyToken="5b59726538a49684">IQDriver.IQDriver</Driver>
    <Provider>Devart.Data.MySql</Provider>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAXpJ+KyRD6U+pcsygin2BCgAAAAACAAAAAAADZgAAwAAAABAAAACREX2+tLaFEppNNnO8ecpBAAAAAASAAACgAAAAEAAAAEHgtGt1TILs2eYyk9+Zx8M4AAAAOqFxxJYGkshKtROr2d/Y/tfVotVIlTygb+UiTZygbipu7XPLEyz9SQC6vx1ofCb+iSPzikzntkoUAAAAvSeOWuPI5AjsddgD8SRI31SXGAY=</CustomCxString>
    <Server>192.168.0.13</Server>
    <Database>avideo</Database>
    <UserName>video</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAXpJ+KyRD6U+pcsygin2BCgAAAAACAAAAAAADZgAAwAAAABAAAAAxoqwgcoRFGaWg4mq52TjmAAAAAASAAACgAAAAEAAAAOehqnKZvhaeJJ6wpD6EWU8IAAAAMI20flaJLuQUAAAAILu84iqrc3EC74EN3i8gqU8k2LI=</Password>
    <DisplayName>aVideo</DisplayName>
    <EncryptCustomCxString>true</EncryptCustomCxString>
    <DriverData>
      <StripUnderscores>false</StripUnderscores>
      <QuietenAllCaps>false</QuietenAllCaps>
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

string[] llines = File.ReadAllLines(@"c:\sp\svdTab\sv");

llines
.Take(llines.Length - 1)
.Select((o, i) =>
{
	string ldt = llines[i].Trim();
	
	string[] vals = ldt.Split('|');
	
	return new
	{
		Number = vals[0],
		From = DateTime.Parse(vals[1]),
		To = DateTime.Parse(vals[2]),
		NumImg = new Bitmap(@"c:\sp\svdTab\n" + i + ".jpg"),
		PrevImg = new Bitmap(@"c:\sp\svdTab\p" + i + ".jpg")
	};
}
)
.Dump();