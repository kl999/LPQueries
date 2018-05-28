<Query Kind="Statements">
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

double a = 1d, b = 0;

var dc = new DumpContainer();
var dc2 = new DumpContainer();

dc.Dump();
dc2.Dump();

for(;b <= 2;)
{
    a = a * 2;
    
    a = a / 3;
    
    b += a;
    
    dc.Content = a;
    
    dc2.Content = b;
    
    Thread.Sleep(1000);
}