<Query Kind="Program">
  <Namespace>Microsoft.Extensions.Configuration</Namespace>
  <Namespace>System.Text.Json</Namespace>
  <Namespace>System.Text.Json.Nodes</Namespace>
  <Namespace>System.Text.Json.Serialization</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

string aExpr = "1d6";
string bExpr = "2d3";
Random rand = new Random();

void Main()
{
	//Parse("2 * 2 + 1").Get().Dump();
	
	var aScore = 0;
	
	var a = Parse(aExpr);/*new OpVal(
		new AddOp(
			new RandVal(2, 6, rand),
			new Val(1)
		)
	);*/
	var b = Parse(bExpr);
	
	for(int i = 0; i < 100_000; i++)
	{
		var aRez = a.Execute();
		var bRez = b.Execute();
		
		//$"{aRez} > {bRez}".Dump();
		
		if(aRez > bRez)
			aScore++;
	}
	
	$"{(aScore / 100_000M) * 100:0.00} %".Dump();
}

IOp Parse(string expr)
{
	var val = @"(?:\d+|(?:\d+d\d+))";
	var op = @"(?:\+|-|\*|/)";
	
	if(Regex.IsMatch(expr, $"^{val}$"))
		return ParseVal(expr);
	
	var m = Regex.Match(expr, $@"^({val})\s?({op})\s?");
	
	if(!m.Success)
		throw new ApplicationException("Incorrect expression!");
	
	var left = ParseVal(m.Groups[1].Value);
	return ParseOp(
		m.Groups[2].Value,
		left,
		Parse(expr.Substring(m.Length))
	);
}

IOp ParseVal(string expr)
{
	var sub = expr.Split('d');
	
	return sub.Length switch {
		1 => new ValOp(Int32.Parse(sub[0])),
		2 => new RandOp(Int32.Parse(sub[0]), Int32.Parse(sub[1]), rand),
		_ => throw new ApplicationException("Incorrect expression!"),
	};
}

IOp ParseOp(string expr, IOp left, IOp right)
{
	return expr switch {
		"+" => new AddOp(left, right),
		"-" => new SubOp(left, right),
		"*" => new MulOp(left, right),
		"/" => new DivOp(left, right),
		_ => throw new ApplicationException("Incorrect expression!"),
	};
}

interface IOp
{
	int Execute();
}

class ValOp(int val) : IOp
{
	public int Execute() => val;
}

class RandOp(int ct, int max, Random rand) : IOp
{
	public int Execute() => Enumerable.Range(0, ct).Sum(i => rand.Next(max) + 1);
}

class AddOp(IOp left, IOp right) : IOp
{
	public int Execute() => left.Execute() + right.Execute();
}

class SubOp(IOp left, IOp right) : IOp
{
	public int Execute() => left.Execute() - right.Execute();
}

class MulOp(IOp left, IOp right) : IOp
{
	public int Execute() => left.Execute() * right.Execute();
}

class DivOp(IOp left, IOp right) : IOp
{
	public int Execute() => left.Execute() / right.Execute();
}
