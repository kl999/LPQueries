<Query Kind="Program">
  <Connection>
    <ID>b35e2479-3b0e-4dd6-bd5f-36670a7fe583</ID>
    <Persist>true</Persist>
    <Driver Assembly="IQDriver" PublicKeyToken="5b59726538a49684">IQDriver.IQDriver</Driver>
    <Provider>Devart.Data.MySql</Provider>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAXpJ+KyRD6U+pcsygin2BCgAAAAACAAAAAAADZgAAwAAAABAAAACREX2+tLaFEppNNnO8ecpBAAAAAASAAACgAAAAEAAAAEHgtGt1TILs2eYyk9+Zx8M4AAAAOqFxxJYGkshKtROr2d/Y/tfVotVIlTygb+UiTZygbipu7XPLEyz9SQC6vx1ofCb+iSPzikzntkoUAAAAvSeOWuPI5AjsddgD8SRI31SXGAY=</CustomCxString>
    <Server>192.168.0.13</Server>
    <Database>avideo</Database>
    <UserName>video</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAXpJ+KyRD6U+pcsygin2BCgAAAAACAAAAAAADZgAAwAAAABAAAAAxoqwgcoRFGaWg4mq52TjmAAAAAASAAACgAAAAEAAAAOehqnKZvhaeJJ6wpD6EWU8IAAAAMI20flaJLuQUAAAAILu84iqrc3EC74EN3i8gqU8k2LI=</Password>
    <DisplayName>aVideo</DisplayName>
    <EncryptCustomCxString>true</EncryptCustomCxString>
    <DriverData>
      <StripUnderscores>false</StripUnderscores>
      <QuietenAllCaps>false</QuietenAllCaps>
    </DriverData>
  </Connection>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

manualresetevent

void Main()
{
	var tsk = (new MyTask(hello));
	tsk.start();
	
	tsk.isFinished().Dump();
	
	//Thread.Sleep(2001);
	
	tsk.wait();
	
	tsk.isFinished().Dump();
	
	/*var tsk = (new MyTask<int>(world));
	
	tsk.start();
	
	tsk.wait().Dump();*/
}

void hello()
{
	Thread.Sleep(2000);
	"Hello".Dump();
}

int world()
{
	Thread.Sleep(2000);
	
	return 5;
}

class MyTask
{
	public delegate void action();
	
	public action a;
	
	private bool finished = false;
	
	private object finishedLocker = new object();
	
	private object taskLocker = new object();
	
	public MyTask(action _a)
	{
		a = _a;
	}
	
	public void start()
	{
		Thread trd = new Thread(run);
		
		trd.IsBackground = false;
		
		trd.Start();
		
		Monitor.Enter(taskLocker);
	}
	
	private void run()
	{
		a();
		
		lock(finishedLocker)
		{
			finished = true;
		}
		
		Monitor.Exit(taskLocker);
	}
	
	public bool isFinished()
	{
		lock(finishedLocker)
		{
			return finished;
		}
	}
	
	public void wait()
	{
		Monitor.Enter(taskLocker);
		Monitor.Exit(taskLocker);
	}
}

class MyTask<T>
{
	public delegate T action();
	
	public action a;
	
	private bool finished = false;
	
	private T rez;
	
	private object finishedLocker = new object();
	
	private object taskLocker = new object();
	
	public MyTask(action _a)
	{
		a = _a;
	}
	
	public void start()
	{
		Thread trd = new Thread(run);
		
		trd.IsBackground = false;
		
		trd.Start();
		
		Monitor.Enter(taskLocker);
	}
	
	private void run()
	{
		rez = a();
		
		lock(finishedLocker)
		{
			finished = true;
		}
		
		Monitor.Exit(taskLocker);
	}
	
	public bool isFinished()
	{
		lock(finishedLocker)
		{
			return finished;
		}
	}
	
	public T wait()
	{
		lock(taskLocker)
		{
			return rez;
		}
	}
}