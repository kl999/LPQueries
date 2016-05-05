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

var di = new DirectoryInfo(@"c:\sp\svdTab");

foreach(var f in di.GetFiles())
{
	f.Delete();
}

var q = Numbers
.AsEnumerable();

var q2 = q
.Select(i =>
{
	byte[] buf = ((byte[])i.NumImg);
	
	Bitmap NumImg = new Bitmap(new MemoryStream(buf));
	
	buf = ((byte[])i.PrevImg);
	
	Bitmap PrevImg = new Bitmap(new MemoryStream(buf));
	
	return new {i.Number, i.From, i.To, NumImg, PrevImg };
});

string str = "";

int ct = 0;

foreach(var o in q2)
{
	str += o.Number + "|" + o.From + "|" + o.To + "\n";
	
	o.NumImg.Save(@"c:\sp\svdTab\n" + ct + ".jpg");
	
	o.PrevImg.Save(@"c:\sp\svdTab\p" + ct + ".jpg");
	
	ct++;
}

//str.Dump();

File.WriteAllText(@"c:\sp\svdTab\sv", str);