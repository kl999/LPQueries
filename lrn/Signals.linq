<Query Kind="Program">
  <Namespace>Microsoft.Extensions.Configuration</Namespace>
  <Namespace>System.Text.Json</Namespace>
  <Namespace>System.Text.Json.Nodes</Namespace>
  <Namespace>System.Text.Json.Serialization</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

// https://willybrauner.com/journal/signal-the-push-pull-based-algorithm

void Main()
{
	var a = new Signal(5);
	
	var b = new Computable(() => a.Value + 1);
	
	var c = new Computable(() => b.Value * 6);
	
	b.Value.Dump();
	
	a.Value++;
	
	b.Value.Dump();
	
	c.Value.Dump();
	
	a.Value++;
	
	b.Value.Dump();
	
	c.Value.Dump();
	
	/*a.Dump(includePrivate:true);
	b.Dump(includePrivate:true);
	c.Dump(includePrivate:true);*/
}

//Globals stack
public static Stack<(Action notify, Action<Action> addSource)> STACK = new();

class Signal
{
	List<Action> subs = new();
	
	public Signal(int value)
	{
		_value = value;
	}
	
	private int _value;
	public int Value
	{
		get
		{
			if(STACK.TryPeek(out (Action notify, Action<Action> addSource) cur))
			{
				subs.Add(cur.notify);
				cur.addSource(() => subs.Remove(cur.notify));
			}
			return _value;
		}
		set
		{
			_value = value;
			foreach(var sub in subs) sub();
		}
	}
}

class Computable
{
	private bool isDirty = true;
	private Func<int> eval;
	List<Action> subs = new();
	private List<Action> sources = new();
	
	public Computable(Func<int> eval)
	{
		this.eval = eval;
	}
	
	private int _value;
	public int Value
	{
		get
		{
			if(STACK.TryPeek(out (Action notify, Action<Action> addSource) cur))
			{
				subs.Add(cur.notify);
				cur.addSource(() => subs.Remove(cur.notify));
			}
			if(isDirty)
				Eval();
			
			return _value;
		}
	}
	
	private void Eval()
	{
		sources.ForEach(i => i());
		sources.Clear();
		
		STACK.Push((
			new Action(() =>
			{
				if(isDirty) return;
				isDirty = true;
				foreach(var sub in subs) sub();
			}),
			new Action<Action>((unsub) => sources.Add(unsub))
		));
		
		_value = eval();
		
		isDirty = false;
		
		STACK.Pop();
	}
}
