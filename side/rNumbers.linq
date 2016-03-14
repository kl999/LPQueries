<Query Kind="Statements" />

Dictionary<string, int> dic = new Dictionary<string, int>();

Func<int, string> getStr = i =>
{
	if(i > 3999)
		return "not above 3999!";
	
	string temp = "*N*";
	
	Func<int, char, char, char, string> tF = (z, low, mid, up) =>
	{
		string temp1 = "***";
	
		if(z > 0 && z < 11)
		{
			if( z < 4)
			{
				temp1 = "";
				
				for(int x = 0; x < z; x++)
				{
					temp1 += low;
				}
			}
			
			if(z == 4)
			{ temp1 = low.ToString(); temp1 += mid.ToString(); }
			
			if( z > 4 && z < 9)
			{
				temp1 = mid.ToString();
				
				int tI = z - 5;
				
				for(int x = 0; x < tI; x++)
				{
					temp1 += low.ToString();
				}
			}
			
			if(z == 9)
			{ temp1 = low.ToString() + up.ToString(); }
			
			if(z == 10)
			{ temp1 = up.ToString(); }
		}
		else throw new Exception("Code breaker " + i);
		
		return temp1;
	};
	
	temp = "";
	
	int rank = (i - ((i / 10000) * 10000)) / 1000;
	if(rank > 0)
	{ temp += tF(rank, 'M', '*', '*'); }
	
	rank = (i - ((i / 1000) * 1000)) / 100;
	if(rank > 0)
	{ temp += tF(rank, 'C', 'D', 'M'); }
	
	rank = (i - ((i / 100) * 100)) / 10;
	if(rank > 0)
	{ temp += tF(rank, 'X', 'L', 'C'); }
	
	rank = i - ((i / 10) * 10);
	if(rank > 0)
	{ temp += tF(rank, 'I', 'V', 'X'); }
	
	return temp;
};

/*for(int i = 0; i < 4000; i++)
{
	dic[getStr(i)] = i;
}*/

for(;;)
{
	string tStr = Console.ReadLine();
	
	tStr = tStr.ToUpper();
	
	if(tStr == "EXIT")
		break;
		
	//dic[tStr].Dump();
	getStr(Int32.Parse(tStr)).Dump();
}