<Query Kind="Program" />

void Main()
{
	var prevArr = new int[237].Select(i => 66).ToArray();
	
	var charArr = new int[237].Select(i => 66).ToArray();
	
	$"{((int)'A')} - {((int)'Z')}".Dump();
	$"{((int)'a')} - {((int)'z')}".Dump();
	
	for(int row = 0; row < 500; row++)
	{
		prevArr = charArr;
		charArr = new int[prevArr.Length];
		charArr[0] = prevArr[prevArr.Length - 1];
		
		for(int i = 1; i < charArr.Length; i++)
		{
			charArr[i] = SimpleNum(charArr[i - 1], prevArr[i]);
		}
	
		String.Join("", charArr.Select(i => (char)i)).Dump();
	}
}

int SimpleNum(int prev, int upper)
{
	var ch = prev - 65;
	
	ch += upper - 65;
	
	ch = ch % 3;
	
	return ch + 65;
}

int FullChar(int prev, int upper)
{
	var ch = prev + upper;
	
	for(;;)
	{
		ch = ch % 123;
		
		for(;;)
		{
			if(ch < 65)
			{
				ch += 65;
				ch = ch % 123;
			}
			else
				break;
		}
		
		if(ch > 90)
			ch += 6;
		else
			break;
	}
	
	return ch;
}