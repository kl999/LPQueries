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
    
    var scr = new DumpContainer();
    
    scr.Dump();
    
    scr.Content = "hello";
    
    var log = new DumpContainer();
    
    log.Dump();
    
    log.Content = "Log";
    
//    for(int i = 0; i < 100; i++)
//    {
//        Task.Delay(500).Wait();
//        
//        scr.Content = (i + " time");
//    }
    
    Ch pl = new Ch("pl");
    
    pl.a.Add(new Def(rand));
    
    pl.a.Add(new Att(rand));
    
    pl.a.Add(new Crsh(rand));
    
    Ch op = new Ch("op");
    
    op.a.Add(new Att(rand));
    
    op.a.Add(new Def(rand));
    
    op.a.Add(new Crsh(rand));
    
    for(;;)
    {
        string ts = "H: " + op.hl + " F: " + op.fcs
            + "\n\nH: " + pl.hl + " F: " + pl.fcs
            + "\n\n-------------------\n";
        
        for(int i = 0; i < pl.a.Count; i++)
        {
            ts += "\n" + i + ": " + pl.a[i].anm();
        }
        
        ts += "\n\n\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\n\n";
        
        scr.Content = ts;
        
        Task.Delay(500).Wait();
        
        int rez = 0;
        
        for(;;)
        {
            var m = Regex.Match(Console.ReadLine(), @"\d+");
            
            if(m.Success)
            {
                rez = Int32.Parse(m.Value);
                
                if(rez >= 0 && rez < pl.a.Count)
                {
                    break;
                }
                else
                {
                    log.Content = "Bad input";
                    
                    Task.Delay(1000).Wait();
                    
                    log.Content = "";
                }
            }
            else
            {
                log.Content = "Bad input";
                
                Task.Delay(1000).Wait();
                
                log.Content = "";
            }
        }
        
        log.Content = pl.a[rez].act(pl, op);
        
        Task.Delay(1000).Wait();
        
        log.Content = "";
        
        if(op.hl <= 0)
        {
            scr.Content = "Good!";
            
            break;
        }
        
        log.Content = op.a[rand.Next(op.a.Count)].act(op, pl);
        
        Task.Delay(1000).Wait();
        
        log.Content = "";
        
        pl.fcs = pl.fcs + 3 > 100 ? 100 : pl.fcs + 3;
        
        op.fcs = op.fcs + 3 > 100 ? 100 : op.fcs + 3;
        
        if(pl.hl <= 0)
        {
            scr.Content = "Bad!";
            
            break;
        }
    }
}

class Ch
{
    public string nm = "@nothing";
    
    public int hl = 100;
    
    public int fcs = 20;
    
    public List<Act> a = new List<Act>();
    
    public Ch(string _nm)
    {
        nm = _nm;
    }
}

interface Act
{
    string act(Ch me, Ch op);
    
    string anm();
}

class Att : Act
{
    Random rand;
    
    public Att(Random _rand)
    {
        rand = _rand;
    }
    
    public string anm()
    {
        return "att";
    }
    
    public string act(Ch me, Ch op)
    {
        string rs = me.nm + " att " + op.nm + " ";
        
        double chs = (double)op.fcs / 100;
        
        chs = chs * 0.9 + 0.05;
        
        if(rand.Next(101) > chs * 100)
        {
            op.hl -= 20;
            
            rs += "Ht! 20 dmg.";
        }
        else
        {
            rs += "Blk!";
        }
        
        me.fcs -= 5; me.fcs = me.fcs >= 0 ? me.fcs : 0;
        
        op.fcs -= 5; op.fcs = op.fcs >= 0 ? op.fcs : 0;
        
        return rs;
    }
}

class Def : Act
{
    Random rand;
    
    public Def(Random _rand)
    {
        rand = _rand;
    }
    
    public string anm()
    {
        return "def";
    }
    
    public string act(Ch me, Ch op)
    {
        string rs = me.nm + " def";
        
        me.fcs = me.fcs + 20 > 100 ? 100 : me.fcs + 20;
        
        return rs;
    }
}

class Crsh : Act
{
    Random rand;
    
    public Crsh(Random _rand)
    {
        rand = _rand;
    }
    
    public string anm()
    {
        return "crsh";
    }
    
    public string act(Ch me, Ch op)
    {
        string rs = me.nm + " crsh " + op.nm + " ";
        
        double chs = (double)op.fcs / 100;
        
        chs = chs * 0.9 + 0.05;
        
        chs *= 2;
        
        if(rand.Next(101) > chs * 100)
        {
            op.hl -= 40;
            
            rs += "Ht! 40 dmg.";
        }
        else
        {
            rs += "Blk!";
        }
        
        me.fcs -= 10; me.fcs = me.fcs >= 0 ? me.fcs : 0;
        
        op.fcs -= 30; op.fcs = op.fcs >= 0 ? op.fcs : 0;
        
        return rs;
    }
}