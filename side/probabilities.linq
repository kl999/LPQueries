<Query Kind="Program">
  <Namespace>Microsoft.Extensions.Configuration</Namespace>
  <Namespace>System.Text.Json</Namespace>
  <Namespace>System.Text.Json.Nodes</Namespace>
  <Namespace>System.Text.Json.Serialization</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

string expression =
	"5d3 EACH - 2";
	//"d52 <= 20 AND d51 <= 4 AND d50 <= 3 AND d49 <= 2 AND d48 <= 1";
int sampleSize =
	100_000;
	//100_000_000;
Random rand = new Random();

void Main()
{
	var lastRound = Parse(expression)
		.Dump(includePrivate:true)//new Var(new Var(Op), Op)
		;
	
	var results = new Dictionary<string, long>();
	
	for(int i = 0; i < sampleSize; i++)
	{
		var result = String.Join(";", lastRound.GetResults());
		
		//$"{result}".Dump();
		
		if(results.ContainsKey(result))
			results[result]++;
		else
			results[result] = 1;
	}
	
	foreach(var result in results.OrderBy(i => i.Key))
		$"{result.Key}: {(((decimal)result.Value) / sampleSize) * 100:0.00########} %".Dump();
}

Round Parse(string expr)
{
	var tokens = GetTokens(expr)
		.Dump()
		;
	
	var parsed = PrattParse(tokens, 0);
	
	if(parsed is Round round)
		return round;
	else if(parsed is Variable variable)
		return new Round(variable);
	
	return new Round(new Variable(parsed));
}

IOp PrattParse(Queue<Token> tokens, int minPow)
{
	var token = tokens.Dequeue();
	IOp left;
	
	if (token.Value == Tokens.BraceOpen)
	{
		left = PrattParse(tokens, GetBindingPower(token));
		if(!tokens.Any() || tokens.Peek().Value != Tokens.BraceClose)
			throw new ApplicationException("Expected ')'!");
		tokens.Dequeue();
	}
	else if (token.Value == Tokens.SquareBracketOpen)
	{
		left = new ContextAccessOp(PrattParse(tokens, GetBindingPower(token)));
		if(!tokens.Any() || tokens.Peek().Value != Tokens.SquareBracketClose)
			throw new ApplicationException("Expected ']'!");
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
		if (token.Value == Tokens.BraceClose)
			return left;
		else if (token.Value == Tokens.SquareBracketClose)
			return left;
		else if (token.Value == Tokens.Each)
		{
			var pow2 = GetBindingPower(token);
			tokens.Dequeue(); //Consume EACH
			token = tokens.Dequeue();
			if(token.Type != TokenType.Operator)
				throw new ApplicationException($"Must be operator after EACH operator! '{token.Raw}'");
			
			left = new EachOp(left, token, PrattParse(tokens, pow2));
			continue;
		}
		else if (token.Type != TokenType.Operator)
			throw new ApplicationException($"Incorrect token! '{token.Raw}'");
		
		var pow = GetBindingPower(token);
		if(pow < minPow) break;
		
		tokens.Dequeue();
		
		left = ParseOp(token, left, PrattParse(tokens, pow + 1));
	}
	
	return left;
}

int GetBindingPower(Token token)
{
	return token.Value switch
	{
		Tokens.RoundSeparator => 0,
		Tokens.VarSeparator => 1,
		Tokens.BraceClose => 2,
		Tokens.BraceOpen => 3,
		Tokens.SquareBracketClose => 4,
		Tokens.SquareBracketOpen => 5,
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
		Tokens.Each => 29,
		_ => throw new ApplicationException($"Incorrect token! '{token}'"),
	};
}

