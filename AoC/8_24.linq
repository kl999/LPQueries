<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var result1 = 0;
	var result2 = 0;
	
	var pairs = new Dictionary<char, List<(int x, int y)>>();
	
	for(var x = 0; x < input[0].Length; x++)
	for(var y = 0; y < input.Length; y++)
	{
		var obj = input[y][x];
		if(obj != '.')
		{
			if(!pairs.ContainsKey(obj))
				pairs[obj] = new List<(int, int)>();
			
			pairs[obj].Add((x, y));
		}
	}
	
	//pairs.Dump();
	
	var inputCopy1 = input.Select(i => i.ToArray()).ToArray();
	var inputCopy2 = input.Select(i => i.ToArray()).ToArray();
	
	foreach(var pairsForObj in pairs)
	{
		var coords = pairsForObj.Value;
		
		for(int march = 0, cur = 1; march < coords.Count - 1;)
		{
			FillPoints1(coords[march], coords[cur], inputCopy1);
			FillPoints2(coords[march], coords[cur], inputCopy2);
			
			cur++;
			if(cur == coords.Count)
			{
				march++;
				cur = march + 1;
			}
		}
	}
	
	//Util.RawHtml($"<pre><code>{Reconstruct(inputCopy1)}</code></pre>").Dump("End1");
	
	for(var x = 0; x < input[0].Length; x++)
	for(var y = 0; y < input.Length; y++)
	{
		if(inputCopy1[y][x] == '#')
		{
			result1++;
		}
		if(inputCopy2[y][x] != '.')
		{
			result2++;
		}
	}
	
	Util.RawHtml($"<pre><code>{Reconstruct(inputCopy2)}</code></pre>").Dump("End");
	
	result1.Dump("Part one");
	result2.Dump("Part two");
}

void FillPoints2((int x, int y) from, (int x, int y) to, char[][] input)
{
	var lengthx = Math.Abs(from.x - to.x);
	var lengthy = Math.Abs(from.y - to.y);
	
	if(from.x > to.x)
		(to, from) = (from, to);
	
	//(from, to, lengthx, lengthy).Dump();
	
	if(from.y < to.y)
	{
		var cur = from;
		for(;;)
		{
			//"A".Dump();
			var beg = (x: cur.x - lengthx, y: cur.y - lengthy);
			
			//beg.Dump();
			
			if(beg.x >= 0 && beg.y >= 0)
				input[beg.y][beg.x] = '#';
			else
				break;
			
			cur = beg;
		}
		
		cur = to;
		for(;;)
		{
			var end = (x: cur.x + lengthx, y: cur.y + lengthy);
			
			//end.Dump();
			
			if(end.x < input[0].Length && end.y < input.Length)
				input[end.y][end.x] = '#';
			else
				break;
			
			cur = end;
		}
	}
	else
	{
		//"B".Dump();

		var cur = from;
		for(;;)
		{
			//$"{from.x - lengthx >= 0 && to.y + lengthy < input.Length}, {to.x + lengthx < input[0].Length}{to.y - lengthy >= 0}".Dump();
			var beg = (x: cur.x - lengthx, y: cur.y + lengthy);
			
			//beg.Dump();
			
			if(beg.x >= 0 && beg.y < input.Length)
				input[beg.y][beg.x] = '#';
			else
				break;
			
			cur = beg;
		}
		
		cur = to;
		for(;;)
		{
			var end = (x: cur.x + lengthx, y: cur.y - lengthy);
			
			//end.Dump();
			
			if(end.x < input[0].Length && end.y >= 0)
				input[end.y][end.x] = '#';
			else
				break;
			
			cur = end;
		}
	}
	
	//Util.RawHtml($"<pre><code>{Reconstruct(input)}</code></pre>").Dump();
}

void FillPoints1((int x, int y) from, (int x, int y) to, char[][] input)
{
	var lengthx = Math.Abs(from.x - to.x);
	var lengthy = Math.Abs(from.y - to.y);
	
	if(from.x > to.x)
		(to, from) = (from, to);
	
	//(from, to, lengthx, lengthy).Dump();
	
	if(from.y < to.y)
	{
		//"A".Dump();
		var beg = (x: from.x - lengthx, y: from.y - lengthy);
		var end = (x: to.x + lengthx, y: to.y + lengthy);
		
		//beg.Dump();
		//end.Dump();
		
		if(beg.x >= 0 && beg.y >= 0)
			input[beg.y][beg.x] = '#';
		if(end.x < input[0].Length && end.y < input.Length)
			input[end.y][end.x] = '#';
	}
	else
	{
		//"B".Dump();
		//$"{from.x - lengthx >= 0 && to.y + lengthy < input.Length}, {to.x + lengthx < input[0].Length}{to.y - lengthy >= 0}".Dump();
		var beg = (x: from.x - lengthx, y: from.y + lengthy);
		var end = (x: to.x + lengthx, y: to.y - lengthy);
		
		//beg.Dump();
		//end.Dump();
		
		if(beg.x >= 0 && beg.y < input.Length)
			input[beg.y][beg.x] = '#';
		if(end.x < input[0].Length && end.y >= 0)
			input[end.y][end.x] = '#';
	}
	
	//Util.RawHtml($"<pre><code>{Reconstruct(input)}</code></pre>").Dump();
}

char[][] input1 = 
"""
......
......
......
......
.11...
11....
""".Replace("\r", "").Split('\n')
.Select(i => i.ToArray())
.ToArray();

char[][] input2 = 
"""
............
........0...
.....0......
.......0....
....0.......
......A.....
............
............
........A...
.........A..
............
............
""".Replace("\r", "").Split('\n')
.Select(i => i.ToArray())
.ToArray();

char[][] input = @"..........1.............TE........................
....................................R.............
..................................................
.......................j.....Q....................
...................A................8.............
...........................s.......9...........k..
q.E..............6...............1R.w.........k...
..6...E..............1.........R...............t..
.....r.Q......6........Re..T..............9.......
.............................T........9...........
...............................................wv.
.P............A..................8.v....s.k.......
.q..................A......k.........8............
..........o.....1.....W..H............8.......w...
..Q........P.........O.........e...N.W............
P................z.........o.............N.......w
..............o.....p..........Z.s..........N.....
.....O.x......K.....................v..aN.........
..O...............U.....H.......t.................
.E.......q...6.....i..............................
..............z..........o...i...........aW.......
....O........r.............e.....Wt...............
...............U.7i........H......h........t......
......Q.......n..2...I...A....i.p.................
...........2...9n.................s........j......
..q................Ur..........p..................
.............n.................K..................
.....S....z.........I.....H.............e.j.......
..................7..prD..K...d...................
S.........V.....7....K............................
......................................0...........
..................................................
..................2..........I....j.Z.............
....................X.............J..Z....a.......
........SX............................x......0J...
................U....n........x...............0...
.........S......X................x....a...........
...5.......X.......................02.............
...............V.........................d...J....
.............................u.......4............
.....5...........................u.4..............
....5.............................................
......V................................3..........
......D..........................................d
....D.................................4...........
.....h....................................d7......
..............................P...................
.........D......h........3................u...4...
.............h..5.....3...........u.....I.........
..........3......V.............................J..".Replace("\r", "").Split('\n')
.Select(i => i.ToArray())
.ToArray();

string Reconstruct(char[][] map) => String.Join('\n', map.Select(i => new String(i)));
