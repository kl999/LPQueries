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
    z((IA)new D());
}

void z(IA l)
{
    $"IA {l.a()}".Dump();
}

void z(IB l)
{
    $"IB {l.a()}".Dump();
}

interface IA
{
    int a();
    
    bool c();
}

interface IB
{
    string a();
    
    bool c();
}

class D : IA, IB
{
    int IA.a() => 5;
    
    string IB.a() => "five";
    
    public bool c() => false;
}