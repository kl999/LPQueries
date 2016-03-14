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
	string file = @"
[first arg]
	first_field 1
	second_field Hello
	flag

-asd
[/first arg]
dsadaasd






aervb



[secondArg]
	first_field 2
	second_field Hi
[/secondArg]

[noFields]
asdfg
*****
4289766
*****
qwerty
[/noFields]

[one]

fieldOfOne Hello!

	[two]
	
	fieldOfTwo World
	
		[three]
			of paranoia
		[/three]
	
	[/two]

[/one]
";

	string file2 = @"
[first arg]
first_field 1
second_field Hello
flag";

file2.Split('\n');
	
	/*List<SimpleLoad.Obj> tList = SimpleLoad.getObjects(file);
	
	foreach(SimpleLoad.Obj o in tList)
	{
		o.breakToFields();
	}
	
	tList.Dump();*/
	
	SimpleLoad.getObjects(file).Dump(1000);
	
	var saveMe = new List<SimpleLoad.Obj>();
	
	saveMe.Add(
		new SimpleLoad.Obj("Hello") { fields = new[] { new SimpleLoad.Field("F1", "World") } }
		);
	
	saveMe.Add(
		new SimpleLoad.Obj("In") { fields = new[] { new SimpleLoad.Field("Field", "Val") } }
		);
	
	saveMe[1].objs = new[]
		{
			new SimpleLoad.Obj("Level1") 
				{ fields = new[] { new SimpleLoad.Field("FL1", "Ok I`m in") } }
		};
	
	saveMe.Dump("orig", 1000);
	
	string str = SimpleLoad.objsToText(saveMe).Dump("objsToText");
	
	SimpleLoad.getObjects(str).Dump("rez", 1000);
}

static class SimpleLoad
{
	public static List<Obj> getObjects(string loaded, bool getFields = true)
	{
		string[] lines = loaded.Split('\n');
		
		return getObjects(lines, getFields);
	}
	
	public static List<Obj> getObjects(string[] lines, bool getFields = true)
	{
		List<Obj> rez = new List<Obj>();
		
		for(int i = 0; i < lines.Length; i++)
		{
			string tstr = lines[i].Trim();
			
			Match m = Regex.Match(tstr, @"(?<=^\[).+(?=\]$)");
			
			//m.Dump();
			
			if(m.Success)
			{
				i = linesInObj(lines, m.Value, i, getFields, rez);
			}
		}
		
		return rez;
	}
	
	static int linesInObj(string[] lines, string name, int i, bool getFields, List<Obj> rez)
	{
		List<Obj> objs = new List<Obj>();
		
		Obj ldtObj = new Obj(name);
		
		i++;
		
		List<string> objLines = new List<string>();
		
		for(; ; i++)
		{
			if(i >= lines.Length)
				throw new Exception("Bad file");
			
			string tstr2 = lines[i].Trim();
			
			if(Regex.IsMatch(tstr2, @"(?<=^\[/)" + ldtObj.name + @"(?=\]$)"))
			{
				break;
			}
			
			Match m = Regex.Match(tstr2, @"(?<=^\[).+(?=\]$)");
			
			if(m.Success)
			{
				//m.Value.Dump();
				
				i = linesInObj(lines, m.Value, i, getFields, objs);
			}
			else
				objLines.Add(tstr2);
		}
		
		ldtObj.objs = objs.ToArray();
		
		ldtObj.lines = objLines.ToArray();
		
		if(getFields)
			ldtObj.breakToFields();
		
		rez.Add(ldtObj);
		
		return i;
	}
	
	public static string objsToText(IEnumerable<Obj> objs)
	{
		string rez = "";
		
		foreach(var o in objs)
		{
			rez += objToText(o);
		}
		
		rez = rez.Remove(rez.Length - 2, 2);
		
		return rez;
	}
	
	private static string objToText(Obj o)
	{
		string rez = "";
		
		rez += "[" + o.name + "]\n\n";
		
		foreach(var f in o.fields)
		{
			rez += f.name;
			
			if(f.value != null)
				rez += " " + f.value;
			
			rez += "\n";
		}
		
		if(o.objs != null && o.objs.Length > 0)
		{
			rez += "\n";
			
			string tmp = "";
			
			foreach(var o2 in o.objs)
			{
				tmp += objToText(o2);
			}
		
			tmp = tmp.Remove(tmp.Length - 2, 2);
			
			tmp = "\t" + tmp.Replace("\n", "\n\t");
			
			rez += tmp;
			
			rez = rez.Remove(rez.Length - 1, 1);
		}
		
		rez += "\n[/" + o.name + "]\n\n\n";
		
		return rez;
	}
	
	public class Obj
	{
		public string name;
		
		public string[] lines;
		
		public Field[] fields;
		
		public Obj[] objs;
		
		public Obj(string _name, string[] _lines = null)
		{
			name = _name;
			
			lines = _lines;
			
			objs = null;
		}
		
		public int breakToFields()
		{
			List<Field> tlist = new List<Field>();
			
			foreach(string tstr in lines)
			{
				Match m;
				
				m = Regex.Match(tstr, @"^\w+$");
				
				if(m.Success)
				{
					tlist.Add(new Field(m.Value, null));
				}
				
				m = Regex.Match(tstr, @"^\w+(?=\s)");
				
				if(m.Success)
				{
					tlist.Add(new Field(m.Value, Regex.Match(tstr, @"(?<=^\w+\s).*").Value));
				}
			}
			
			fields = tlist.ToArray();
			
			return tlist.Count;
		}
	}
	
	public class Field
	{
		public string name;
		
		public string value;
		
		public Field(string _name, string _value)
		{
			name = _name;
			value = _value;
		}
	}
}