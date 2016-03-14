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
    var a = new Cls();
    
    a.Dump();
    
    var di = new DirectoryInfo(@"c:\sp\imgs");
    
    if(false)
    for(;;)
    {
        foreach(var bmp in di.GetFiles().Select(i => new Bitmap(i.FullName)))
        {
            var tmr = Task.Delay(800);
            
            //bmp.Dump();
            
            a.dc.Content = bmp;
            
            tmr.Wait();
        }
    }
}

class Cls
{
    public int a = 5;
    public int s = 2;
    
    public DumpContainer dc = new DumpContainer();
    
    public string d = "QwertyUiop!";
    
    public string asd
    {
        get { return "4"; }
    }
}