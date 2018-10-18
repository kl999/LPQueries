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
    var o = new A
    {
        a =
        {
            1,
            2,
            3
        },
        b =
        {
            {5, "five"},
            {6, "is"},
            {7, "not four"}
        }
    };
    
    o.Dump();
    
    /*//compile time error
    List<int> o2 = new List<int>();
    
    o2 =
    {
        1, 2, 3
    };*/
}

class A
{
    public List<int> a {get;} = new List<int>();
    public B b {get;} = new B();
}

class B : IEnumerable<int>
{
    private List<int> vals = new List<int>();
    
    public List<string> defs = new List<string>();
    
    public IEnumerator<int> GetEnumerator() => vals.GetEnumerator();
    
    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)vals.GetEnumerator();
    
    public void Add(int val, string def)
    {
        vals.Add(val);
        defs.Add(def);
    }
}