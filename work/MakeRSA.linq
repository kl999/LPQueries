<Query Kind="Statements">
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

using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
{
	//Export the key information to an RSAParameters object. 
	//Pass false to export the public key information or pass 
	//true to export public and private key information.
	RSAParameters RSAParams = RSA.ExportParameters(true);
	RSAParams.Dump();
	
	/*File.WriteAllText(@"c:\sp\AviataRSA\public.xml", RSA.ToXmlString(false).Dump());
	File.WriteAllText(@"c:\sp\AviataRSA\private.xml",RSA.ToXmlString(true).Dump());*/
    
    var cert = new System.Security.Cryptography.X509Certificates.X509Certificate2();
    
    cert.PrivateKey.FromXmlString(RSA.ToXmlString(true));
    //).Save(@"c:\sp\AviataRSA\tst.p12");
}