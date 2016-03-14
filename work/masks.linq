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
	Characters chs;
	
	chs = new Characters();
	
	Masks masks = new Masks(File.ReadAllText(@"C:\sp\template picts\masks.txt"), chs);
	
	string numstr = "KMZ23S8ET01";//"AZ32EUP";//"2B7ASD0S";//"A6B45X2";
	
	/*string mask = "A111AAA";
	
	masks.isMaskOf(numstr, mask).Dump("Is mask of");*/
	
	masks.findMask(numstr).Dump("Find mask");
	
	var sw = new Stopwatch();
	sw.Restart();
	for(int i = 0; i < 1000; i++)
		masks.findMask(numstr);
	sw.Stop();
	sw.Dump("1 000 times");
}



class Masks
{
	private Characters chs;
	
	private string[] masks;
	
	public Masks(string loaded, Characters _chs)
	{
		chs = _chs;
		
		List<SimpleLoad.Obj> tmp = SimpleLoad.getObjects(loaded);
		
		masks = tmp
		.Where(i => i.name == "mask")
		.Select(i =>
		{
		return i.fields.FirstOrDefault(o => o.name == "mask").value;
		})
		.ToArray();
	}
	
	public string findMask(string numstr)
	{
		foreach (string mask in masks)
		{
		string tmp = isMaskOf(numstr, mask);
		
		if (tmp != "") return tmp;
		}
		
		return "";
	}
	
	public string isMaskOf(string numstr, string mask)
	{
		if (numstr.Length != mask.Length)
			return "";
		
		string strmask = "";
		
		for (int i = 0; i < numstr.Length; i++)
		{
			if (numstr[i] != '*')
			{
				Character ch = chs.character(numstr[i]);
				
				if ((ch.kind & Character.Kind.number) != 0)
				{
					strmask += "1";
				}
				else if ((ch.kind & Character.Kind.letter) != 0)
				{
					strmask += "A";
				}
			}
			else
			{
				strmask += "*";
			}
		}
		
		if (mask == strmask)
			return numstr;
		
		return samed(strmask, mask, numstr);
	}
	
	private string samed(string strmask, string mask, string numstr)
	{
		string strdmask = "";
		
		for (int i = 0; i < numstr.Length; i++)
		{
			if (numstr[i] != '*')
			{
				Character ch = chs.character(numstr[i]);
				
				if ((ch.kind & Character.Kind.dangerous) != 0)
				{
					strdmask += "D";
				}
				else
				{
					strdmask += strmask[i];
				}
			}
			else
			{
				strdmask += "*";
			}
		}
		
		string tmp = "";
		
		for (int i = 0; i < mask.Length; i++)
		{
			if(mask[i] != '*')
			{
				if (mask[i] != strmask[i])
				{
					if (strmask[i] != '*')
					{
						if (strdmask[i] != 'D')
						{
							return "";
						}
						else
						{
							tmp += chs.pair(numstr[i]);
						}
					}
					else
					{
						tmp += '*';
					}
				}
				else
				{
					tmp += numstr[i];
				}
			}
		}
		
		if (tmp.Where(i => i != '*').Count() > 3)
			return tmp;
		else
			return "";
	}
}

class Characters
{
	private List<Character> chars = new List<Character>();
	
	public Characters()
	{
		load();
	}
	
	private void load()
	{
		string[] buf = File.ReadAllLines(@"C:\sp\template picts\chars.txt");
		
		//buf.Dump();
		
		for(int i = 0; i < buf.Length; i++)
		{
			if(Regex.Match(buf[i], @"\[ch\]").Success)
			{
				i++;
				
				char tch = ' ';
				
				char tpair = ' ';
				
				Character.Kind tkind = 0;
				
				for(; ; i++)
				{
					Match m;
					
					if(i >= buf.Length) throw new Exception("Bad file");
					else if(Regex.Match(buf[i], @"\[/ch\]").Success) break;
					
					m = Regex.Match(buf[i], @"(?<=^char\s).$");
					
					if(m.Success)
					{
						tch = m.Value[0];
					}
					
					m = Regex.Match(buf[i], @"(?<=^kind\s)\w+$");
					
					if(m.Success)
					{
						switch(m.Value)
						{
							case "letter" :
							{
								tkind = Character.Kind.letter;
								break;
							}
							
							case "number" :
							{
								tkind = Character.Kind.number;
								break;
							}
						}
					}
				
					m = Regex.Match(buf[i], @"(?<=^pair\s).$");
						
					if(m.Success)
					{
						tpair = m.Value[0];
					}
				}
				
				if(tpair != ' ')
				{
					tkind |= Character.Kind.dangerous;
				}
				
				chars.Add(new Character(tch, tkind, tpair));
			}
		}
		
		//chars.Dump();
	}
	
	public bool isPair(char ch1, char ch2)
	{
		Character o = chars.FirstOrDefault(i => i.ch == ch1);
		
		if(o != null)
		{
			if(o.pair == ch2)
				return true;
		}
		
		return false;
	}
	
	public char pair(char ch)
	{
		Character o = chars.FirstOrDefault(i => i.ch == ch);
		
		return o.pair;//chars.FirstOrDefault(i => i.ch == o.pair).ch;
	}
	
	public Character character(char ch)
	{
		return chars.FirstOrDefault(i => i.ch == ch);
	}
}

class Character
{
	public Kind kind { get; private set; }
	
	public char ch = ' ';
	
	public char pair = ' ';
	
	public Character(char _ch, Kind _kind, char _pair)
	{
		ch = _ch;
		kind = _kind;
		pair = _pair;
	}
	
	public enum Kind
	{
		letter = 1,
		number = 2,
		dangerous = 4,
		dangerousLetter = dangerous | letter,
		dangerousNumber = dangerous | number
	}
}