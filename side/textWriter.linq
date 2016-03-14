<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	//"I am some test\nwritten string".strWrt(100);
	
	File.ReadAllText(@"c:\sp\text.txt").strWrt(50);
}

static class strHlpr
{
	public static void strWrt(this string str, int speed)
	{
		string[] lines = str.Split('\n');
		
		foreach(string temp in lines)
		{
			string[] words = temp.Split(' ');
			
			foreach(string word in words)
			{
				/*foreach(char ch in word)
				{
					Console.Write(ch);
				
					Task.Delay(speed).Wait();
				}*/
				
				Console.Write(word);
				
				Console.Write(" ");
				
				Task.Delay(speed).Wait();
			}
			
			Task.Delay(speed * 10).Wait();
			
			Console.WriteLine();
		}
	}
}