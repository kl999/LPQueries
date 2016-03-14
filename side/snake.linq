<Query Kind="Statements" />

Random rand = new Random();
int pos = 0;

var randS = System.Security.Cryptography.RandomNumberGenerator.Create();


for(;;)
{
	string str = "..........";
	int rez = rand.Next(3);
	
	byte[] buf = new byte[1];
	randS.GetBytes(buf);
	//int rez = (int)(((double)buf[0] / 255) * 3);
	
	switch (rez)
	{
		case 1:
		{
			if(pos > 0)
			{
				pos--;
			}
			break;
		}
		
		case 2:
		{
			if(pos < 9)
			{
				pos++;
			}
			break;
		}
	}
	str = new String(str.Select((i,j) => 
	{
	if(j==pos)
	{
		if(rez == 0)
			i = '|';
		if(rez == 1)
			i = '/';
		if(rez == 2)
			i = '\\';
	}
		
	return i;
	}).ToArray());
	
	str.Dump();
	System.Threading.Thread.Sleep(100);
}