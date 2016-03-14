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
	var dc = new DumpContainer();
	
	dc.Dump();
	
	var pr = new Pr();
	
	dc.Content = pr.show();
	
	int wnr = -1;
	for(; (wnr = pr.turn()) == -1;) { dc.Content = pr.show(); }
	
	dc.Content = pr.show() + "Wins:" + (wnr == 3 ? "noone" : wnr.ToString());
	
	wnr.Dump();
}

class Pr
{
	static int sd = 3;
	
	byte[,] field = new byte[sd, sd];
	
	int ct = 0;
	
#warning ctor!
	Pl[] pls = new Pl[2] 
	{
		//new H(),
		new C(1),
		new H()
	};
	
	public string show()
	{
		string rez = "";
		
		for(int x = 0; x < sd; x++)
		{
			for(int y = 0; y < sd; y++)
			{
				rez += field[x, y] == 0 ? "." : field[x, y] == 1 ? "X" : "0";
			}
			rez += "\n";
		}
		
		return rez;
	}
	
	public int turn()
	{
		var mva = new Func<int, bool>(i =>
		{
			string mv = pls[i - 1].move(field);
			
			int x = mv[0] - 'a',
				y = mv[1] - '1';
			
			//(x + " " + y).Dump();
			
			try
			{
				field[x, y] = (byte)i;
			}
			catch(IndexOutOfRangeException)
			{
				return false;
			}
			
			ct++;
			
			return true;
		});
		
		if(ct % 2 == 0)
		{
			if(!mva(1)) return 3;
		}
		else
		{
			if(!mva(2)) return 3;
		}
		
		return chk(field);
	}
	
	public static int chk(byte[,] field)
	{
		for(int a = 0; a < sd; a++)
		{
			int x = field[a, 0], y = field[0, a];
			for(int b = 1; b < sd; b++)
			{
				if(x != 0 && field[a, b] != x)
					x = 0;
				if(y != 0 && field[b, a] != y)
					y = 0;
			}
			
			if(x != 0) return x;
			if(y != 0) return y;
		}
		
		{
			int x = field[0, 0], y = field[sd - 1, 0];
			for(int a = 1, b = 1; a < sd; a++, b++)
			{
				if(x != 0 && field[a, b] != x)
					x = 0;
				if(y != 0 && field[sd - a - 1, b] != y)
					y = 0;
			}
			
			if(x != 0) return x;
			if(y != 0) return y;
		}
		
		return -1;
	}
}








interface Pl
{
	string move(byte[,] field);
}

class H : Pl
{
	public string move(byte[,] field)
	{
		return Console.ReadLine();
	}
}

class C : Pl
{
	Random rand = new Random();
	
	public int align = 2;
	
	public C(int _align)
	{
		align = _align;
	}
	
	public string move(byte[,] field)
	{
		var br = new Branch(field, -1, -1, (byte)(align == 1 ? 2 : 1));
		
		int moverezx = -1;
		int moverezy = -1;
		
		List<Branch> wins = new List<Branch>();
		List<Branch> draws = new List<Branch>();
		
		foreach(var sub in br.sub)
		{
			if((sub.comput = recursion(sub, align)) == align)
			{
				wins.Add(sub);
			}
			else if(sub.comput == -1)
			{
				draws.Add(sub);
			}
		}
		
		//br.Dump(); throw new Exception("Show me!");
		
		if(wins.Count() > 0)
		{
			int rch = rand.Next(wins.Count() - 1);
			moverezx = wins[rch].px;
			moverezy = wins[rch].py;
			
			return "" + (char)('a' + moverezx) + (char)('1' + moverezy);
		}
		else if(draws.Count() > 0)
		{
			int rch = rand.Next(draws.Count() - 1);
			moverezx = draws[rch].px;
			moverezy = draws[rch].py;
			
			return "" + (char)('a' + moverezx) + (char)('1' + moverezy);
		}
		
		return "" + ((char)('a' - 1)) + "0";
	}
	
	int recursion(Branch fbr, int al)
	{
		//int rez = -1;
		
		if(fbr.win != -1)
			return fbr.win;
		
		List<int> rezs = new List<int>();
		
		foreach(var sub in fbr.sub)
		{
			/*int tmp = recursion(sub, al);
			
			rez = tmp;
			
			if(tmp != -1)
			{
				if(tmp == al && sub.bral == al)
				{
					rez = tmp;
					break;
				}
				
				if(tmp != al && sub.bral != al)
				{
					rez = tmp;
					break;
				}
			}*/
			
			rezs.Add(sub.comput = recursion(sub, al));
		}
		
		if(rezs.Count() == 0) return fbr.win;
		
		if((fbr.bral == 1 ? 2 : 1) == al)
		{
			if(rezs.Contains(al)) return al;
			else if(rezs.Contains(-1)) return -1;
			else return (al == 1 ? 2 : 1);
		}
		else
		{
			if(rezs.Contains((al == 1 ? 2 : 1))) return (al == 1 ? 2 : 1);
			else if(rezs.Contains(-1)) return -1;
			else return al;
		}
		
		//return rez;
	}
	
	class Branch
	{
		public List<Branch> sub = new List<Branch>();
		
		public int comput = 0;
		
		public byte[,] fld = null;
		
		public int win = -1,
		px = -1, py = -1,
		bral = -1;
		
		public Branch(byte[,] field, int _x, int _y, byte align)
		{
			//field.Dump();
			
			//align.Dump();
			
			px = _x;
			py = _y;
			
			bral = align;
			
			int wn = Pr.chk(field);
			
			int sd = field.GetLength(0);
			
			fld = copyArr(field, sd);
			
			if(wn != -1)
			{
				win = wn;
				return;
			}
			
			for(int x = 0; x < sd; x++)
			{
				for(int y = 0; y < sd; y++)
				{
					if(field[x, y] == 0)
					{
						var tmp = copyArr(field, sd);
						
						tmp[x, y] = (byte)(align == 1 ? 2 : 1);
						
						sub.Add(new Branch(tmp, x, y, (byte)(align == 1 ? 2 : 1)));
					}
				}
			}
		}
		
		byte[,] copyArr(byte[,] arr, int sd)
		{
			var rez = new byte[sd, sd];
			
			for(int x = 0; x < sd; x++)
			{
				for(int y = 0; y < sd; y++)
				{
					rez[x, y] = arr[x, y];
				}
			}
			
			return rez;
		}
	}
}