internal static IOp ParseOp(Token token, IOp left, IOp right)
{
	return token.Value switch
	{
		Tokens.RoundSeparator => new Round(left, right),
		Tokens.VarSeparator => new Variable(left, right),
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

Queue<Token> GetTokens(string expr)
{
	var val = @"(?:(?:\d*d\d+)|\d+)";
	var op = @"(?:\+|-|\*|/|COMP|AND|OR|>=|>|<=|<|==|!=|;|\||EACH)";
	var util = @"(?:\(|\)|\[|\])";
	
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

class Round : IOp
{
	public IOp Left = null;
	public IOp Right = null;
	
	public Round(IOp _variable)
	{
		Left = _variable;
	}
	
	public Round(IOp _left, IOp _right)
	{
		Left = _left;
		Right = _right;
	}
	
	public int Execute(List<int> context)
	{
		throw new NotImplementedException();
	}
	
	public List<int> GetResults()
	{
		var result = new List<int>();
		var previous = new List<int>();
		
		if (Left is Round round)
			previous = round.GetResults();
		else if (Left is Variable variable)
			previous = variable.GetResults(previous);
		else
			previous.Add(Left.Execute(previous));
		
		if (Right is Variable variable2)
			result.AddRange(variable2.GetResults(previous));
		else if (Right is not null)
			result.Add(Right.Execute(previous));
		else
			result.AddRange(previous);
		
		return result;
	}
}

class Variable : IOp
{
	public IOp Left;
	public IOp Right;
	
	public Variable(IOp _op)
	{
		Left = _op;
	}
	
	public Variable(IOp _left, IOp _right)
	{
		Left = _left;
		Right = _right;
	}
	
	public int Execute(List<int> context) => Right.Execute(context);
	
	public List<int> GetResults(List<int> previous)
	{
		var result = new List<int>();
		
		if (Left is Variable variable)
			result.AddRange(variable.GetResults(previous));
		else
			result.Add(Left.Execute(previous));
		
		if (Right is not null)
			result.Add(Right.Execute(previous));
		
		return result;
	}
}

interface IOp
{
	int Execute(List<int> context);
}

class ValOp(int val) : IOp
{
	public int Execute(List<int> context) => val;
}

class RandOp(int ct, int max, Random rand) : IOp
{
	public int Execute(List<int> context) => Enumerable.Range(0, ct).Sum(i => rand.Next(max) + 1);
	public List<int> GetList() => Enumerable.Range(0, ct).Select(i => rand.Next(max) + 1).ToList();
}

class ContextAccessOp(IOp indexOp) : IOp
{
	public int Execute(List<int> context)
	{
		var index = indexOp.Execute(context);
		if(index < 1 || index > context.Count)
			throw new ApplicationException($"Index [{index}] outside context!");
		
		return context[index - 1];
	}
}

class CompOp(IOp left, IOp right) : IOp
{
	public int Execute(List<int> context)
	{
		var contestants = GetContestants(context);
		
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
	private List<int> GetContestants(List<int> context)
	{
		var result = new List<int>();
		if(left is CompOp c)
			result.AddRange(c.GetContestants(context));
		else
			result.Add(left.Execute(context));
		result.Add(right.Execute(context));
		
		return result;
	}
}

class AndOp(IOp left, IOp right) : IOp
{
	public int Execute(List<int> context) => left.Execute(context) > 0 && right.Execute(context) > 0 ? 1 : 0;
}

class OrOp(IOp left, IOp right) : IOp
{
	public int Execute(List<int> context) => left.Execute(context) > 0 || right.Execute(context) > 0 ? 1 : 0;
}

class GreaterOp(IOp left, IOp right) : IOp
{
	public int Execute(List<int> context) => left.Execute(context) > right.Execute(context) ? 1 : 0;
}

class GreaterOrEqualOp(IOp left, IOp right) : IOp
{
	public int Execute(List<int> context) => left.Execute(context) >= right.Execute(context) ? 1 : 0;
}

class LessOp(IOp left, IOp right) : IOp
{
	public int Execute(List<int> context) => left.Execute(context) < right.Execute(context) ? 1 : 0;
}

class LessOrEqualOp(IOp left, IOp right) : IOp
{
	public int Execute(List<int> context) => left.Execute(context) <= right.Execute(context) ? 1 : 0;
}

class EqualOp(IOp left, IOp right) : IOp
{
	public int Execute(List<int> context) => left.Execute(context) == right.Execute(context) ? 1 : 0;
}

class NotEqualOp(IOp left, IOp right) : IOp
{
	public int Execute(List<int> context) => left.Execute(context) != right.Execute(context) ? 1 : 0;
}

class AddOp(IOp left, IOp right) : IOp
{
	public int Execute(List<int> context) => left.Execute(context) + right.Execute(context);
}

class SubOp(IOp left, IOp right) : IOp
{
	public int Execute(List<int> context) => left.Execute(context) - right.Execute(context);
}

class MulOp(IOp left, IOp right) : IOp
{
	public int Execute(List<int> context) => left.Execute(context) * right.Execute(context);
}

class DivOp(IOp left, IOp right) : IOp
{
	public int Execute(List<int> context) => left.Execute(context) / right.Execute(context);
}

class EachOp(IOp left, Token token, IOp right) : IOp
{
	public int Execute(List<int> context)
	{
		var randOp = left as RandOp;
		
		if(randOp is null)
			throw new ApplicationException("Left hand side of EACH operator must be Random value (ex: 3d6)!");
		
		return randOp.GetList().Where(i => ParseOp(token, new ValOp(i), right).Execute(context) != 0).Count();
	}
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
				";" => new Token(Tokens.VarSeparator, TokenType.Operator, raw),
				"|" => new Token(Tokens.RoundSeparator, TokenType.Operator, raw),
				"EACH" => new Token(Tokens.Each, TokenType.Operator, raw),
				_ => throw new ApplicationException($"Incorrect expression! '{raw}'"),
			},
		TokenType.Utility => raw switch
			{
				"(" => new Token(Tokens.BraceOpen, TokenType.Utility, raw),
				")" => new Token(Tokens.BraceClose, TokenType.Utility, raw),
				"[" => new Token(Tokens.SquareBracketOpen, TokenType.Utility, raw),
				"]" => new Token(Tokens.SquareBracketClose, TokenType.Utility, raw),
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
	SquareBracketOpen,
	SquareBracketClose,
	VarSeparator,
	RoundSeparator,
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
	Each,
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

