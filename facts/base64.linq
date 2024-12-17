<Query Kind="Program">
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var str = @"eyJuYmYiOjE2OTc2MDA3OTcsImV4cCI6MTY5NzYwNDM5NywiaXNzIjoiaHR0cHM6Ly9kZXYtYXV0aC5rYXp0aWNrZXQua3oiLCJjbGllbnRfaWQiOiJLYXp0aWNrZXQuT3BlbkFwaS5LYXNwaSIsImNsaWVudF9Jc01hcmtldFBsYWNlIjoidHJ1ZSIsImlhdCI6MTY5NzYwMDc5Nywic2NvcGUiOlsiTWFya2V0UGxhY2UiXX0";
	
	var rez = Base64Decode(str).Dump("Rez");
	
	Base64Encode("Hello! how u managed to understand such a complex cipher?").Dump();
	
	//System.Buffers.Text.Base64Url.EncodeToString("The weather is sunny!").Dump();
    
    /*
    var raw = File.ReadAllText(@"in");

    var rezBytes = System.Convert.FromBase64String(raw);
    
    File.WriteAllBytes(@"out", rezBytes);
    /**/
	
	/*
	var raw = File.ReadAllBytes(@"in");
	
	System.Convert.ToBase64String(raw).Dump("FromFile");
	/**/
	
	"".Dump();
}

public static string Base64Encode(string plainText)
{
	var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
	return System.Convert.ToBase64String(plainTextBytes);
}

public static string Base64Decode(string base64EncodedData)
{
	base64EncodedData = base64EncodedData + new String('=', base64EncodedData.Length % 2);
	
	base64EncodedData = base64EncodedData.Replace('-', '+').Replace('_', '/');
	
	//base64EncodedData.Dump();
	
	var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
    
    //File.WriteAllBytes(Path.Combine(Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%") ?? "z", @"Desktop\raw.raw"), base64EncodedBytes);
    
	return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
}