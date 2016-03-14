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
	var chs = new Characters();
	
	char ch1 = 'Z',
		 ch2 = '2';
		 
	bool rez = false;
	var sw = new Stopwatch();
	sw.Restart();
	
	for(int i = 0; i < 1000; i++)
	rez = chs.isPair(ch1, ch2);
	
	sw.Stop();
	sw.Dump();
	
	rez.Dump("Is [" + ch1 + "] pair of [" + ch2 + "]");
	
	chs.pair('B').Dump();
	
	chs.character('A').Dump();
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
		
		chars.Dump();
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