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

void Main()
{
    foreach(var o in emitEnum())
    {
        $"->{o}".Dump();
        
        if(o > 3) break;
    }
}

IEnumerable<int> emitEnum()
{
    using(var a = new DspzCheck())
    {
        for(int i = 0; i < 100; i++)
        {
            i.Dump();
            yield return i;
        }
    }
}

class DspzCheck : IDisposable
{
    public void Dispose()
    {
        "Disposed!".Dump();
    }
}