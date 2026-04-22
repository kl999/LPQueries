<Query Kind="Program">
  <Namespace>Microsoft.Extensions.Configuration</Namespace>
  <Namespace>System.Collections.Concurrent</Namespace>
  <Namespace>System.Text.Json</Namespace>
  <Namespace>System.Text.Json.Nodes</Namespace>
  <Namespace>System.Text.Json.Serialization</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

string expression =
	"1";
	//"d10 IF 1 GOTO ([1] < 4)*1 + ([1] >= 4)*2|d10 IF 1 GOTO ([1] < 5)*1 + ([1] >= 5)*2";
	//"(0;0| [1];d6 | [1]+[2];[2] IF [2] == 6 GOTO 2 | [1]) > 6";
	//"20d6 EACH >= 4| [1]d6 EACH >= 5| [1]d6 EACH >= 3";
	//"d52 <= 20 AND d51 <= 4 AND d50 <= 3 AND d49 <= 2 AND d48 <= 1";
string[] compare = [
];
int sampleSize =
	//1;
	3_000_000;
	//100_000_000;
static Random rand = new Random();

void Main()
{
	Parse(expression)//new Var(new Var(Op), Op)
		.Dump(includePrivate:true);
	
	MonteCarlo(expression);
	
	foreach(var expr in compare)
		MonteCarlo(expr);
}
void MonteCarlo(string expr)
{
	var lastRound = Parse(expr);
		
	var results = new ConcurrentDictionary<string, long>();
	
	for(int i = 0; i < sampleSize; i++)
	{
		var result = String.Join(";", lastRound.GetResults());
		
		//$"{result}".Dump();
		
		if(results.ContainsKey(result))
			results[result]++;
		else
			results[result] = 1;
	}
	
	expr.Dump("Expr");
	foreach(var result in results.OrderBy(i => i.Key.PadLeft(100, '0')))
		$"{result.Key}: {(((decimal)result.Value) / sampleSize) * 100:0.00########} %".Dump();
}

Round Parse(string expr)
{
	var tokens = GetTokens(expr)
		//.Dump()
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
	
	if (token.Value == Tokens.Minus)
		left = new MulOp(new ValOp(-1), PrattParse(tokens, 50));
	else if (token.Value == Tokens.RandomValue)
	{
		left = ParseOp(token, new ValOp(1), null);
	}
	else if (token.Value == Tokens.BraceOpen)
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
		if (token.Value == Tokens.RandomValue)
		{
			left = ParseOp(token, left, null);
			tokens.Dequeue();
			continue;
		}
		else if (token.Value == Tokens.BraceClose)
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
		
		//$"ParseOp({token.Value}, {left}, PrattParse(tokens({tokens.Count}), {pow} + 1));".Dump();
		left = ParseOp(token, left, PrattParse(tokens, pow + 1));
	}
	
	return left;
}

int GetBindingPower(Token token)
{
	return token.Value switch
	{
		Tokens.BraceClose => 0,
		Tokens.BraceOpen => 1,
		Tokens.RoundSeparator => 2,
		Tokens.If => 3,
		Tokens.Goto => 4,
		Tokens.VarSeparator => 4,
		Tokens.SquareBracketClose => 5,
		Tokens.SquareBracketOpen => 6,
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
		Tokens.RandomValue => 50,
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
		Tokens.RandomValue => new RandOp(left, Int32.Parse(token.Raw.Substring(1)), rand),
		Tokens.If => new IfOp(left, right),
		Tokens.Goto => new GotoOp(left, right),
		_ => throw new ApplicationException($"Incorrect expression! '{token.Raw}'"),
	};
}

Queue<Token> GetTokens(string expr)
{
	var val = @"(?:\d+)";
	var op = @"(?:\+|-|\*|/|COMP|AND|OR|>=|>|<=|<|==|!=|;|\||EACH|d\d+|IF|GOTO)";
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
	return new ValOp(Int32.Parse(token.Raw));
}

