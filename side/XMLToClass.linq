<Query Kind="Program">
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
	var str =
@"<TstCls>
  <ael>5</ael>
  <zxc>8</zxc>
  <qwe/>
  <str>Hello world!</str>
</TstCls>";
	
	XMLToClassStr.getClsStr(str).Dump();
}

class XMLToClassStr
{
	public static string getClsStr(string instr)
	{
		string rez = "",
			objname = "NoName",
			vars = "",
			parsestr = "",
			tostr = "";
		
		XElement xml = XElement.Parse(instr);
		
		objname = xml.Name.ToString();
		
		var chldrn = xml.Elements();
		
		foreach(var ch in chldrn)
		{
			var varname = getVarType(ch, ref parsestr, ref tostr);
			
			if(varname != "")
				vars += "public " + varname + ";\n";
		}
		
		rez += string.Format("public void parse(string str)\n{{\n{0}\n{1}}}\n\n",
@"XElement xml = XElement.Parse(str);

Match m;
string val = """";
",
		parsestr);
		
				rez += string.Format("public override string ToString()\n{{\n{0}\n{1}{2}\n}}\n\n",
@"XElement xml = new XElement(""" + objname + @""");
",
		tostr,
@"return xml.ToString();
");
		
		rez = String.Format("class {0}\n{{\n{1}\n{2}\n}}", objname, vars, rez);
		
		return rez;
	}
	
	static string getVarType(XElement el, ref string parsestr, ref string tostr)
	{
		var name = el.Name.ToString();
		
		if(el.Elements().Count() == 0 && !string.IsNullOrEmpty(el.Value))//.Elements().First().GetType() == typeof(XText))
		{
			var m = Regex.Match(el.Value, @"^\d+$");
			
			if(m.Success)
			{
				parsestr +=
@"val = xml.Element(""" + name + @""").Value;
m = Regex.Match(val, @""^\d+$"");
this." + name + @" = m.Success ? Int32.Parse(m.Value) : 0;

";
	
			tostr +=
@"xml.Add(new XElement (""" + name  + @""", " + name + @"));

";
				
				return "int " + name + " = 0";
			}
			else
			{
				parsestr +=
@"val = xml.Element(""" + name + @""").Value;
this." + name + @" = val;
	
";
	
			tostr +=
@"xml.Add(new XElement (""" + name  + @""", " + name + @"));

";
				
				return "string " + name + " = \"\"";
			}
		}
		else if(el.Elements().Count() == 0)
		{
			parsestr +=
@"val = xml.Element(""" + name + @""").Value;
this." + name + @" = val;
				
";
	
			tostr +=
@"xml.Add(new XElement (""" + name  + @""", " + name + @"));

";
	
			return "string " + name + " = null";
		}
		else
		{
			return "";
		}
	}
}