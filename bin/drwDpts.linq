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

long w = 103,
	h = 103;

long[,] map = new long[w, h];

long inc = 10;

map[((w - 1) / 2) + 1, ((h - 1) / 2) + 1] = inc;

long sqrt2 = (int)(Math.Sqrt(2) * 100);

for(bool fnd = true; fnd;)
{
fnd = false;

for(int x = 1; x < w - 1; x++)
for(int y = 1; y < h - 1; y++)
{
	if(map[x, y] != 0)
	{
		long val = map[x, y];
		
		if(map[x, y - 1] == 0)
			map[x, y - 1] = val + inc;
		
		if(map[x + 1, y - 1] == 0)
			map[x + 1, y - 1] = ((val + inc) * sqrt2) / 100;
		
		if(map[x + 1, y] == 0)
			map[x + 1, y] = val + inc;
		
		if(map[x + 1, y + 1] == 0)
			map[x + 1, y + 1] = ((val + inc) * sqrt2) / 100;
		
		if(map[x, y + 1] == 0)
			map[x, y + 1] = val + inc;
		
		if(map[x - 1, y + 1] == 0)
			map[x - 1, y + 1] = ((val + inc) * sqrt2) / 100;
		
		if(map[x - 1, y] == 0)
			map[x - 1, y] = val + inc;
		
		if(map[x - 1, y - 1] == 0)
			map[x - 1, y - 1] = ((val + inc) * sqrt2) / 100;
	}
	else
	{
		fnd = true;
	}
}
}

map.Dump();

Bitmap bmp = new Bitmap((int)w, (int)h);

for(int x = 1; x < w - 1; x++)
for(int y = 1; y < h - 1; y++)
{
	int val = (byte)(map[x, y] / 2);
	
	bmp.SetPixel(x - 1, y - 1, Color.FromArgb(val, val, val));
}

bmp.Dump();