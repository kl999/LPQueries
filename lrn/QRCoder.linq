<Query Kind="Statements">
  <Reference Relative="..\_Exts\QRCoder.dll">C:\Users\samartsev_26224\Desktop\LINQPad6\queries\Git\_Exts\QRCoder.dll</Reference>
  <Namespace>QRCoder</Namespace>
  <Namespace>QRCoder.Exceptions</Namespace>
  <Namespace>QRCoder.Extensions</Namespace>
</Query>

//https://github.com/codebude/QRCoder

QRCodeGenerator qrGenerator = new QRCodeGenerator();
QRCodeData qrCodeData = qrGenerator.CreateQrCode("The text which should be encoded.", QRCodeGenerator.ECCLevel.Q);
var qrCode = new QRCode(qrCodeData);
qrCode.GetGraphic(10).Dump();
