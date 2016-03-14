<Query Kind="Program">
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	myCls obj = new myCls();
	
	int timesGot = 0;
	
	for(;;)
	{
		rezStr rez = obj.getRez();
		
		((rez.str == null ? "nothing" : rez.str
		+ " " + rez.arr.Skip(5000).Take(3).Sum())
		+ " Iter: " + ++timesGot
		).Dump();
		
		if(rez.str == "Time is: 4")
			break;
	}
}

class myCls
{
	int[] arr = new int[1000000];
	
	string str = "No length.";
	
	int ct = 0;
	
	Random rand = new Random();
	
	object locker = new object();
	
	//New frame
	public myCls()
	{
		Task.Run(() =>
		{
			for(int i = 0; i < 4; i++)
			{
				doTmth();
			}
		});
	}
	
	void doTmth()
	{
		int[] temp = new int[1000000];
		
		for(int i = 0; i < 1000000; i++)
		{
			temp[i] = rand.Next(50, 100);
		}
		
		lock(locker)
		{
			arr = temp;
			str = "Time is: " + ++ct;
		}
	}
	
	public rezStr getRez()
	{
		lock(locker)
		{
			rezStr rez = new rezStr();
			rez.arr = arr;
			rez.str = str;

			return rez;
		}
	}
}

struct rezStr
{
	public int[] arr;
	
	public string str;
}