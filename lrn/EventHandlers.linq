<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var a = new EvCheck();
	
	a.InvokeDelegate();
	
	a.handler += new EventHandler((o,e) => "aaa".Dump());
	a.handler += new EventHandler(InvMethod);
	
	a.InvokeDelegate();
	
	a.handler -= new EventHandler(InvMethod);
	a.handler -= new EventHandler((o,e) => "aaa".Dump());
	a.handler -= new EventHandler((o,e) => "bbb".Dump());
	
	a.InvokeDelegate();
}

void InvMethod(object sender, EventArgs e) => "invoked".Dump();

class EvCheck
{
	public event EventHandler handler;
	
	public void InvokeDelegate()
	{
		if(handler is null) return;
		handler.Invoke(this, new EventArgs());
	}
}
