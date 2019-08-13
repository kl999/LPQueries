<Query Kind="Program">
  <Namespace>LINQPad.Controls</Namespace>
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

long N = 27;

void Main()
{
    long num = 14586375129;
    
    numN(num).Dump();
}

long numN(long num)
{
    long rez = 0;
    long tnum = num;
    
    for(;tnum > 0;)
    {
        rez += tnum % N;
        
        tnum = tnum / N;
    }
    
    if(rez / N == 0)
        return rez;
    else
        return numN(rez);
}