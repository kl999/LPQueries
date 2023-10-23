<Query Kind="Program" />

void Main()
{
	MagicNumber(9).Dump("9");
	MagicNumber(13).Dump("13");
	MagicNumber(123).Dump("123");
	
	for(int i = 0, offset = 0; i < 500; i++)
	{
		$"{offset + i}: {MagicNumber(offset + i)}".Dump();
	}
}

int MagicNumber(int number)
{
	var tempValue = 0;
	
	for(;;)
	{
		if(number < 10)
			return number;
		
		tempValue = number;
		
		number = 0;
		
		for(;;)
		{
			number += tempValue % 10;
			
			tempValue = tempValue / 10;
			
			if(tempValue < 10)
			{
				number += tempValue;
				break;
			}
		}
	}
}