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
    defValCl.defaultValKnown(3).Dump();
    defValCl.defaultValKnown(Encoding.UTF8).Dump();
    
    "\r\nAnd now from type!\r\n".Dump();
    
    ((int)defValCl.getDefValz(typeof(int))).Dump();
    ((Encoding)defValCl.getDefValz(typeof(Encoding))).Dump();
    
    string nstr = null;
    object obj = nstr;
    Encoding nenc = (Encoding)obj;
    
    string nstr2 = "Error!";
    object obj2 = nstr2;
    Encoding nenc2 = (Encoding)obj2;
}

class defValCl
{
    public static object getDefValz(Type t)
    {
        MethodInfo method = typeof(defValCl).GetMethod("defaultVal");
        MethodInfo generic = method.MakeGenericMethod(t);
        return generic.Invoke(null, null);
    }
    
    public static T defaultValKnown<T>(T a)
    {
        return default(T);
    }
    
    public static T defaultVal<T>()
    {
        return default(T);
    }
}