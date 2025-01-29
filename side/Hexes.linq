<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var map = """
. . . 
 . . .
. . . 
 . . .
""".Replace("\r", "").Split('\n').Select(i => i.ToArray()).ToArray();
	Display(map);
}

private void Display(char[][] map)
{
	var display = new StringBuilder();
	for(int y = 0; y < map.Length; y++)
	{
		var top = "";
		var bottom = "";
		if(y % 2 == 1) top = bottom = "  ";
		
		for(int x = y % 2; x < map[0].Length; x += 2)
		{
			
			top    += $"{x}X  ";
			bottom += $"X{y}  ";
		}
		
		display.AppendLine(top);
		display.AppendLine(bottom);
	}
	
	Util.RawHtml($"<pre><code>{display.ToString()}</pre></code>").Dump();
}

private void DisplayMehh()
{
	var side = 10;
	
	var displSide = side * 2;
	
	var display = new StringBuilder();
	for(int yd = 0; yd < displSide; yd++)
	{
		for(int x = 0; x < side; x++)
		{
			var symbol = "XX";
			var y = yd / 2;
			
			if(yd % 2 == 0) symbol = $"{x}X";
			else symbol = $"X{y}";
			
			if(x % 2 != y % 2) symbol = "  ";
			
			display.Append(symbol);
		}
		
		display.AppendLine();
	}
	
	Util.RawHtml($"<pre><code>{display.ToString()}</pre></code>").Dump();
}
