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
  <Reference>C:\sp\CvTest\OpenCvSharp.dll</Reference>
  <Namespace>OpenCvSharp</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

//Directory.SetCurrentDirectory(@"C:\sp");

var bmp = new Bitmap(@"C:\sp\n1.jpg");

//bmp.Dump();

IplImage img = BitmapConverter.ToIplImage(bmp);

//img.Dump();

img.Smooth(img, SmoothType.Median, 21);

IplImage Cim = new IplImage(
	img.Size, BitDepth.U8, 1
	);

img.Canny(Cim, 50, 200);

//img.Sub(Cim, img);

BitmapConverter.ToBitmap(img).Dump();