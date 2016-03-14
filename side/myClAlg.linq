<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
    Random rand = new Random();
    
    int[] arr = new int[100];
    
    int trueClCt = 3 + rand.Next(3);
    
    arr = arr
        .Select(i => rand.Next(trueClCt) * 1000 - 100 + rand.Next(200))
        //.Select(i => rand.Next(50) * 100 + rand.Next(100))
        .ToArray();
    
    var rez = findClusters(arr, (i, j) => Math.Abs(i - j) < 200);
    
    trueClCt.Dump("true Cl Ct");
    
    foreach(var cl in rez.OrderBy(i => i.start))
    {
        ((cl.end / 1000) * 1000).Dump("Name");
        
        cl.body = cl.body.OrderBy(i => i).ToList();
        
        cl.Dump();
    }
}

List<Cluster> findClusters(int[] arr, Func<int, int, bool> f)
{
    if(arr.Length == 0)
        return null;
    
    List<Cluster> rez = new List<Cluster>();
    
    for(int i = 0; i < arr.Length; i++)
    {
        int found = 0;
        
        foreach(var cl in rez)
        {
            if(!cl.delete)
            {
                found = cl.fromCl(arr[i], f);
                
                if(found > 0)
                {
                    if(found > 1)
                    {
                        foreach(var cl2 in rez)
                        {
                            if(cl2 != cl) if(!cl2.delete) cl.united(cl2, f);
                        }
                    }
                    break;
                }
            }
        }
        
        if(found == 0)
        {
            rez.Add(new Cluster(arr[i]));
        }
        
        rez = rez.Where(o => !o.delete).ToList();
        
        //Util.HorizontalRun (true, arr[i], rez).Dump();
    }
    
    return rez;
}

class Cluster
{
    public int start;
    
    public int end;
    
    public List<int> body = new List<int>();
    
    public bool delete = false;
    
    public Cluster(int firstMember)
    {
        start = firstMember;
        end = firstMember;
        
        body.Add(firstMember);
    }
    
    public int fromCl(int q, Func<int, int, bool> f)
    {
        if(q >= start
            && q <= end)
        {
            body.Add(q);
            return 1;
        }
        else if(f(start, q) || f(end, q))
        {
            if(q < start)
            {
                start = q;
                body.Add(q);
            }
            else if(q > end)
            {
                end = q;
                body.Add(q);
            }
            else
                throw new Exception("Unexpected");
            return 2;
        }
        else
        {
            return 0;
        }
    }
    
    public void united(Cluster cl2, Func<int, int, bool> f)
    {
        if(f(start, cl2.end))
        {
            start = cl2.start;
            
            body.AddRange(cl2.body);
            
            cl2.delete = true;
            
            return;
        }
        else if(f(end, cl2.start))
        {
            end = cl2.end;
            
            body.AddRange(cl2.body);
            
            cl2.delete = true;
            
            return;
        }
    }
}