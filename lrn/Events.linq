<Query Kind="Program">
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

string str = "ok";
	
void Main()
{
	Task tsk = new Task(() =>
	{
		evCls a = new evCls();
		
		a.ghoolEv += evMtd;
		
		for(int i = 0; i < 3; i++)
		{
			//Thread.Sleep(1000);
			
			a.zomM();
		}
	});
    
    tsk.Start();
	
	tsk.Dump();// = "Tsk";
    
    tsk.Wait();
	str.Dump();
    
	/*for(int i = 0; i > 1000; i++)
	{
		str.Dump();
		
		Thread.Sleep(1);
	}*/
}

void evMtd(object sender, EventArgs e)
{
    Thread.Sleep(1000);
    
	str += " hi";
}

class evCls
{
	public void zomM()
	{
		ghoolEv(this, new EventArgs());
	}
	
	public event EventHandler ghoolEv;
}