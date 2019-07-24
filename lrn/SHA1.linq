<Query Kind="Program">
  <Namespace>LINQPad.Controls</Namespace>
  <Namespace>System.Data.Linq.SqlClient</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Security</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
  <Namespace>System.Security.Cryptography.X509Certificates</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
    var di = new DirectoryInfo(@"queries\Git\lrn");
    
    foreach(var fi in di.GetFiles())
    {
        $"{fi.Name}: {getFileHash(File.ReadAllBytes(fi.FullName))}".Dump();
    }
}

string getFileHash(byte[] buffer)
{
    using(SHA1Managed sha1 = new SHA1Managed())
    {
        var hash = sha1.ComputeHash(buffer);
        var sb = new StringBuilder(hash.Length * 2);

        foreach(byte b in hash)
        {
            // can be "x2" if you want lowercase
            sb.Append(b.ToString("X2"));
        }

        return sb.ToString();
    }
}