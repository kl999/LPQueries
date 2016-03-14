<Query Kind="Program">
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
  <Reference>&lt;ProgramFilesX86&gt;\MySQL\MySQL Connector Net 6.7.4\Assemblies\v4.0\MySql.Data.dll</Reference>
  <Namespace>MySql.Data.MySqlClient</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	/*Bitmap bmp = new Bitmap(@"c:\sp\n7.png");
	
	sendBmp(bmp);*/
	
	/*DirectoryInfo di = new DirectoryInfo(
	@"D:\Документы\VideoPlateRegistration\VideoPlateRecognition\bin\Debug\results\previous");
	
	foreach(FileInfo file in di.GetFiles())
	{
		file.Name.Dump();
		
		Bitmap orig = new Bitmap(file.OpenRead());
		
		Bitmap bmp = new Bitmap(orig, 320, 200);
		
		//bmp.Dump();
		
		sendBmp(bmp);
	}*/
	
	param();
}


void sendBmp(Bitmap bmp)
{
	MemoryStream str = new MemoryStream();
	
	bmp.Save(str, ImageFormat.Jpeg);
	
	byte[] buf = str.GetBuffer();
	
	//buf.Dump();
	
	//Encoding.UTF8.GetByteCount(BitConverter.ToString(buf).Replace("-", string.Empty)).Dump();
	
	string send = BitConverter.ToString(buf).Replace("-", string.Empty);
	
	//send.Dump();
	
	string CommandText = "INSERT INTO `avideo`.`imgtab` (`image`) VALUES (0x" + send + ")";
	string Connect="Database=avideo;Data Source=192.168.0.13;User Id=video;Password=123";
	
	//((double)Encoding.UTF8.GetByteCount(CommandText) / 1024).Dump();
	
	MySqlConnection myConnection = new MySqlConnection(Connect);
	MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
	
	myConnection.Open();
	
	myCommand.ExecuteNonQuery();
	
	myConnection.Close();
}

void param()
{
	Bitmap bmp = new Bitmap(@"c:\sp\1.png");
	
	MemoryStream str = new MemoryStream();
	
	bmp.Save(str, ImageFormat.Jpeg);
	
	byte[] buf = str.GetBuffer();
	
	string Connect="Database=avideo;Data Source=192.168.0.13;User Id=video;Password=123";
	
	MySqlConnection myConnection = new MySqlConnection(Connect);
	
	var myCommand = new MySqlCommand("INSERT INTO imgtab SET image = @image", myConnection);
    myCommand.Parameters.Add("@image", MySqlDbType.Blob).Value = buf;
	
	myConnection.Open();
	
	myCommand.ExecuteNonQuery();
	
	myConnection.Close();
}