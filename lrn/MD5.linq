<Query Kind="Program">
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Security</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Security.Cryptography.X509Certificates</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
    CalculateMD5Hash("").Dump();//TP03abcd1234//1234567890ABCDEF
}

public string CalculateMD5Hash(string input)
{
    // step 1, calculate MD5 hash from input

    var md5 = System.Security.Cryptography.MD5.Create();

    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

    byte[] hash = md5.ComputeHash(inputBytes);

    // step 2, convert byte array to hex string

    StringBuilder sb = new StringBuilder();

    for (int i = 0; i < hash.Length; i++)
    {
        sb.Append(hash[i].ToString("X2"));
    }

    return sb.ToString();
}