<Query Kind="Program">
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	programm obj = new programm();
	
	obj.work();
}

class programm
{
	static int a = 5, b = 10, c = 20;
	
	public void work()
	{
		Console.WriteLine("a + b + c = " + (a + b + c));
		
		Console.WriteLine("Please enter the name of the variable"
		+ " that you wish to change:");
		
		string varName = Console.ReadLine();
		
		Type t = this.GetType();//typeof();
		
		FieldInfo fieldInfo = t.GetField(
			varName,
			BindingFlags.NonPublic | BindingFlags.Static);
		
		if(fieldInfo != null)
		{
			Console.WriteLine("The current value of "
				+ fieldInfo.Name + " is " + fieldInfo.GetValue(null)
				+ ". You may enter a new value now:");
			
			string newValue = Console.ReadLine();
			
			int newInt;
			
			if(int.TryParse(newValue, out newInt))
			{
				fieldInfo.SetValue(null, newInt);
				
				Console.WriteLine("a + b + c = " + (a + b + c));
			}
		}
		else
			"bad".Dump();
	}
}
