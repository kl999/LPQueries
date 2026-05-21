<Query Kind="Program">
  <Namespace>Microsoft.Extensions.Configuration</Namespace>
  <Namespace>System.Text.Json</Namespace>
  <Namespace>System.Text.Json.Nodes</Namespace>
  <Namespace>System.Text.Json.Serialization</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

void Main()
{
	Expression<Func<int, int>> a = (a) => 1 + a;
	
	var v = new ExpressionCounterVisitor();
	
	v.Visit(a.Body);
	
	v.Counts.Dump();
}

public class ExpressionCounterVisitor : ExpressionVisitor
{
    public Dictionary<string, int> Counts { get; private set; } = 
        new Dictionary<string, int>();

    public override Expression Visit(Expression node)
    {
        var key = node.NodeType.ToString();
        if (Counts.ContainsKey(key))
        {
            Counts[key] += 1;
        }
        else
        {
            Counts.Add(key, 1);
        }
        
        return base.Visit(node);
    }
}
