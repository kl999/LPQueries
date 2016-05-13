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
    a().Dump();
    
    dlgt b = mtda;
    
    b().Dump();
    
    cl1 o1 = new cl1();
    
    dlgt c = o1.cmtd;
    
    c().Dump();
    
    cl1 o2 = new cl1() { vrbl = 21 };
    
    dlgt d = o2.cmtd;
    
    d().Dump();
}

delegate int dlgt();

dlgt a = smtda;

static int smtda()
{
    return 15;
}

static int mtda()
{
    return 17;
}

class cl1
{
    public int vrbl = 19;
    public int cmtd() => vrbl;
}