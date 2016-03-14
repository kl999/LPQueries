<Query Kind="Statements">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

using(var wrtr = new StreamWriter(
	@"c:\sp\tst.cs", false, Encoding.GetEncoding(1251)
))
{
	wrtr.WriteLine(
@"{1:F01SAGS000000000001000001}
{2:I102SGRОSS000000U3003}
{4:
:52В:CASPKZKA");
	
	wrtr.WriteLine(":70:/NUM/1");
	
	wrtr.WriteLine(String.Format("/DATE/{0:ddMMyy}", DateTime.Now));
	
	wrtr.WriteLine("/ASSIGN/");
	
	int i = 0;
	
	var cells = "666;GreatMany;Hell;6.66;13".Split(';');//0=AccountNumber;1=Name;2=Address;3=PayAmount;4=PaymentId
	
	wrtr.WriteLine(":21:" + (i + 1));
	
	wrtr.WriteLine(":32B:KZT" + cells[3]);
	
	wrtr.WriteLine(":70:/ADR/" + cells[2]);
	
	wrtr.WriteLine("//LS/" + cells[0]);
	
	wrtr.WriteLine("//FM/" + cells[1]);
	
	wrtr.WriteLine("//PHONE/");
	
	wrtr.WriteLine("//NPD/00101" + (i + 1));
	
	wrtr.WriteLine(string.Format(":32А:{0:ddMMyy}КZТ{1}", DateTime.Now, "6.66"));
	
	wrtr.Write("-}");
}