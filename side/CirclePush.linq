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
    var log = new LogLast(20);
    
    log.get().Dump("0");
    
    log = new LogLast(20);
    
    for(int i = 0; i < 3; i++)
        log.push(i.ToString());
    
    log.get().Dump("3");
    
    log = new LogLast(20);
    
    for(int i = 0; i < 21; i++)
        log.push(i.ToString());
    
    log.get().Dump("21");
    
    log = new LogLast(20);
    
    for(int i = 0; i < 23; i++)
        log.push(i.ToString());
    
    log.get().Dump("23");
    
    log = new LogLast(20);
    
    for(int i = 0; i < 40; i++)
        log.push(i.ToString());
    
    log.get().Dump("40");
}

class LogLast
{
    public int len = -1;

    public string[] vals = null;
    
    public int curPointer = 0;
    
    public LogLast(int _len)
    {
        len = _len;
        
        vals = new string[len];
    }
    
    public void push(string val)
    {
        vals[curPointer] = val;
        
        curPointer++;
        
        if(curPointer == len) curPointer = 0;
    }
    
    public string[] get()
    {
        if(curPointer == 0)
        {
            return vals.Where(i => i != null).ToArray();
        }
            
        var rez = new List<string>();
        
        if(vals[curPointer] != null)
            rez.Add(vals[curPointer]);
        
        for(int i = curPointer + 1; i != curPointer; i++)
        {
            //this.Dump(i.ToString());
            if(i == len) i = 0;
            
            if(vals[i] != null)
                rez.Add(vals[i]);
        }
        
        return rez.ToArray();
    }
}