interface IOp
{
	int Execute(List<int> context);
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
		return GetResults().First();
	}
	
	public List<int> GetResults()
	{
		var rounds = GetRounds()
			//.Dump("rounds")
			;
		List<int> previous = new ();
		
		for(int i = 0; i < rounds.Count;)
		{
			previous = rounds[i].GetResults(previous);
			if (rounds[i] is IfOp if1)
			{
				var jump = if1.GetJump(previous);
				if (jump is null)
				{
					i++;
					continue;
				}
				if (jump < 1 || jump > rounds.Count)
					throw new ApplicationException($"Jump {jump} is out of bounds! round {i}");
				
				i = jump.Value - 1;
			}
			else
				i++;
		}
		
		return previous;
	}

	public List<Variable> GetRounds()
	{
		var rounds = new List<Variable>();
		
		if (Left is Round round)
			rounds.AddRange(round.GetRounds());
		else
			rounds.Add(Left is Variable v ? v : new Variable(Left));
		
		if (Right is not null)
			rounds.Add(Right is Variable v2 ? v2 : new Variable(Right));
		
		return rounds;
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
	
	public virtual int Execute(List<int> context) => Right is null ? Left.Execute(context) : Right.Execute(context);
	
	public virtual List<int> GetResults(List<int> previous)
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

class IfOp : Variable
{
	public IfOp(IOp _op) : base(_op)
	{
	}
	
	public IfOp(IOp _left, IOp _right) : base(_left, _right)
	{
	}
	
	public override int Execute(List<int> context) => Left.Execute(context);
	
	public override List<int> GetResults(List<int> previous)
	{
		var result = new List<int>();
		
		if (Left is Variable variable)
			result.AddRange(variable.GetResults(previous));
		else
			result.Add(Left.Execute(previous));
		
		return result;
	}
	
	public int? GetJump(List<int> context)
	{
		var goto1 = Right as GotoOp;
		
		if(goto1 is null) throw new ApplicationException("No GOTO found!");
		
		if(goto1.ShouldJump(context))
			return goto1.JumpTarget(context);
		else
			return null;
	}
}

class GotoOp(IOp left, IOp right) : IOp
{
	public int Execute(List<int> context) => throw new NotImplementedException();
	
	public bool ShouldJump(List<int> context) => left.Execute(context) != 0;
	public int JumpTarget(List<int> context) => right.Execute(context);
	
	public override string ToString() => $"{left} goto: {right}";
}

class ValOp(int val) : IOp
{
	public int Execute(List<int> context) => val;
	
	public override string ToString() => $"var: {val}";
}

class RandOp(IOp left, int max, Random rand) : IOp
{
	public int Execute(List<int> context)
	{
		var ct = left.Execute(context);
		
		if (ct < 0) throw new ApplicationException($"Dice count must be >= 0! Current {ct}");
		
		return Enumerable.Range(0, ct).Sum(i => rand.Next(max) + 1);
	}
	public List<int> GetList(List<int> context)
	{
		var ct = left.Execute(context);
		
		if (ct < 0) throw new ApplicationException($"Dice count must be >= 0! Current {ct}");
		
		return Enumerable.Range(0, ct).Select(i => rand.Next(max) + 1).ToList();
	}
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
	public override string ToString() => $"ctxt: {indexOp}";
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
		var var1 = left as Variable;
		
		if(randOp is not null)
		{
			return randOp.GetList(context).Where(i => ParseOp(token, new ValOp(i), right).Execute(context) != 0).Count();
		}
		else if (var1 is not null)
		{
			return var1.GetResults(context).Where(i => ParseOp(token, new ValOp(i), right).Execute(context) != 0).Count();
		}
		else
			throw new ApplicationException("Left hand side of EACH operator must be Random value (ex: '3d6') or values list (ex: '(1;2;3)')!");
		
		
	}
}

Token MakeToken(string raw, TokenType type)
{
	return type switch
	{
		TokenType.Value => new Token(Tokens.Value, TokenType.Value, raw),
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
				"IF" => new Token(Tokens.If, TokenType.Operator, raw),
				"GOTO" => new Token(Tokens.Goto, TokenType.Operator, raw),
				_ => raw.Contains("d") ?
					new Token(Tokens.RandomValue, TokenType.Operator, raw)
					: throw new ApplicationException($"Incorrect expression! '{raw}'"),
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
	If,
	Goto,
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

