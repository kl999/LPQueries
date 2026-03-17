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
	Parse("1d10 - (1 + 3)")
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

IOp PrattParse(Queue<Token> tokens, int minPow)
{
	var token = tokens.Dequeue();
	IOp left;
	if (token.Type == TokenType.Utility && token.Value == Tokens.BraceOpen)
	{
		left = PrattParse(tokens, 1);
		if(!tokens.Any() || tokens.Peek().Value != Tokens.BraceClose)
			throw new ApplicationException("Expected ')'!");
		tokens.Dequeue();
	}
	else if (token.Type != TokenType.Value)
		throw new ApplicationException($"Incorrect token! '{token.Raw}'");
	else
		left = ParseVal(token);
	
	for(;;)
	{
		if(!tokens.Any()) break;
		token = tokens.Peek();
		if (token.Type == TokenType.Utility && token.Value == Tokens.BraceClose)
			return left;
		else if (token.Type != TokenType.Operator)
			throw new ApplicationException($"Incorrect token! '{token.Raw}'");
		
		var pow = GetBindingPower(token);
		if(pow < minPow) break;
		
		tokens.Dequeue();
		
		left = ParseOp(token, left, PrattParse(tokens, pow));
	}
	
	return left;
}

Queue<Token> GetTokens(string expr)
{
	var val = @"(?:(?:\d*d\d+)|\d+)";
	var op = @"(?:\+|-|\*|/)";
	var util = @"(?:\(|\))";
	
	var tokens = new Queue<Token>();
	for(;;)
	{
		if (expr.Length == 0) break;
		
		var found = false;
		foreach((string, TokenType) o in new[]{(val, TokenType.Value), (op, TokenType.Operator), (util, TokenType.Utility)})
		{
			var (ptrn, type) = o;
			
			var m = Regex.Match(expr, $"^{ptrn}");
			if (m.Success)
			{
				tokens.Enqueue(MakeToken(m.Value, type));
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

Token MakeToken(string raw, TokenType type)
{
	return type switch
	{
		TokenType.Value => raw.Contains("d") ?
			new Token(Tokens.RandomValue, TokenType.Value, raw)
			: new Token(Tokens.Value, TokenType.Value, raw),
		TokenType.Operator => raw switch
			{
				"+" => new Token(Tokens.Plus, TokenType.Operator, raw),
				"-" => new Token(Tokens.Minus, TokenType.Operator, raw),
				"*" => new Token(Tokens.Multiply, TokenType.Operator, raw),
				"/" => new Token(Tokens.Divide, TokenType.Operator, raw),
				_ => throw new ApplicationException($"Incorrect expression! '{raw}'"),
			},
		TokenType.Utility => raw switch
			{
				"(" => new Token(Tokens.BraceOpen, TokenType.Utility, raw),
				")" => new Token(Tokens.BraceClose, TokenType.Utility, raw),
				_ => throw new ApplicationException($"Incorrect expression! '{raw}'"),
			},
		_ => throw new ApplicationException($"UnknownType! '{type}'"),
	};
}

IOp ParseVal(Token token)
{
	if (token.Raw.StartsWith('d'))
		return new RandOp(1, Int32.Parse(token.Raw.Substring(1)), rand);
	var sub = token.Raw.Split('d');
	
	return sub.Length switch
	{
		1 => new ValOp(Int32.Parse(sub[0])),
		2 => new RandOp(Int32.Parse(sub[0]), Int32.Parse(sub[1]), rand),
		_ => throw new ApplicationException($"Incorrect expression! '{token.Raw}'"),
	};
}

int GetBindingPower(Token token)
{
	return token.Value switch
	{
		Tokens.Plus => 10,
		Tokens.Minus => 11,
		Tokens.Multiply => 20,
		Tokens.Divide => 21,
		Tokens.BraceOpen => 1,
		Tokens.BraceClose => 0,
		_ => throw new ApplicationException($"Incorrect token! '{token}'"),
	};
}

IOp ParseOp(Token token, IOp left, IOp right)
{
	return token.Value switch
	{
		Tokens.Plus => new AddOp(left, right),
		Tokens.Minus => new SubOp(left, right),
		Tokens.Multiply => new MulOp(left, right),
		Tokens.Divide => new DivOp(left, right),
		_ => throw new ApplicationException($"Incorrect expression! '{token.Raw}'"),
	};
}

class Token(Tokens _value, TokenType _type, string _raw)
{
	public Tokens Value => _value;
	public TokenType Type => _type;
	public string Raw => _raw;
}
enum Tokens
{
	Unknown = 0,
	Value = 1,
	RandomValue,
	Plus,
	Minus,
	Multiply,
	Divide,
	BraceOpen,
	BraceClose,
}
enum TokenType
{
	Unknown = 0,
	Value = 1,
	Operator = 2,
	Utility = 3,
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
