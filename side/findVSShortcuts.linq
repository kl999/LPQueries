<Query Kind="Program">
  <Namespace>System.Data.Linq.SqlClient</Namespace>
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

void Main()
{
    var di = new DirectoryInfo(@"C:\Program Files (x86)\Microsoft Visual Studio 14.0\VC#\Snippets\1033");
    
    search(di, "cw");
}

void search(DirectoryInfo di, string shortcut)
{
    foreach(var o in di.GetDirectories()) search(o, shortcut);
    
    foreach(var p in di.GetFiles().Select(i => i.FullName))
    {
        XElement el = null;
        
        try
        {
            el = XElement.Load(p);
        }
        //catch { continue; }
        finally {}
        
        //el.Dump();
        //el.Elements().Dump();
        
        XNamespace ns = el.GetDefaultNamespace();
        
        var sct = el?.Element(ns + "CodeSnippet")?.Element(ns + "Header")?.Element(ns + "Shortcut")?.Value;
        
        if(sct == shortcut) p.Dump();
    }
}