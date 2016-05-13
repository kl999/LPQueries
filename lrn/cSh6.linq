<Query Kind="Program">
  <Namespace>static System.DayOfWeek</Namespace>
  <Namespace>static System.Math</Namespace>
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
    $"<Date in reverse: {DateTime.Now:ss:mm:HH yyyy.MM.dd}d>".Dump();
    
    var d = new Dictionary<string, int>()
    {
        ["a"] = 5,
        ["b"] = 6,
    }
    //.GetType()
    ;
    
    d.Dump();
    
    var a = new A();
    a.Dump();
    a.s = "zxc";
    a.lsp.Dump();
    a.lsm().Dump();
    a[50].Dump();
    a[2.0].Dump();
    
    Sqrt(4).Dump("Sqrt(4)");
    
    $"{Thursday + 1} mood".Dump();
    ((int)Friday).Dump();
    
    A nl = null;
    (nl?.z ?? -1).Dump();
    nl?.lsm().Dump();
    
    //string rez = String.Format("{5}&txn_id={1}&txn_date={3:yyyyMMddHHmmss}&{6}={0}&{4}={2:0.00}",0 paymentRequest.Parameters.Trim(), 1 paymentRequest.SystemId, 2 paymentRequest.Amount / 100.0, 3 paymentRequest.RequestDate, 4 amountName(cfg), 5 PaymentName(cfg), 6 AccountName(cfg));
    
    nameof(nl).Dump();
    
    try
    {
        if(a[10] > 20) throw new Exception("Hello!");
        throw new Exception("World!");
    }
    catch(Exception e) when(e.Message == "Hello!")
    {
        e.Message.Dump();
    }
    
    FormattableString fstr = $"asd{5.7} dt{DateTime.Now}";

    var fstr2 = $"qwerty{17.5}";
    fstr2.GetType().Dump();
    
    //FormattableString c = b;
    
    Console.WriteLine(fstr.ToString(System.Globalization.CultureInfo.InvariantCulture));
    Console.WriteLine(fstr.ToString(System.Globalization.CultureInfo.GetCultureInfo("ru-RU")));
}

class A
{
    public int z { get; set; } = 3;
    public int Zx2 { get; } = 6;

    public string s = "rty";
    
    public string lsp => "qwe" + s;
    public string lsm() => "vbn" + s;
    
    public int this[long id] => new int[id].Select(i => rand.Next(100)).Last();
    public int this[double id] => Enumerable.Range(20, 40).ToArray()[(int)id];
    
    private Random rand = new Random();
}