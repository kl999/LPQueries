<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
  <Namespace>System.Security.Cryptography.X509Certificates</Namespace>
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
	
	using (RSACryptoServiceProvider rsa =
		(RSACryptoServiceProvider)new X509Certificate2(@"c:\sp\AviataRSA\kaspi.kz.p12", "superkaspi", X509KeyStorageFlags.DefaultKeySet).PrivateKey)
	{
		byteSign =
			rsa.SignData(byteSign, "SHA1");
	}
	
	byteSign.Dump("Enc");
	
	using (RSACryptoServiceProvider rsa =
		(RSACryptoServiceProvider)new X509Certificate2(@"c:\sp\AviataRSA\kaspi.kz.cer").PublicKey.Key)
	{
		rsa.VerifyData(Encoding.UTF8.GetBytes(strSign), "SHA1", byteSign).Dump("IsSame");
	}
}

// Define other methods and classes here
