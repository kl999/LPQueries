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
	string loadetStr = 
@"[map]
mmmmm
mfr.m
m...m
m...m
mmmmm
[/map]";
	
	string[] ldArr = loadetStr.Split('\n');
	
	//ldArr.Dump();
	
	getMap(ldArr);
}


void getMap(string[] ldArr)
{
	bool bad = false;
	
	List<string> mapStr = new List<string>();
	
	for(int i = 0; i < ldArr.Length; i++)
	{
		if(ldArr[i].Trim() == "[map]")
		{
			for(;;)
			{
				i++;
				
				if(ldArr[i] == "[/map]")
				{
					break;
				}
				else if(i == ldArr.Length - 1)
				{
					bad = true;
					break;
				}
				
				mapStr.Add(ldArr[i].Trim());
			}
		}
	}
	
	mapStr.Dump();
	
	int rowl = mapStr.Count(),
		coll = 0;
		
	char[,] chMap = null;
	
	if(rowl == 0)
		bad = true;
	else
	{
		coll = mapStr[0].Length;
		
		if(coll == 0)
			bad = true;
		else
		{
			//("cols: " + coll + " rows: " + rowl).Dump();
			chMap = new char[coll, rowl];
			
			for(int y = 0; y < rowl; y++)
			{
				if(mapStr[y].Length == coll)
				{		
					for(int x = 0; x < coll; x++)
					{
						chMap[x, y] = getTile(mapStr[y][x]);
					}
				}
				else
				{
					//mapStr[y].Dump("bad");
					//Encoding.UTF8.GetBytes(mapStr[y]).Dump();
					bad = true;
					break;
				}
			}
		}
	}
	
	(bad ? "fl" : "sc").Dump();
	
	if(!bad)
	{
		chMap.Dump();
	}
}

char getTile(char ch)
{
	return ch;
}