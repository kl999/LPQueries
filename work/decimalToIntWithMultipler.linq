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
    int val = 0, mul = 0;
    decimal org = 17.353333m;
    
    countTariffAndMultipler(out val, out mul, org);
    
    $"for {org}: val = {val}, mul = {mul}".Dump();
}

public void countTariffAndMultipler(out int Val, out int Mul, decimal ValOrig)
{
    decimal mul = 1;
    for (; mul < 10000000; mul *= 10)
    {
        if (ValOrig % (1 / mul) == 0) break;
    }

    if (mul == 10000000) throw new Exception("More then 6 digits after the decimal point");

    if (mul < 1000)
    {
        Mul = -1;
        Val = (int)(ValOrig * 100);
    }
    else
    {
        Mul = (int)mul;
        Val = (int)(ValOrig * mul);
    }
}