<Query Kind="Program">
  <Namespace>Microsoft.Extensions.Configuration</Namespace>
  <Namespace>System.Text.Json</Namespace>
  <Namespace>System.Text.Json.Nodes</Namespace>
  <Namespace>System.Text.Json.Serialization</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

string expression =
	"0;1";
	//"d52 <= 20 AND d51 <= 4 AND d50 <= 3 AND d49 <= 2 AND d48 <= 1";
int sampleSize =
	100_000;
	//100_000_000;
Random rand = new Random();

void Main()
{
	/*Parse("d5 COMP d6 COMP d7")
		.Dump(includePrivate:true)
		.Execute()
		.Dump();*/
	var expr = Parse(expression);/*new OpVal(
		new AddOp(
			new RandVal(2, 6, rand),
			new Val(1)
		)
	);*/
	
	var results = new Dictionary<string, long>();
	
	for(int i = 0; i < sampleSize; i++)
	{
		var result = expr.Execute().ToString();
		
		//$"{result}".Dump();
		
		if(results.ContainsKey(result))
			results[result]++;
		else
			results[result] = 1;
	}
	
	foreach(var result in results.OrderBy(i => i.Key))
		$"{result.Key}: {(((decimal)result.Value) / sampleSize) * 100:0.00########} %".Dump();
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
		
		left = ParseOp(token, left, PrattParse(tokens, pow + 1));
	}
	
	return left;
}

Queue<Token> GetTokens(string expr)
{
	var val = @"(?:(?:\d*d\d+)|\d+)";
	var op = @"(?:\+|-|\*|/|COMP|AND|OR|>=|>|<=|<|==|!=)";
	var util = @"(?:\(|\)|;)";
	
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
		Tokens.BraceClose => 0,
		Tokens.BraceOpen => 1,
		Tokens.VarSeparator => 2,
		Tokens.VarsDeclareEnd => 3,
		Tokens.Compare => 10,
		Tokens.Or => 11,
		Tokens.And => 12,
		Tokens.Greater => 20,
		Tokens.GreaterOrEqual => 21,
		Tokens.Less => 22,
		Tokens.LessOrEqual => 23,
		Tokens.Equal => 24,
		Tokens.NotEqual => 25,
		Tokens.Plus => 30,
		Tokens.Minus => 31,
		Tokens.Multiply => 40,
		Tokens.Divide => 41,
		_ => throw new ApplicationException($"Incorrect token! '{token}'"),
	};
}

IOp ParseOp(Token token, IOp left, IOp right)
{
	return token.Value switch
	{
		Tokens.Compare => new CompOp(left, right),
		Tokens.And => new AndOp(left, right),
		Tokens.Or => new OrOp(left, right),
		Tokens.Greater => new GreaterOp(left, right),
		Tokens.GreaterOrEqual => new GreaterOrEqualOp(left, right),
		Tokens.Less => new LessOp(left, right),
		Tokens.LessOrEqual => new LessOrEqualOp(left, right),
		Tokens.Equal => new EqualOp(left, right),
		Tokens.NotEqual => new NotEqualOp(left, right),
		Tokens.Plus => new AddOp(left, right),
		Tokens.Minus => new SubOp(left, right),
		Tokens.Multiply => new MulOp(left, right),
		Tokens.Divide => new DivOp(left, right),
		_ => throw new ApplicationException($"Incorrect expression! '{token.Raw}'"),
	};
}

class Round
{
	public List<Variable> Variables = new();
	public Round Previous = null;
}

class Variable
{
	public int value;
	public IOp op;
	
	public Variable(int _value, IOp _op)
	{
		value = _value;
		op = _op;
	}
	
	public void Collapse()
	{
		value = op.Execute();
	}
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

class CompOp(IOp left, IOp right) : IOp
{
	public int Execute()
	{
		var contestants = GetContestants();
		
		var i = 1;
		var max = contestants.First();
		var maxInd = i;
		i++;
		foreach(var val in contestants.Skip(1))
		{
			if (val > max)
			{
				max = val;
				maxInd = i;
			}
			i++;
		}
		
		return maxInd;
	}
	private List<int> GetContestants()
	{
		var result = new List<int>();
		if(left is CompOp c)
			result.AddRange(c.GetContestants());
		else
			result.Add(left.Execute());
		result.Add(right.Execute());
		
		return result;
	}
}

class AndOp(IOp left, IOp right) : IOp
{
	public int Execute() => left.Execute() > 0 && right.Execute() > 0 ? 1 : 0;
}

class OrOp(IOp left, IOp right) : IOp
{
	public int Execute() => left.Execute() > 0 || right.Execute() > 0 ? 1 : 0;
}

class GreaterOp(IOp left, IOp right) : IOp
{
	public int Execute() => left.Execute() > right.Execute() ? 1 : 0;
}

class GreaterOrEqualOp(IOp left, IOp right) : IOp
{
	public int Execute() => left.Execute() >= right.Execute() ? 1 : 0;
}

class LessOp(IOp left, IOp right) : IOp
{
	public int Execute() => left.Execute() < right.Execute() ? 1 : 0;
}

class LessOrEqualOp(IOp left, IOp right) : IOp
{
	public int Execute() => left.Execute() <= right.Execute() ? 1 : 0;
}

class EqualOp(IOp left, IOp right) : IOp
{
	public int Execute() => left.Execute() == right.Execute() ? 1 : 0;
}

class NotEqualOp(IOp left, IOp right) : IOp
{
	public int Execute() => left.Execute() != right.Execute() ? 1 : 0;
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

Token MakeToken(string raw, TokenType type)
{
	return type switch
	{
		TokenType.Value => raw.Contains("d") ?
			new Token(Tokens.RandomValue, TokenType.Value, raw)
			: new Token(Tokens.Value, TokenType.Value, raw),
		TokenType.Operator => raw switch
			{
				"COMP" => new Token(Tokens.Compare, TokenType.Operator, raw),
				"AND" => new Token(Tokens.And, TokenType.Operator, raw),
				"OR" => new Token(Tokens.Or, TokenType.Operator, raw),
				">" => new Token(Tokens.Greater, TokenType.Operator, raw),
				">=" => new Token(Tokens.GreaterOrEqual, TokenType.Operator, raw),
				"<" => new Token(Tokens.Less, TokenType.Operator, raw),
				"<=" => new Token(Tokens.LessOrEqual, TokenType.Operator, raw),
				"==" => new Token(Tokens.Equal, TokenType.Operator, raw),
				"!=" => new Token(Tokens.NotEqual, TokenType.Operator, raw),
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
				";" => new Token(Tokens.VarSeparator, TokenType.Utility, raw),
				"|" => new Token(Tokens.VarsDeclareEnd, TokenType.Utility, raw),
				_ => throw new ApplicationException($"Incorrect expression! '{raw}'"),
			},
		_ => throw new ApplicationException($"UnknownType! '{type}'"),
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
	BraceOpen = 1,
	BraceClose,
	VarSeparator,
	VarsDeclareEnd,
	Compare,
	Or,
	And,
	Greater,
	GreaterOrEqual,
	Less,
	LessOrEqual,
	Equal,
	NotEqual,
	Value,
	RandomValue,
	Plus,
	Minus,
	Multiply,
	Divide,
}
enum TokenType
{
	Unknown = 0,
	Value = 1,
	Operator = 2,
	Utility = 3,
}

