<Query Kind="Statements">
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

var dta = new int[10000].Select(i => new{ a = 1, b = "2", c = 3, d = 5, e = "qwertu" }) as IEnumerable<dynamic>;

var fst = dta.FirstOrDefault();

if (fst != null)
{
    var type = fst.GetType() as Type;
    var mmbrs = type.GetProperties();

    foreach (var item in dta)
    {
        "----------------".Dump();
        Console.Write("|");
        
        for (int i = 0; i < mmbrs.Length; i++)
        {
            Console.Write(mmbrs[i].GetValue(item, null).ToString() + "|");
        }
        "".Dump();
    }
}

"----------------".Dump();