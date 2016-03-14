<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	//using System.Security.Cryptography;
	
	var strSign = "<request><auth><provider>homebank</provider><message>4542b1d4-5bc2-4062-aee7-a0b6908442fd</message></auth><method>getPNR</method><params><pnr>ABC123</pnr></params></request>";
	
	var byteSign = Encoding.UTF8.GetBytes(strSign);
	
	// This is one implementation of the abstract class SHA1.
//	SHA1 sha = new SHA1CryptoServiceProvider();
//	
//	byteSign = sha.ComputeHash(byteSign);
//	
//	byteSign = new byte[0];
	
	using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
	{
		rsa.FromXmlString(File.ReadAllText(
			//@"c:\sp\AviataRSA\theirPublic.xml"
			//@"c:\sp\AviataRSA\public.xml"
			@"c:\sp\AviataRSA\private.xml"
			));
		
		byteSign =
			//rsa.Encrypt(byteSign, true);
			rsa.SignData(byteSign, "SHA1");
	}
	
	byteSign.Dump();
	
	using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
	{
		rsa.FromXmlString(File.ReadAllText(@"c:\sp\AviataRSA\public.xml"));
		
		rsa.VerifyData(Encoding.UTF8.GetBytes(strSign), "SHA1", byteSign).Dump();
	}
}