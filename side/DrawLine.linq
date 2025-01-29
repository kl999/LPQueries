<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

using static System.Math;

var tests = new (int x, int y)[][]
{
	new[]{(1,1), (10, 10)},
	new[]{(1,1), (10, 1)},
	new[]{(1,1), (1, 10)},
	new[]{(1,1), (10, 3)},
	new[]{(1,1), (3, 10)},
	new[]{(5,5), (3, 35)},
};

foreach(var points in tests)
{
	var a = points[0];
	var b = points[1];
	
	$"A: {a}, B: {b}".Dump();

	var side = new[]{ a.x, a.y, b.x, b.y }.Max() + 5;
	var result = new StringBuilder(side * side);

	var coords = lineCoords(a, b);
	//coords.Dump();

	for(int y = 0; y < side; y++)
	{
		for(int x = 0; x < side; x++)
		{
			var symbol = ".";
			
			if(coords.Any(i => i.x == x && i.y == y)) symbol = "#";
			
			if(a.x == x && a.y == y) symbol = "A";
			if(b.x == x && b.y == y) symbol = "B";
			
			result.Append(symbol);
		}
		
		result.AppendLine();
	}

	Util.RawHtml($"<pre><code>{result.ToString()}</pre></code>").Dump();
}

(int x, int y)[] lineCoords((int x, int y) from, (int x, int y) to)
{
	var result = new List<(int x, int y)>();
	
	if(to.x < from.x) (to, from) = (from, to);
	
	var xlen = to.x - from.x;
	var ylen = to.y - from.y;
	
	if(xlen > ylen && ylen >= 0)
	{
		var ratio = (decimal)ylen / xlen;
		
		for(var i = 0; i < xlen; i++)
		{
			result.Add((from.x + i, from.y + (int)Round(i * ratio)));
		}
	}
	else if(ylen > 0)
	{
		var ratio = (decimal)xlen / ylen;
		
		for(var i = 0; i < ylen; i++)
		{
			result.Add((from.x + (int)Round(i * ratio), from.y + i));
		}
	}
	else
	{
		var ratio = (decimal)xlen / ylen;
		
		for(var i = 0; i > ylen; i--)
		{
			result.Add((from.x + (int)Round(i * ratio), from.y + i));
		}
	}
	
	return result.ToArray();
}
