<Query Kind="Statements">
  <Connection>
    <ID>b35e2479-3b0e-4dd6-bd5f-36670a7fe583</ID>
    <Persist>true</Persist>
    <Driver Assembly="IQDriver" PublicKeyToken="5b59726538a49684">IQDriver.IQDriver</Driver>
    <Provider>Devart.Data.MySql</Provider>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAhcs/CVWJAUqCcoBOjqPB/AAAAAACAAAAAAADZgAAwAAAABAAAABp23jBJOG2AoWBdP9kVpdZAAAAAASAAACgAAAAEAAAACzv66b+V5RI02/Bb74HGT04AAAAFBexL1d1pv7G7GyQcwNH3MZ+QacTDDkqlKA+pM1ifWMGZ261/vqUGk9TFmDw2DTK/J8PNUJiVysUAAAALQdoZ7s9+3YgL6yme4Galo1AgeE=</CustomCxString>
    <Server>192.168.0.20</Server>
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

Color clr1 = Color.Red, clr2 = Color.Green;

var bmp = new Bitmap(100, 100);

Graphics.FromImage(bmp).Clear(clr1);

bmp.Dump();

var pctbmp = new Bitmap(30, 30);

Color pctclr = Color.White;

for(int pct = 90; pct >= 10; pct -= 10)
{
	pctclr = Color.FromArgb(
		(byte)((clr1.R * pct + clr2.R * (100 - pct)) / 100)
		, (byte)((clr1.G * pct + clr2.G * (100 - pct)) / 100)
		, (byte)((clr1.B * pct + clr2.B * (100 - pct)) / 100)
		);
	
	Graphics.FromImage(pctbmp).Clear(pctclr);
	
	pctbmp.Dump();
}

Graphics.FromImage(bmp).Clear(clr2);

bmp.Dump();