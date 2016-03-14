<Query Kind="Statements">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

//D:\Документы\VideoPlateRegistration\VideoPlateRecognition\bin\Debug

Regex.Match("{A31BDPP1}	from <11:28:45> to <11:28:50>",
	@"{(.*)}\sfrom\s<(.*?)>\sto\s<(.*)>").Groups.Dump();


Regex.Match("28 февраля 2014г.",
	@"\d{2,2}\s\w+\s20\d{2,2}г\.").Dump();