<Query Kind="Program">
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var str = @"Tj4q1qbcX0iQgHVZ3iyQYwG86YOMXOY_p2Ug7GVuyPl_0F9KqY4TvOglcaHZBj43_QftlcIpuWD8IpXt0CJHBoL9BXLNe7W6eQA3NvRVwkekc8kWZ6LnaR5Muh7fwfZE7Lu4teNPxRPEWmtHNIppdttd6jXfgiNX86XSZvAtJjnvSI684sZYxijaBFkwcf7GvYN-XxxRwk2cKGGDaVM49Ko6fFCkin5sHCtdUg6Al19F50iviGB5zlprEt1nPR9j0gTWuFpbph1KgtloV_hOmKHIHhtK-YSFT_mrwXreln7mSkLvQBed9LXgQrcYxKcGRyTvOpsHw2EncTyiqHXwfw";
	
	var rez = Base64Decode(str).Dump("Rez");
	
	Base64Encode("Hello! how u managed to understand such a complex cipher?").Dump();
    
    /*
    var raw = File.ReadAllText(@"in");

    var rezBytes = System.Convert.FromBase64String(raw);
    
    File.WriteAllBytes(@"out", rezBytes);
    */
}

public static string Base64Encode(string plainText)
{
	var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
	return System.Convert.ToBase64String(plainTextBytes);
}

public static string Base64Decode(string base64EncodedData)
{
	base64EncodedData = base64EncodedData + new String('=', base64EncodedData.Length % 4);
	
	base64EncodedData = base64EncodedData.Replace('-', '+').Replace('_', '/');
	
	var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
    
    //File.WriteAllBytes(Path.Combine(Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%") ?? "z", @"Desktop\raw.raw"), base64EncodedBytes);
    
	return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
}