<Query Kind="Program">
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
	var str = @"0b9c68504bf7abe2c1097fbf110b00429b830f1bcfc93e0e8595f7dcb0a89db6";
	
	var rez = Base64Decode(str).Dump("Rez");
	
	Base64Encode("Hello! how u managed to understand such a complex cipher?").Dump();
}

public static string Base64Encode(string plainText)
{
	var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
	return System.Convert.ToBase64String(plainTextBytes);
}

public static string Base64Decode(string base64EncodedData)
{
	var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
    
    //File.WriteAllBytes(Path.Combine(Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%") ?? "z", @"Desktop\raw.raw"), base64EncodedBytes);
    
	return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
}