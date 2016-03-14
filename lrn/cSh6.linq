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
    $"<Date in reverse: {DateTime.Now:ss:mm:HH yyyy.MM.dd}d>".Dump();
    
    var d = new Dictionary<string, int>()
    {
        ["a"] = 5,
        ["b"] = 6,
    }
    //.GetType()
    ;
    
    d.Dump();
    
    var a = new A();
    a.Dump();
    a.s = "zxc";
    a.lsp.Dump();
    a.lsm().Dump();
}

class A
{
    public string s = "rty";
    
    public string lsp => "qwe" + s;
    public string lsm() => "vbn" + s;
}