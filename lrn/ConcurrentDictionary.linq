<Query Kind="Statements">
  <Namespace>System.Collections.Concurrent</Namespace>
  <Namespace>System.Data.Linq.SqlClient</Namespace>
  <Namespace>System.Diagnostics</Namespace>
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

ConcurrentDictionary<long, string> cd = new ConcurrentDictionary<long, string>();

cd.AddOrUpdate(1, "hi", (key, oldValue) => "hi").Dump("fst Add");

cd.AddOrUpdate(1, "second", (key, oldValue) => oldValue).Dump("only Add");

try
{
    cd.AddOrUpdate(1, "third", (key, oldValue) =>
    {
        if(oldValue != "third")
            throw new Exception("diff zzz!!!");
        
        return "third";
    })
    .Dump("if diff exception");
}
catch(Exception ex)
{
    ex.Dump();
}

cd[1].Dump("get");

try
{
    cd[2].Dump();
}
catch(Exception ex)
{
    ex.Dump();
}

cd[1] = "forth";
cd[1].Dump("chg");

cd.TryRemove(1, out string ret).Dump("removed " + ret);
cd.TryRemove(1, out ret).Dump("removed " + ret);

cd.TryRemove(2, out string ret2).Dump("try remove " + (ret2 == ""));