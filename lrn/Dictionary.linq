<Query Kind="Statements" />

Dictionary<string, int> dic = new Dictionary<string, int>();

Func<int, string> getStr = i =>
{
	string temp = i.ToString();
	
	return 
		new String(temp.
			Select(ch => "XABCDEFGHI"[Int32.Parse(ch.ToString())]).ToArray());
};

for(int i = 0; i < 10000; i++)
{
	dic["number of " + getStr(i)] = i;
}

for(;;)
{
	string tStr = Console.ReadLine();
	
	tStr = tStr.ToUpper();
	
	if(tStr == "EXIT")
		break;
	
	System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
	sw.Start();
	
	dic["number of " + tStr].Dump();
	
	sw.Stop();
	sw.Elapsed.TotalMilliseconds.Dump("time");
}