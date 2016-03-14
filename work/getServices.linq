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
	string[] lines = File.ReadAllLines(@"C:\sp\счета_2014_07_14.rpt");
	
	var colnames = ("account_id;account_name;ivoice_id;serv_id;serv_name;is_counter_serv;last_count;prev_count;quantity_count;"
	+ "tariff;calc_value;recalc_sum;peni_sum;debt_info;debt_sum;fix_sum").Split(';');
	
	List<Row> rez = new List<Row>();
	
	foreach(var ln in lines.Skip(1))
	{
		var sub = ln.Split(';');
		
		int code = Int32.Parse(sub[3]);
		
		if(rez.FirstOrDefault(i => i.code == code) != null)
			rez.First(i => i.code == code).ct++;
		else
		{
			rez.Add(new Row(){ code = code, desc = sub[4], example = string.Join("; ", sub.Select((i, ind) => colnames[ind] + "=" + i).ToArray()) });
		}
	}
	
	rez
	.OrderByDescending(i => i.ct)
	.Dump();
}

class Row
{
	public int code = 0;
	public string desc = "No";
	public long ct = 1;
	public string example = "";
}