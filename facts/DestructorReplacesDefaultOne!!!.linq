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
    {
        a[] arr = new a[1024];
        
        for(int i = 0; i < arr.Length; i++)
        {
            arr[i] = new a();
        }
    }
    
    System.GC.Collect();
    
    Thread.Sleep(200);
    
    System.GC.Collect();
    
    Console.ReadLine();
}

class a
{
    byte[] mb = new byte[1048576];
    
    /*public a(Random rand)
    {
        for(int i = 0; i < mb.Length; i++)
        {
            mb[i] = (byte)rand.Next(256);
        }
    }*/
    
    ~a() { mb = null; "GCd".Dump(); }
}