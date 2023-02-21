<Query Kind="Program" />

void Main()
{
	var a = new A()
	{
		a = new TimeEnum(),
	};
	
	foreach(var item in  a.a ?? new int[0])
	{
		item.Dump();
	}
}

class A
{
	public IEnumerable<int> a;
}

class TimeEnum : IEnumerable<int>
{
	public IEnumerator<int> GetEnumerator()
	{
		return GetEnum().GetEnumerator();
	}
	
	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnum().GetEnumerator();
	}
	
	private IEnumerable<int> GetEnum()
	{
		for(int cur = 11; cur > 10; )
			yield return cur = (int)(DateTime.Now.Ticks % 10000);
	}
}