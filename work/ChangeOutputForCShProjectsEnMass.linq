<Query Kind="Program">
  <Namespace>System.Data.Linq.SqlClient</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Security</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Security.Cryptography.X509Certificates</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

string path = @"C:\sh\git\";

void Main()
{
    var mainDI = new DirectoryInfo(path);
    
    recursiveReplace(mainDI, 0);
}

void recursiveReplace(DirectoryInfo di, int nesting)
{
    foreach(var f in di.GetFiles("*.csproj"))
    {
        var doc = XElement.Load(f.FullName);
        
        var dftNs = (XNamespace)"http://schemas.microsoft.com/developer/msbuild/2003";
        
        foreach(var el in doc
            .Elements(dftNs + "PropertyGroup")
            .Where(i =>
                i.Attributes()
                .FirstOrDefault(ii =>
                    ii.Name == "Condition"
                    && (ii.Value.Contains("Release")
                        || ii.Value.Contains("Debug"))
                ) != null
            ))
        {
            var op = el.Element(dftNs + "OutputPath");
            
            op.Value = String.Join("", new int[nesting].Select(i => @"..\")) + "BuildOutput";
        }
        
        //string a = null; a.ToString();
        
        doc.Save(f.FullName);
    }
    
    foreach(var indi in di.GetDirectories())
    {
        recursiveReplace(indi, nesting + 1);
    }
}