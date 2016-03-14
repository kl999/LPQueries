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
    var dc = new DumpContainer();
    dc.Dump();
    var curDc = new DumpContainer();
    curDc.Dump();
    curDc.Content = 1;
    
    long len = 10000;
    long[] arr = new long[len];
    arr[0] = 2;
    
    for(long i = 2, cur = 1; arr[len - 1] == 0; i++)
    {
        if(i % 1000 == 0) dc.Content = i;
        
        bool found = false;
        for(long o = 0; o < cur; o++)
        {
            if(i % arr[o] == 0)
            {
                found = true;
                break;
            }
        }
        
        if(!found)
        {
            arr[cur] = i;
            cur++;
            curDc.Content = cur;
            //arr.Dump();
        }
    }
    
    //arr.Dump("Rez");
    
    var myPrimes = new List<long>();
    myPrimes.Add(2);
    var forEyes = new List<string>();
    forEyes.Add("Start");
    
    bool swtch = true;
    int cur2 = 0;
    for(;;)
    {
        if(myPrimes.Last() == arr[len - 1]) break;
        
        dc.Content = myPrimes[cur2];
        curDc.Content = cur2;
        
        if(swtch)
        {
            myPrimes.Add(myPrimes[cur2] * 2 - 1);
            forEyes.Add(myPrimes[cur2].ToString() + "*2-1");
            
            swtch = !swtch;
        }
        else
        {
            if(myPrimes[cur2] != 2){
            myPrimes.Add(myPrimes[cur2] * 2 + 1);
            forEyes.Add(myPrimes[cur2].ToString() + "*2+1");}
            
            cur2++;
            //if(cur2 == 1) cur2++;
            
            swtch = !swtch;
        }
    }
    
    var mpstrl = myPrimes.Select(i => i.ToString()).ToList();
    int maxlen = mpstrl.Select(i => i.Length).OrderByDescending(i => i).First() + 4;
    
    using(var wrtr = new StreamWriter(@"c:\sp\SPTh.bat", false, Encoding.UTF8))
    {
        for(int i = 0; i < mpstrl.Count; i++)
        {
            bool isPrime = arr.Contains(myPrimes[i]);
            
            string z = ((isPrime ? "" : "=>") + mpstrl[i]).PadRight(maxlen);
            
            wrtr
            //Console
            .WriteLine(z + forEyes[i].PadRight(10) + (isPrime ? "" : getDivs(arr, myPrimes[i], "")));
        }
    }
    
    foreach(var num in arr.Skip(1))
    {
        if(!myPrimes.Contains(num))
        {
            ("Bad " + num).Dump();
            break;
        }
    }
}

string getDivs(long[] prms, long num, string prev)
{
    foreach(var p in prms)
    {
        if(num % p == 0)
            if(num / p == 1)
            {
                return prev + (prev == "" ? "" : "*") + p;
            }
            else
            {
                return getDivs(prms, num / p, prev + (prev == "" ? "" : "*") + p);
            }
    }
    
    return "Error!!!";
}