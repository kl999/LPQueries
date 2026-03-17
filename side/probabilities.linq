<Query Kind="Program">
  <Namespace>Microsoft.Extensions.Configuration</Namespace>
  <Namespace>System.Text.Json</Namespace>
  <Namespace>System.Text.Json.Nodes</Namespace>
  <Namespace>System.Text.Json.Serialization</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

string aExpr = "1d6 + 3";
string bExpr = "2d3";
Random rand = new Random();

void Main()
{
	Parse("2 * (2 + 3) * 4")
		.Dump(includePrivate:true)
		.Execute()
		.Dump();
	
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
	var tokens = GetTokens(expr)
		.Dump()
		;
	
	return PrattParse(tokens, 0);
}

IOp PrattParse(List<(string v, int t)> tokens, int minPow)
{
	var token = Pop(tokens);
	IOp left;
	if (token.t == 2 && token.v == "(")
	{
		left = PrattParse(tokens, 1);
		if(!tokens.Any() || Pick(tokens).v != ")")
			throw new ApplicationException("Expected ')'!");
		Pop(tokens);
	}
	else if (token.t != 0)
		throw new ApplicationException($"Incorrect token! '{token.v}'");
	else
		left = ParseVal(token.v);
	
	for(;;)
	{
		if(!tokens.Any()) break;
		token = Pick(tokens);
		if (token.t == 2 && token.v == ")")
			return left;
		else if (token.t != 1)
			throw new ApplicationException($"Incorrect token! '{token.v}'");
		
		var pow = GetBindingPower(token.v);
		if(pow < minPow) break;
		
		Pop(tokens);
		
		left = ParseOp(token.v, left, PrattParse(tokens, pow));
	}
	
	return left;
}

(string v, int t) Pop(List<(string v, int t)> tokens)
{
	var result = tokens.First();
	tokens.RemoveAt(0);
	return result;
}

(string v, int t) Pick(List<(string v, int t)> tokens)
{
	return tokens.First();
}

int GetBindingPower(string token)
{
	return token switch
	{
		"+" => 10,
		"-" => 11,
		"*" => 20,
		"/" => 21,
		"(" => 1,
		")" => 0,
		_ => throw new ApplicationException($"Incorrect token! '{token}'"),
	};
}

List<(string v, int t)> GetTokens(string expr)
{
	var val = @"(?:(?:\d+d\d+)|\d+)";
	var op = @"(?:\+|-|\*|/)";
	var util = @"(?:\(|\))";
	
	var tokens = new List<(string v, int t)>();
	for(;;)
	{
		if (expr.Length == 0) break;
		
		var found = false;
		foreach((string, int) o in new[]{(val, 0), (op, 1), (util, 2)})
		{
			var (ptrn, type) = o;
			
			var m = Regex.Match(expr, $"^{ptrn}");
			if (m.Success)
			{
				tokens.Add((m.Value, type));
				expr = expr.Substring(m.Length).Trim();
				found = true;
				break;
			}
		}
		
		if(found) continue;
		
		throw new ApplicationException($"Wrong format! '{expr}'");
	}
	
	return tokens;
}

IOp ParseVal(string expr)
{
	var sub = expr.Split('d');
	
	return sub.Length switch
	{
		1 => new ValOp(Int32.Parse(sub[0])),
		2 => new RandOp(Int32.Parse(sub[0]), Int32.Parse(sub[1]), rand),
		_ => throw new ApplicationException($"Incorrect expression! '{expr}'"),
	};
}

IOp ParseOp(string expr, IOp left, IOp right)
{
	return expr switch
	{
		"+" => new AddOp(left, right),
		"-" => new SubOp(left, right),
		"*" => new MulOp(left, right),
		"/" => new DivOp(left, right),
		_ => throw new ApplicationException($"Incorrect expression! '{expr}'"),
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
